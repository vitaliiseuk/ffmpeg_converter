#include "config.h"

#define HAVE_CLOSESOCKET 1
#if !HAVE_CLOSESOCKET
#define closesocket close
#endif
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

#include <io.h>
#if defined(_WIN32) && !defined(__MINGW32CE__)
#  include <fcntl.h>
#  ifdef lseek
#   undef lseek
#  endif
#  define lseek(f,p,w) _lseeki64((f), (p), (w))
#  ifdef stat
#   undef stat
#  endif
#  define stat _stati64
#  ifdef fstat
#   undef fstat
#  endif
#  define fstat(f,s) _fstati64((f), (s))
#endif /* defined(_WIN32) && !defined(__MINGW32CE__) */

extern "C"
{
	#include "libavformat/avformat.h"
	#include "libavformat/ffm.h"
	#include "libavformat/rtpdec.h"
	#include "libavformat/rtpproto.h"
	#include "libavformat/rtsp.h"
	#include "libavformat/rtspcodes.h"
	#include "libavformat/avio_internal.h"
	#include "libavformat/internal.h"
	#include "libavformat/url.h"

	#include "libavutil/avassert.h"
	#include "libavutil/avstring.h"
	#include "libavutil/pixdesc.h"
	#include "libavutil/lfg.h"
	#include "libavutil/dict.h"
	#include "libavutil/intreadwrite.h"
	//#include "libavutil/mathematics.h"
	#include "libavutil/random_seed.h"
	#include "libavutil/parseutils.h"
	#include "libavutil/opt.h"
	#include "libavutil/time.h"
}


#include <stdarg.h>
#if HAVE_UNISTD_H
#include <unistd.h>
#endif
#include <fcntl.h>
#if HAVE_POLL_H
#include <poll.h>
#endif
#include <errno.h>
#include <time.h>
#include <signal.h>

//#include "cmdutils.h"

#define FFSERVER_MAX_STREAMS 20

/* each generated stream is described here */
enum FFServerStreamType {
    STREAM_TYPE_LIVE,
    STREAM_TYPE_STATUS,
    STREAM_TYPE_REDIRECT,
};

enum FFServerIPAddressAction {
    IP_ALLOW = 1,
    IP_DENY,
};

/* description of each stream of the ffserver.conf file */
typedef struct FFServerStream {
    FFServerStreamType stream_type;
    char filename[1024];          /* stream filename */
    struct FFServerStream *feed;  /* feed we are using (can be null if coming from file) */
    AVDictionary *in_opts;        /* input parameters */
    AVDictionary *metadata;       /* metadata to set on the stream */
    AVInputFormat *ifmt;          /* if non NULL, force input format */
    AVOutputFormat *fmt;
    int nb_streams;
    int prebuffer;                /* Number of milliseconds early to start */
    int64_t max_time;             /* Number of milliseconds to run */
    int send_on_key;
    AVStream *streams[FFSERVER_MAX_STREAMS];
    int feed_streams[FFSERVER_MAX_STREAMS]; /* index of streams in the feed */
    char feed_filename[1024];     /* file name of the feed storage, or
                                     input file name for a stream */
    int64_t pid;                    /* Of ffmpeg process */
    time_t pid_start;             /* Of ffmpeg process */
    char **child_argv;
    struct FFServerStream *next;
    unsigned bandwidth;           /* bandwidth, in kbits/s */
    /* RTSP options */
    char *rtsp_option;
    /* multicast specific */
    int is_multicast;
    struct in_addr multicast_ip;
    int multicast_port;           /* first port used for multicast */
    int multicast_ttl;
    int loop;                     /* if true, send the stream in loops (only meaningful if file) */
    char single_frame;            /* only single frame */

    /* feed specific */
    int feed_opened;              /* true if someone is writing to the feed */
    int is_feed;                  /* true if it is a feed */
    int readonly;                 /* True if writing is prohibited to the file */
    int truncate;                 /* True if feeder connection truncate the feed file */
    int conns_served;
    int64_t bytes_served;
    int64_t feed_max_size;        /* maximum storage size, zero means unlimited */
    int64_t feed_write_index;     /* current write position in feed (it wraps around) */
    int64_t feed_size;            /* current size of feed */
    struct FFServerStream *next_feed;
} FFServerStream;

typedef struct FFServerConfig {
	FFServerConfig() {
		memset(this, 0, sizeof(FFServerConfig));
	}
    char *filename;
    FFServerStream *first_stream; /* contains all streams, including feeds */
    unsigned int nb_max_http_connections;
    unsigned int nb_max_connections;
    uint64_t max_bandwidth;
    int debug;
    char logfilename[1024];
    sockaddr_in http_addr;
    sockaddr_in rtsp_addr;
    int errors;
    int warnings;
    int use_defaults;
    // Following variables MUST NOT be used outside configuration parsing code.
    enum AVCodecID guessed_audio_codec_id;
    enum AVCodecID guessed_video_codec_id;
    AVDictionary *video_opts;     /* AVOptions for video encoder */
    AVDictionary *audio_opts;     /* AVOptions for audio encoder */
    AVCodecContext *dummy_actx;   /* Used internally to test audio AVOptions. */
    AVCodecContext *dummy_vctx;   /* Used internally to test video AVOptions. */
    int no_audio;
    int no_video;
    int line_num;
    int stream_use_defaults;
} FFServerConfig;

#define PATH_LENGTH 1024

enum HTTPState {
    HTTPSTATE_WAIT_REQUEST,
    HTTPSTATE_SEND_HEADER,
    HTTPSTATE_SEND_DATA_HEADER,
    HTTPSTATE_SEND_DATA,          /* sending TCP or UDP data */
    HTTPSTATE_SEND_DATA_TRAILER,
    HTTPSTATE_RECEIVE_DATA,
    HTTPSTATE_WAIT_FEED,          /* wait for data from the feed */
    HTTPSTATE_READY,

    RTSPSTATE_WAIT_REQUEST,
    RTSPSTATE_SEND_REPLY,
    RTSPSTATE_SEND_PACKET,
};

static const char * const http_state[] = {
    "HTTP_WAIT_REQUEST",
    "HTTP_SEND_HEADER",

    "SEND_DATA_HEADER",
    "SEND_DATA",
    "SEND_DATA_TRAILER",
    "RECEIVE_DATA",
    "WAIT_FEED",
    "READY",

    "RTSP_WAIT_REQUEST",
    "RTSP_SEND_REPLY",
    "RTSP_SEND_PACKET",
};

#define IOBUFFER_INIT_SIZE 8192

/* timeouts are in ms */
#define HTTP_REQUEST_TIMEOUT (15 * 1000)
#define RTSP_REQUEST_TIMEOUT (3600 * 24 * 1000)

#define SYNC_TIMEOUT (10 * 1000)

typedef struct RTSPActionServerSetup {
    uint32_t ipaddr;
    char transport_option[512];
} RTSPActionServerSetup;

typedef struct {
    int64_t count1, count2;
    int64_t time1, time2;
} DataRateData;

/* context associated with one connection */
typedef struct HTTPContext {
    enum HTTPState state;
    int fd; /* socket file descriptor */
    struct sockaddr_in from_addr; /* origin */
    struct pollfd *poll_entry; /* used when polling */
    int64_t timeout;
    uint8_t *buffer_ptr, *buffer_end;
    int http_error;
    int post;
    int chunked_encoding;
    int chunk_size;               /* 0 if it needs to be read */
    struct HTTPContext *next;
    int got_key_frame; /* stream 0 => 1, stream 1 => 2, stream 2=> 4 */
    int64_t data_count;
    /* feed input */
    int feed_fd;
    /* input format handling */
    AVFormatContext *fmt_in;
    int64_t start_time;            /* In milliseconds - this wraps fairly often */
    int64_t first_pts;            /* initial pts value */
    int64_t cur_pts;             /* current pts value from the stream in us */
    int64_t cur_frame_duration;  /* duration of the current frame in us */
    int cur_frame_bytes;       /* output frame size, needed to compute
                                  the time at which we send each
                                  packet */
    int pts_stream_index;        /* stream we choose as clock reference */
    int64_t cur_clock;           /* current clock reference value in us */
    /* output format handling */
    struct FFServerStream *stream;
    /* -1 is invalid stream */
    int feed_streams[FFSERVER_MAX_STREAMS]; /* index of streams in the feed */
    int switch_feed_streams[FFSERVER_MAX_STREAMS]; /* index of streams in the feed */
    int switch_pending;
    AVFormatContext fmt_ctx; /* instance of FFServerStream for one user */
    int last_packet_sent; /* true if last data packet was sent */
    int suppress_log;
    DataRateData datarate;
    int wmp_client_id;
    char protocol[16];
    char method[16];
    char url[128];
    int buffer_size;
    uint8_t *buffer;
    int is_packetized; /* if true, the stream is packetized */
    int packet_stream_index; /* current stream for output in state machine */

    /* RTSP state specific */
    uint8_t *pb_buffer; /* XXX: use that in all the code */
    AVIOContext *pb;
    int seq; /* RTSP sequence number */

    /* RTP state specific */
    enum RTSPLowerTransport rtp_protocol;
    char session_id[32]; /* session id */
    AVFormatContext *rtp_ctx[FFSERVER_MAX_STREAMS];

    /* RTP/UDP specific */
    URLContext *rtp_handles[FFSERVER_MAX_STREAMS];

    /* RTP/TCP specific */
    struct HTTPContext *rtsp_c;
    uint8_t *packet_buffer, *packet_buffer_ptr, *packet_buffer_end;
} HTTPContext;

typedef struct FeedData {
    long long data_count;
    float avg_frame_size;   /* frame size averaged over last frames with exponential mean */
} FeedData;

#define FLT_MAX 3.40282346638528859812e+38F

#define FLT_MIN 1.17549435082228750797e-38F

#define DBL_MAX ((double)1.79769313486231570815e+308L)

#define DBL_MIN ((double)2.22507385850720138309e-308L)

#define MAX_CHILD_ARGS 64

#define HAVE_GETADDRINFO 1



/*FILE *get_preset_file(char *filename, size_t filename_size, const char *preset_name, int is_path, const char *codec_name)
{
	FILE *f = NULL;
	int i;
	const char *base[3] = { getenv("FFMPEG_DATADIR"),
		getenv("HOME"),
		FFMPEG_DATADIR, };

	if (is_path) {
		av_strlcpy(filename, preset_name, filename_size);
		f = fopen(filename, "r");
	}
	else {
#ifdef _WIN32
		char datadir[MAX_PATH], *ls;
		base[2] = NULL;

		if (GetModuleFileNameA(GetModuleHandleA(NULL), datadir, sizeof(datadir)-1))
		{
			for (ls = datadir; ls < datadir + strlen(datadir); ls++)
			if (*ls == '\\') *ls = '/';

			if (ls = strrchr(datadir, '/'))
			{
				*ls = 0;
				strncat(datadir, "/ffpresets", sizeof(datadir)-1 - strlen(datadir));
				base[2] = datadir;
			}
		}
#endif
		for (i = 0; i < 3 && !f; i++) {
			if (!base[i])
				continue;
			snprintf(filename, filename_size, "%s%s/%s.ffpreset", base[i],
				i != 1 ? "" : "/.ffmpeg", preset_name);
			f = fopen(filename, "r");
			if (!f && codec_name) {
				snprintf(filename, filename_size,
					"%s%s/%s-%s.ffpreset",
					base[i], i != 1 ? "" : "/.ffmpeg", codec_name,
					preset_name);
				f = fopen(filename, "r");
			}
		}
	}

	return f;
} */

static int64_t ffm_read_write_index(int fd)
{
    uint8_t buf[8];

    if (lseek(fd, 8, SEEK_SET) < 0)
        return AVERROR(EIO);
    if (read(fd, buf, 8) != 8)
        return AVERROR(EIO);
    return AV_RB64(buf);
}

static int ffm_write_write_index(int fd, int64_t pos)
{
    uint8_t buf[8];
    int i;

    for(i=0;i<8;i++)
        buf[i] = (pos >> (56 - i * 8)) & 0xff;
    if (lseek(fd, 8, SEEK_SET) < 0)
        goto bail_eio;
    if (write(fd, buf, 8) != 8)
        goto bail_eio;

    return 8;

bail_eio:
    return AVERROR(EIO);
}

static void ffm_set_write_index(AVFormatContext *s, int64_t pos, int64_t file_size)
{
    av_opt_set_int(s, "server_attached", 1, AV_OPT_SEARCH_CHILDREN);
    av_opt_set_int(s, "ffm_write_index", pos, AV_OPT_SEARCH_CHILDREN);
    av_opt_set_int(s, "ffm_file_size", file_size, AV_OPT_SEARCH_CHILDREN);
}

static char *ctime1(char *buf2, size_t buf_size)
{
    time_t ti;
    char *p;

    ti = time(NULL);
    p = ctime(&ti);
    if (!p || !*p) {
        *buf2 = '\0';
        return buf2;
    }
    av_strlcpy(buf2, p, buf_size);
    p = buf2 + strlen(buf2) - 1;
    if (*p == '\n')
        *p = '\0';
    return buf2;
}

static int extract_rates(char *rates, int ratelen, const char *request)
{
    const char *p;

    for (p = request; *p && *p != '\r' && *p != '\n'; ) {
        if (av_strncasecmp(p, "Pragma:", 7) == 0) {
            const char *q = p + 7;

            while (*q && *q != '\n' && av_isspace(*q))
                q++;

            if (av_strncasecmp(q, "stream-switch-entry=", 20) == 0) {
                int stream_no;
                int rate_no;

                q += 20;

                memset(rates, 0xff, ratelen);

                while (1) {
                    while (*q && *q != '\n' && *q != ':')
                        q++;

                    if (sscanf(q, ":%d:%d", &stream_no, &rate_no) != 2)
                        break;

                    stream_no--;
                    if (stream_no < ratelen && stream_no >= 0)
                        rates[stream_no] = rate_no;

                    while (*q && *q != '\n' && !av_isspace(*q))
                        q++;
                }

                return 1;
            }
        }
        p = strchr(p, '\n');
        if (!p)
            break;

        p++;
    }

    return 0;
}

static void get_word(char *buf, int buf_size, const char **pp)
{
    const char *p;
    char *q;

    p = *pp;
    p += strspn(p, SPACE_CHARS);
    q = buf;
    while (!av_isspace(*p) && *p != '\0') {
        if ((q - buf) < buf_size - 1)
            *q++ = *p;
        p++;
    }
    if (buf_size > 0)
        *q = '\0';
    *pp = p;
}

class CFFStreamServer
{
public:
	int no_launch;
	int need_to_start_children; 
	
	/* maximum number of simultaneous HTTP connections */
	unsigned int nb_connections;
	uint64_t current_bandwidth;
	
	/* Making this global saves on passing it around everywhere */
	int64_t cur_time;

	AVLFG random_state;

	HTTPContext *first_http_ctx;

	FFServerConfig config;
	
	bool fStop;
public:

	CFFStreamServer()
	{
		first_http_ctx = NULL;
		cur_time = 0;
		current_bandwidth = 0;
		nb_connections = 0;
		fStop = true;
	}

	int ffserver_save_avoption(const char *opt, const char *arg, int type, FFServerConfig *config);
	int ffserver_save_avoption_int(const char *opt, int64_t arg,	int type, FFServerConfig *config);
	void ffserver_get_arg(char *buf, int buf_size, const char *pp);
	int	ffserver_set_codec(AVCodecContext *ctx, const char *codec_name,	FFServerConfig *config);
	int ffserver_opt_preset(const char *arg, int type, FFServerConfig *config);
	AVOutputFormat* ffserver_guess_format(const char *short_name, const char *filename, const char *mime_type);
	int ffserver_set_int_param(int *dest, const char *value, int factor,	int min, int max, FFServerConfig *config, const char *error_msg, ...);
	int ffserver_set_float_param(float *dest, const char *value, float factor, float min, float max,	FFServerConfig *config,	const char *error_msg, ...);
	int ffserver_parse_config_global(FFServerConfig *config, const char *cmd, const char *p);
	int ffserver_parse_config_stream(FFServerConfig *config, const char *cmd, const char *p, FFServerStream **pstream);
	int ffserver_parse_config_redirect(FFServerConfig *config, const char *cmd, const char **p, FFServerStream **predirect);
	int ffserver_parse_ffconfig(const char *filename, char* szRtspPort, char* szRtspName, FFServerConfig *config);
	void ffserver_free_child_args(void *argsp);
	int ff_neterrno(void);
	int ff_getaddrinfo(const char *node, const char *service, const struct addrinfo *hints, struct addrinfo **res);
	void ff_freeaddrinfo(struct addrinfo *res);

	void add_codec(FFServerStream *stream, AVCodecContext *av, FFServerConfig *config);

	void new_connection(int server_fd, int is_rtsp);
	void close_connection(HTTPContext *c);

	/* HTTP handling */
	int handle_connection(HTTPContext *c);
	void print_stream_params(AVIOContext *pb, FFServerStream *stream);
	int open_input_stream(HTTPContext *c, const char *info);

	/* should convert the format at the same time */
	/* send data starting at c->buffer_ptr to the output connection
	* (either UDP or TCP)
	*/
	int http_send_data(HTTPContext *c);

/*	int http_receive_data(HTTPContext *c);

	int http_start_receive_data(HTTPContext *c);*/

	/* RTSP handling */
	int rtsp_parse_request(HTTPContext *c);
	void rtsp_cmd_describe(HTTPContext *c, const char *url);
	void rtsp_cmd_options(HTTPContext *c, const char *url);
	void rtsp_cmd_setup(HTTPContext *c, const char *url, RTSPMessageHeader *h);
	void rtsp_cmd_play(HTTPContext *c, const char *url, RTSPMessageHeader *h);
	void rtsp_cmd_interrupt(HTTPContext *c, const char *url, RTSPMessageHeader *h, int pause_only);
	void rtsp_reply_header(HTTPContext *c, enum RTSPStatusCode error_number);
	void rtsp_reply_error(HTTPContext *c, enum RTSPStatusCode error_number);

	/* SDP handling */
	int prepare_sdp_description(FFServerStream *stream, uint8_t **pbuffer,  struct in_addr my_ip);
	
	/* RTP handling */
	HTTPContext *rtp_new_connection(struct sockaddr_in *from_addr, FFServerStream *stream, const char *session_id, enum RTSPLowerTransport rtp_protocol);
	int rtp_new_av_stream(HTTPContext *c, int stream_index, struct sockaddr_in *dest_addr, HTTPContext *rtsp_c);
	
	/* utils */
	
	/* open a listening socket */
	int socket_open_listen(struct sockaddr_in *my_addr);

	/* start all multicast streams */
	void start_multicast(void);

	/* main loop of the HTTP server */
	int http_server(void);

	/* start waiting for a new HTTP/RTSP request */
	void start_wait_request(HTTPContext *c, int is_rtsp);

	void http_send_too_busy_reply(int fd);

	int find_stream_in_feed(FFServerStream *feed, AVCodecContext *codec, int bit_rate);

	int modify_current_stream(HTTPContext *c, char *rates);

	void fmt_bytecount(AVIOContext *pb, int64_t count);

	/* return the server clock (in us) */
	int64_t get_server_clock(HTTPContext *c);

	/* return the estimated time (in us) at which the current packet must be sent */
	int64_t get_packet_send_clock(HTTPContext *c);

	int http_prepare_data(HTTPContext *c);

	HTTPContext * find_rtp_session(const char *session_id);

	RTSPTransportField * find_transport(RTSPMessageHeader *h, enum RTSPLowerTransport lower_transport);

	/**
	* find an RTP connection by using the session ID. Check consistency
	* with filename
	*/
	HTTPContext * find_rtp_session_with_url(const char *url, const char *session_id);

	
	/********************************************************************/
	/* ffserver initialization */
	
	/* FIXME: This code should use avformat_new_stream() */
	AVStream * add_av_stream1(FFServerStream *stream, AVCodecContext *codec, int copy);

	/* return the stream number in the feed */
	int add_av_stream(FFServerStream *feed, AVStream *st);

	void remove_stream(FFServerStream *stream);

	/* specific MPEG4 handling : we extract the raw parameters */
	void extract_mpeg4_header(AVFormatContext *infile);

	/* compute the needed AVStream for each file */
	void build_file_streams(void);

	/* compute the bandwidth used by each stream */
	void compute_bandwidth(void);

	void update_datarate(DataRateData *drd, int64_t count);

	/**
	* compute the real filename of a file by matching it without its
	* extensions to all the stream's filenames
	*/
	void compute_real_filename(char *filename, int max_size);

	int compute_datarate(DataRateData *drd, int64_t count);

	int resolve_host(struct in_addr *sin_addr, const char *hostname);

	int Start(char *szInUrl, char* szRtspPort, char* szRtspName);
	void Stop();
};


