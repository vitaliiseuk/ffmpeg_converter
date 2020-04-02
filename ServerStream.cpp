#pragma comment(lib, "Ws2_32.lib")

#include "cmdutils.h"

int CFFStreamServer::resolve_host(struct in_addr *sin_addr, const char *hostname)
{

	if (!ff_inet_aton(hostname, sin_addr)) {
#if HAVE_GETADDRINFO
		struct addrinfo *ai, *cur;
		struct addrinfo hints = { 0 };
		hints.ai_family = AF_INET;
		if (getaddrinfo(hostname, NULL, &hints, &ai))
			return -1;

		for (cur = ai; cur; cur = cur->ai_next) {
			if (cur->ai_family == AF_INET) {
				*sin_addr = ((struct sockaddr_in *)cur->ai_addr)->sin_addr;
				freeaddrinfo(ai);
				return 0;
			}
		}
		freeaddrinfo(ai);
		return -1;
#else
		struct hostent *hp;
		hp = gethostbyname(hostname);
		if (!hp)
			return -1;
		memcpy(sin_addr, hp->h_addr_list[0], sizeof(struct in_addr));
#endif
	}
	return 0;
}

void CFFStreamServer::ffserver_get_arg(char *buf, int buf_size, const char *pp)
{
	const char *p;
	char *q;
	int quote = 0;

	p = pp;
	q = buf;

	while (av_isspace(*p)) p++;

	if (*p == '\"' || *p == '\'')
		quote = *p++;

	while (*p != '\0') {
		if (quote && *p == quote || !quote && av_isspace(*p))
			break;
		if ((q - buf) < buf_size - 1)
			*q++ = *p;
		p++;
	}

	*q = '\0';
	if (quote && *p == quote)
		p++;
	pp = p;
}

int CFFStreamServer::ffserver_set_codec(AVCodecContext *ctx, const char *codec_name,	FFServerConfig *config)
{
	int ret;
	AVCodec *codec = avcodec_find_encoder_by_name(codec_name);
	
	if (!codec || codec->type != ctx->codec_type) 
	{
		report_config_error(config->filename, config->line_num, AV_LOG_ERROR,	&config->errors,	"Invalid codec name: '%s'\n", codec_name); 
		return 0;
	}
	
	return 0;
}

int CFFStreamServer::ffserver_opt_preset(const char *arg, int type, FFServerConfig *config)
{
	FILE *f = NULL;
	char filename[1000], tmp[1000], tmp2[1000], line[1000];
	int ret = -1;
	AVCodecContext *avctx;
	const AVCodec *codec;

	codec = avcodec_find_encoder(avctx->codec_id);

	while (!feof(f))
	{
		int e = fscanf(f, "%999[^\n]\n", line) - 1;
		
		if (line[0] == '#' && !e)
			continue;
		
		e |= sscanf(line, "%999[^=]=%999[^\n]\n", tmp, tmp2) - 2;
		
		if (e)
		{
			av_log(NULL, AV_LOG_ERROR, "%s: Invalid syntax: '%s'\n", filename,	line);
			TRACE("%s: Invalid syntax: '%s'\n", filename, line);
			ret = AVERROR(EINVAL);
			break;
		}
		if (!strcmp(tmp, "acodec") && avctx->codec_type == AVMEDIA_TYPE_AUDIO ||
			!strcmp(tmp, "vcodec") && avctx->codec_type == AVMEDIA_TYPE_VIDEO)
		{
			if (ffserver_set_codec(avctx, tmp2, config) < 0)
				break;
		}
		else if (!strcmp(tmp, "scodec")) 
		{
			av_log(NULL, AV_LOG_ERROR, "Subtitles preset found.\n");
			TRACE("Subtitles preset found.\n");
			ret = AVERROR(EINVAL);
			break;
		}
		else if (ffserver_save_avoption(tmp, tmp2, type, config) < 0)
			break;
	}

	fclose(f);

	return ret;
}

int CFFStreamServer::ffserver_set_int_param(int *dest, const char *value, int factor,	int min, int max, FFServerConfig *config, const char *error_msg, ...)
{
	int tmp;
	char *tailp;
	
	if (!value || !value[0])
		goto error;
	
	errno = 0;
	
	tmp = strtol(value, &tailp, 0);
	
	if (tmp < min || tmp > max)
		goto error;
	
	if (factor) 
	{
		if (tmp == INT_MIN || FFABS(tmp) > INT_MAX / FFABS(factor))
			goto error;
		tmp *= factor;
	}
	if (tailp[0] || errno)
		goto error;
	if (dest)
		*dest = tmp;
	return 0;
}

int CFFStreamServer::ffserver_set_float_param(float *dest, const char *value, float factor, float min, float max,	FFServerConfig *config,	const char *error_msg, ...)
{
	double tmp;

	char *tailp;

	if (!value || !value[0])
		goto error;
	
	errno = 0;
	
	tmp = strtod(value, &tailp);
	
	if (tmp < min || tmp > max)
		goto error;
	
	if (factor)
		tmp *= factor;
	
	if (tailp[0] || errno)
		goto error;
	
	if (dest)
		*dest = tmp;
	
	return 0;
}

int CFFStreamServer::ffserver_save_avoption_int(const char *opt, int64_t arg,	int type, FFServerConfig *config)
{
	char buf[22];
	snprintf(buf, sizeof(buf), "%"PRId64, arg);
	return ffserver_save_avoption(opt, buf, type, config);
}

int CFFStreamServer::ffserver_parse_config_stream(FFServerConfig *config, const char *cmd, const char *p, FFServerStream **pstream)
{
	char arg[1024], arg2[1024];
	FFServerStream *stream;
	int val;
	int ret = -1;

	av_assert0(pstream);
	stream = *pstream;

	if (!av_strcasecmp(cmd, "Stream")) 
	{
		char *q;
		FFServerStream *s;
		stream = (FFServerStream*)av_mallocz(sizeof(FFServerStream));
		if (!stream)
			return AVERROR(ENOMEM);
		config->dummy_actx = avcodec_alloc_context3(NULL);
		config->dummy_vctx = avcodec_alloc_context3(NULL);
		if (!config->dummy_vctx || !config->dummy_actx) 
		{
			av_free(stream);
			avcodec_free_context(&config->dummy_vctx);
			avcodec_free_context(&config->dummy_actx);
			return AVERROR(ENOMEM);
		}
		config->dummy_actx->codec_type = AVMEDIA_TYPE_AUDIO;
		config->dummy_vctx->codec_type = AVMEDIA_TYPE_VIDEO;
		ffserver_get_arg(stream->filename, sizeof(stream->filename), p);
		q = strrchr(stream->filename, '>');
		if (q)
			*q = '\0';

		for (s = config->first_stream; s; s = s->next) 
		{
			if (!strcmp(stream->filename, s->filename))
				ERROR("Stream '%s' already registered\n", s->filename);
		}

		stream->fmt = ffserver_guess_format(NULL, stream->filename, NULL);
		if (stream->fmt) {
			config->guessed_audio_codec_id = stream->fmt->audio_codec;
			config->guessed_video_codec_id = stream->fmt->video_codec;
		}
		else 
		{
			config->guessed_audio_codec_id = AV_CODEC_ID_NONE;
			config->guessed_video_codec_id = AV_CODEC_ID_NONE;
		}
		config->stream_use_defaults = config->use_defaults;
		*pstream = stream;
		return 0;
	}
	av_assert0(stream);

	if (!av_strcasecmp(cmd, "Format")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		if (!strcmp(arg, "status")) {
			stream->stream_type = STREAM_TYPE_STATUS;
			stream->fmt = NULL;
		}
		else {
			stream->stream_type = STREAM_TYPE_LIVE;
			/* JPEG cannot be used here, so use single frame MJPEG */
			if (!strcmp(arg, "jpeg")) 
			{
				strcpy(arg, "singlejpeg");
				stream->single_frame = 1;
			}
			stream->fmt = ffserver_guess_format(arg, NULL, NULL);
			if (!stream->fmt)
				ERROR("Unknown Format: '%s'\n", arg);
		}
		if (stream->fmt) {
			config->guessed_audio_codec_id = stream->fmt->audio_codec;
			config->guessed_video_codec_id = stream->fmt->video_codec;
		}
	}
	else if (!av_strcasecmp(cmd, "InputFormat")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		stream->ifmt = av_find_input_format(arg);
		if (!stream->ifmt)
			ERROR("Unknown input format: '%s'\n", arg);
	}
	else if (!av_strcasecmp(cmd, "FaviconURL")) {
		if (stream->stream_type == STREAM_TYPE_STATUS)
			ffserver_get_arg(stream->feed_filename,
			sizeof(stream->feed_filename), p);
		else
			ERROR("FaviconURL only permitted for status streams\n");
	}
	else if (!av_strcasecmp(cmd, "Author") ||
		!av_strcasecmp(cmd, "Comment") ||
		!av_strcasecmp(cmd, "Copyright") ||
		!av_strcasecmp(cmd, "Title")) {
		char key[32];
		int i;
		ffserver_get_arg(arg, sizeof(arg), p);
		for (i = 0; i < strlen(cmd); i++)
			key[i] = av_tolower(cmd[i]);
		key[i] = 0;
//		WARNING("Deprecated '%s' option in configuration file. Use " "'Metadata %s VALUE' instead.\n", cmd, key);

		if (av_dict_set(&stream->metadata, key, arg, 0) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "Metadata")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_get_arg(arg2, sizeof(arg2), p);
		if (av_dict_set(&stream->metadata, arg, arg2, 0) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "Preroll")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		stream->prebuffer = atof(arg) * 1000;
	}
	else if (!av_strcasecmp(cmd, "StartSendOnKey")) {
		stream->send_on_key = 1;
	}
	else if (!av_strcasecmp(cmd, "AudioCodec")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_codec(config->dummy_actx, arg, config);
	}
	else if (!av_strcasecmp(cmd, "VideoCodec")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_codec(config->dummy_vctx, arg, config);
	}
	else if (!av_strcasecmp(cmd, "MaxTime")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		stream->max_time = atof(arg) * 1000;
	}
	else if (!av_strcasecmp(cmd, "AudioBitRate")) {
		float f;
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_float_param(&f, arg, 1000, -FLT_MAX, FLT_MAX, config,
			"Invalid %s: '%s'\n", cmd, arg);
		if (ffserver_save_avoption_int("b", (int64_t)lrintf(f),
			AV_OPT_FLAG_AUDIO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "AudioChannels")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("ac", arg, AV_OPT_FLAG_AUDIO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "AudioSampleRate")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("ar", arg, AV_OPT_FLAG_AUDIO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoBitRateRange")) {
		int minrate, maxrate;
		char *dash;
		ffserver_get_arg(arg, sizeof(arg), p);
		dash = strchr(arg, '-');
		if (dash) {
			*dash = '\0';
			dash++;
			if (ffserver_set_int_param(&minrate, arg, 1000, 0, INT_MAX, config, "Invalid %s: '%s'", cmd, arg) >= 0 &&
				ffserver_set_int_param(&maxrate, dash, 1000, 0, INT_MAX, config, "Invalid %s: '%s'", cmd, arg) >= 0) {
				if (ffserver_save_avoption_int("minrate", minrate, AV_OPT_FLAG_VIDEO_PARAM, config) < 0 ||
					ffserver_save_avoption_int("maxrate", maxrate, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
					goto nomem;
			}
		}
		else
			ERROR("Incorrect format for VideoBitRateRange. It should be "
			"<min>-<max>: '%s'.\n", arg);
	}
	else if (!av_strcasecmp(cmd, "Debug")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("debug", arg, AV_OPT_FLAG_AUDIO_PARAM, config) < 0 ||
			ffserver_save_avoption("debug", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "Strict")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("strict", arg, AV_OPT_FLAG_AUDIO_PARAM, config) < 0 ||
			ffserver_save_avoption("strict", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoBufferSize")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 8 * 1024, 0, INT_MAX, config,
			"Invalid %s: '%s'", cmd, arg);
		if (ffserver_save_avoption_int("bufsize", val, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoBitRateTolerance")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 1000, INT_MIN, INT_MAX, config,
			"Invalid %s: '%s'", cmd, arg);
		if (ffserver_save_avoption_int("bt", val, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoBitRate")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 1000, INT_MIN, INT_MAX, config,
			"Invalid %s: '%s'", cmd, arg);
		if (ffserver_save_avoption_int("b", val, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoSize")) {
		int ret, w, h;
		ffserver_get_arg(arg, sizeof(arg), p);
		ret = av_parse_video_size(&w, &h, arg);
		if (ret < 0)
			ERROR("Invalid video size '%s'\n", arg);
		else {
/*			if (w % 2 || h % 2)
				WARNING("Image size is not a multiple of 2\n"); */
			if (ffserver_save_avoption("video_size", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
				goto nomem;
		}
	}
	else if (!av_strcasecmp(cmd, "AVOptionVideo") ||
		!av_strcasecmp(cmd, "AVOptionAudio")) {
		int ret;
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_get_arg(arg2, sizeof(arg2), p);
		if (!av_strcasecmp(cmd, "AVOptionVideo"))
			ret = ffserver_save_avoption(arg, arg2, AV_OPT_FLAG_VIDEO_PARAM,
			config);
		else
			ret = ffserver_save_avoption(arg, arg2, AV_OPT_FLAG_AUDIO_PARAM,
			config);
		if (ret < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "AVPresetVideo") ||
		!av_strcasecmp(cmd, "AVPresetAudio")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (!av_strcasecmp(cmd, "AVPresetVideo"))
			ffserver_opt_preset(arg, AV_OPT_FLAG_VIDEO_PARAM, config);
		else
			ffserver_opt_preset(arg, AV_OPT_FLAG_AUDIO_PARAM, config);
	}
	else if (!av_strcasecmp(cmd, "VideoTag")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (strlen(arg) == 4 &&
			ffserver_save_avoption_int("codec_tag",
			MKTAG(arg[0], arg[1], arg[2], arg[3]),
			AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "BitExact")) {
		if (ffserver_save_avoption("flags", "+bitexact", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "DctFastint")) {
		if (ffserver_save_avoption("dct", "fastint", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "IdctSimple")) {
		if (ffserver_save_avoption("idct", "simple", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "Qscale")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, INT_MIN, INT_MAX, config,
			"Invalid Qscale: '%s'\n", arg);
		if (ffserver_save_avoption("flags", "+qscale", AV_OPT_FLAG_VIDEO_PARAM, config) < 0 ||
			ffserver_save_avoption_int("global_quality", FF_QP2LAMBDA * val,
			AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
}

int CFFStreamServer::ffserver_parse_ffconfig(const char *filename, char* szRtspPort, char* szRtspName, FFServerConfig *config)
{
	FILE *f;
	char line[1024];
	char cmd[64];
	const char *p;
	FFServerStream **last_stream = NULL, *stream = NULL ;
	
	int ret = -1;

	av_assert0(config);

	ffserver_parse_config_global(config, "RTSPPort", szRtspPort);
	ffserver_parse_config_global(config, "MaxClients", "1000");
	ffserver_parse_config_global(config, "MaxBandwidth", "100000");

	ret = ffserver_parse_config_stream(config, "Stream", szRtspName, &stream);
	
	if (ret < 0)
		return ret;

	last_stream = &config->first_stream;

	{
	/* add in stream list */
		*last_stream = stream;
		last_stream = &stream->next;
	}

	ffserver_parse_config_stream(config, "Format", "rtp", &stream);
	ffserver_parse_config_stream(config, "File", filename, &stream);
	ffserver_parse_config_stream(config, "/Stream", "\n", &stream);

	if (ret < 0)
		return ret;

	if (config->errors)
		return AVERROR(EINVAL);
	else
		return 0;
}

int CFFStreamServer::ff_neterrno(void)
{
	int err = WSAGetLastError();
	switch (err) {
	case WSAEWOULDBLOCK:
		return AVERROR(EAGAIN);
	case WSAEINTR:
		return AVERROR(EINTR);
	case WSAEPROTONOSUPPORT:
		return AVERROR(EPROTONOSUPPORT);
	case WSAETIMEDOUT:
		return AVERROR(ETIMEDOUT);
	case WSAECONNREFUSED:
		return AVERROR(ECONNREFUSED);
	case WSAEINPROGRESS:
		return AVERROR(EINPROGRESS);
	}
	return -err;
}

int CFFStreamServer::ff_getaddrinfo(const char *node, const char *service,	const struct addrinfo *hints, struct addrinfo **res)
{
	struct hostent *h = NULL;
	struct addrinfo *ai;
	struct sockaddr_in *sin;

#if HAVE_WINSOCK2_H
	int (WSAAPI *win_getaddrinfo)(const char *node, const char *service,
		const struct addrinfo *hints,
	struct addrinfo **res);
	HMODULE ws2mod = GetModuleHandle("ws2_32.dll");
	win_getaddrinfo = (int(__stdcall *)(const char *, const char *, const addrinfo *, addrinfo **))GetProcAddress(ws2mod, "getaddrinfo");
	if (win_getaddrinfo)
		return win_getaddrinfo(node, service, hints, res);
#endif /* HAVE_WINSOCK2_H */

	*res = NULL;
	sin = (sockaddr_in*)av_mallocz(sizeof(struct sockaddr_in));
	if (!sin)
		return EAI_FAIL;
	sin->sin_family = AF_INET;

	if (node) {
		if (!ff_inet_aton(node, &sin->sin_addr)) {
			if (hints && (hints->ai_flags & AI_NUMERICHOST)) {
				av_free(sin);
				return EAI_FAIL;
			}
			h = gethostbyname(node);
			if (!h) {
				av_free(sin);
				return EAI_FAIL;
			}
			memcpy(&sin->sin_addr, h->h_addr_list[0], sizeof(struct in_addr));
		}
	}
	else {
		if (hints && (hints->ai_flags & AI_PASSIVE))
			sin->sin_addr.s_addr = INADDR_ANY;
		else
			sin->sin_addr.s_addr = INADDR_LOOPBACK;
	}

	return 0;
}


/* open a listening socket */
int CFFStreamServer::socket_open_listen(struct sockaddr_in *my_addr)
{
    int server_fd, tmp;	
	server_fd = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	//server_fd = socket(AF_INET, SOCK_STREAM, 0);
    if (server_fd < 0) 
	{
        perror ("socket");
        return -1;
    }

    tmp = 1;
	if (setsockopt(server_fd, SOL_SOCKET, SO_REUSEADDR, &tmp, sizeof(tmp)))
	{
		av_log(NULL, AV_LOG_WARNING, "setsockopt SO_REUSEADDR failed\n");
		TRACE("setsockopt SO_REUSEADDR failed\n");
	}

    my_addr->sin_family = AF_INET;
    if (bind (server_fd, (struct sockaddr *) my_addr, sizeof (*my_addr)) < 0) {
        char bindmsg[50];
        snprintf(bindmsg, sizeof(bindmsg), "%d-bind(port %d), %d\n",	server_fd, ntohs(my_addr->sin_port), WSAGetLastError());
        perror (bindmsg);
		TRACE(bindmsg);
        goto fail;
    }

    if (listen (server_fd, 5) < 0) {
        perror ("listen");
        goto fail;
    }

	if (ff_socket_nonblock(server_fd, 1) < 0)
	{
		av_log(NULL, AV_LOG_WARNING, "ff_socket_nonblock failed\n");
		TRACE("ff_socket_nonblock failed\n");
	}

    return server_fd;

fail:
    closesocket(server_fd);
    return -1;
}

/* start waiting for a new HTTP/RTSP request */
void CFFStreamServer::start_wait_request(HTTPContext *c, int is_rtsp)
{
    c->buffer_ptr = c->buffer;
    c->buffer_end = c->buffer + c->buffer_size - 1; /* leave room for '\0' */

    c->state = is_rtsp ? RTSPSTATE_WAIT_REQUEST : HTTPSTATE_WAIT_REQUEST;
    c->timeout = cur_time +
                 (is_rtsp ? RTSP_REQUEST_TIMEOUT : HTTP_REQUEST_TIMEOUT);
}

void CFFStreamServer::close_connection(HTTPContext *c)
{
    HTTPContext **cp, *c1;
    int i, nb_streams;
    AVFormatContext *ctx;
    AVStream *st;

    /* remove connection from list */
    cp = &first_http_ctx;
    while (*cp) {
        c1 = *cp;
        if (c1 == c)
            *cp = c->next;
        else
            cp = &c1->next;
    }

    /* remove references, if any (XXX: do it faster) */
    for(c1 = first_http_ctx; c1; c1 = c1->next) {
        if (c1->rtsp_c == c)
            c1->rtsp_c = NULL;
    }

    /* remove connection associated resources */
    if (c->fd >= 0)
        closesocket(c->fd);
    if (c->fmt_in) 
	{
        /* close each frame parser */
        for(i=0;i<c->fmt_in->nb_streams;i++) 
		{
            st = c->fmt_in->streams[i];
            if (st->codec->codec)
                avcodec_close(st->codec);
        }
        avformat_close_input(&c->fmt_in);
    }

    /* free RTP output streams if any */
    nb_streams = 0;
    if (c->stream)
        nb_streams = c->stream->nb_streams;

    for(i=0;i<nb_streams;i++) 
	{
        ctx = c->rtp_ctx[i];
        if (ctx) 
		{
            av_write_trailer(ctx);
            av_dict_free(&ctx->metadata);
            av_freep(&ctx->streams[0]);
            av_freep(&ctx);
        }
        ffurl_close(c->rtp_handles[i]);
    }

    ctx = &c->fmt_ctx;

    if (!c->last_packet_sent && c->state == HTTPSTATE_SEND_DATA_TRAILER) 
	{
        /* prepare header */
        if (ctx->oformat && avio_open_dyn_buf(&ctx->pb) >= 0) 
		{
            av_write_trailer(ctx);
            av_freep(&c->pb_buffer);
            avio_close_dyn_buf(ctx->pb, &c->pb_buffer);
        }
    }

    for(i=0; i<ctx->nb_streams; i++)
        av_freep(&ctx->streams[i]);
    av_freep(&ctx->streams);
    av_freep(&ctx->priv_data);

    if (c->stream && !c->post && c->stream->stream_type == STREAM_TYPE_LIVE)
        current_bandwidth -= c->stream->bandwidth;

    /* signal that there is no feed if we are the feeder socket */
    if (c->state == HTTPSTATE_RECEIVE_DATA && c->stream) {
        c->stream->feed_opened = 0;
        close(c->feed_fd);
    }

    av_freep(&c->pb_buffer);
    av_freep(&c->packet_buffer);
    av_freep(&c->buffer);
    av_free(c);
    nb_connections--;
}

int CFFStreamServer::handle_connection(HTTPContext *c)
{
    int len, ret;
    uint8_t *ptr;

    switch(c->state) {
    case RTSPSTATE_WAIT_REQUEST:
        /* timeout ? */
        if ((c->timeout - cur_time) < 0)
            return -1;
        if (c->poll_entry->revents & (POLLERR | POLLHUP))
            return -1;

        /* no need to read if no events */
        if (!(c->poll_entry->revents & POLLIN))
            return 0;
        /* read the data */
    read_loop:
        if (!(len = recv(c->fd, (char*)(c->buffer_ptr), 1, 0)))
            return -1;

        if (len < 0) {
            if (ff_neterrno() != AVERROR(EAGAIN) &&
                ff_neterrno() != AVERROR(EINTR))
                return -1;
            break;
        }
        /* search for end of request. */
        c->buffer_ptr += len;
        ptr = c->buffer_ptr;
        if ((ptr >= c->buffer + 2 && !memcmp(ptr-2, "\n\n", 2)) ||
            (ptr >= c->buffer + 4 && !memcmp(ptr-4, "\r\n\r\n", 4))) {

			/* request found : parse it and reply */
			ret = rtsp_parse_request(c);

            if (ret < 0)
                return -1;
        } else if (ptr >= c->buffer_end) {
            /* request too long: cannot do anything */
            return -1;
        } else goto read_loop;

        break;

    case HTTPSTATE_SEND_HEADER:
        if (c->poll_entry->revents & (POLLERR | POLLHUP))
            return -1;

        /* no need to write if no events */
        if (!(c->poll_entry->revents & POLLOUT))
            return 0;
        len = send(c->fd, (char*)(c->buffer_ptr), c->buffer_end - c->buffer_ptr, 0);
        if (len < 0) {
            if (ff_neterrno() != AVERROR(EAGAIN) &&
                ff_neterrno() != AVERROR(EINTR)) {
                goto close_connection;
            }
            break;
        }
        c->buffer_ptr += len;
        if (c->stream)
            c->stream->bytes_served += len;
        c->data_count += len;
        if (c->buffer_ptr >= c->buffer_end) {
            av_freep(&c->pb_buffer);
            /* if error, exit */
            if (c->http_error)
                return -1;
            /* all the buffer was sent : synchronize to the incoming
             * stream */
            c->state = HTTPSTATE_SEND_DATA_HEADER;
            c->buffer_ptr = c->buffer_end = c->buffer;
        }
        break;

    case HTTPSTATE_SEND_DATA:
    case HTTPSTATE_SEND_DATA_HEADER:
    case HTTPSTATE_SEND_DATA_TRAILER:

        if (!c->is_packetized) 
		{
            if (c->poll_entry->revents & (POLLERR | POLLHUP))
                return -1;

            /* no need to read if no events */
            if (!(c->poll_entry->revents & POLLOUT))
                return 0;
        }

#if 1

#endif
        if (http_send_data(c) < 0)
            return -1;
        /* close connection if trailer sent */
        if (c->state == HTTPSTATE_SEND_DATA_TRAILER)
            return -1;
        /* Check if it is a single jpeg frame 123 */
        if (c->stream->single_frame && c->data_count > c->cur_frame_bytes && c->cur_frame_bytes > 0) 
		{
            close_connection(c);
        }
        break;
    case HTTPSTATE_WAIT_FEED:
        /* no need to read if no events */
        if (c->poll_entry->revents & (POLLIN | POLLERR | POLLHUP))
            return -1;

        /* nothing to do, we'll be waken up by incoming feed packets */
        break;

    case RTSPSTATE_SEND_REPLY:
        if (c->poll_entry->revents & (POLLERR | POLLHUP))
            goto close_connection;
        /* no need to write if no events */
        if (!(c->poll_entry->revents & POLLOUT))
            return 0;
        len = send(c->fd, (char*)(c->buffer_ptr), c->buffer_end - c->buffer_ptr, 0);
        if (len < 0) {
            if (ff_neterrno() != AVERROR(EAGAIN) &&
                ff_neterrno() != AVERROR(EINTR)) {
                goto close_connection;
            }
            break;
        }
        c->buffer_ptr += len;
        c->data_count += len;
        if (c->buffer_ptr >= c->buffer_end) {
            /* all the buffer was sent : wait for a new request */
            av_freep(&c->pb_buffer);
            start_wait_request(c, 1);
        }
        break;
    case RTSPSTATE_SEND_PACKET:
        if (c->poll_entry->revents & (POLLERR | POLLHUP)) {
            av_freep(&c->packet_buffer);
            return -1;
        }
        /* no need to write if no events */
        if (!(c->poll_entry->revents & POLLOUT))
            return 0;
        len = send(c->fd, (char*)(c->packet_buffer_ptr), c->packet_buffer_end - c->packet_buffer_ptr, 0);
        if (len < 0) {
            if (ff_neterrno() != AVERROR(EAGAIN) &&
                ff_neterrno() != AVERROR(EINTR)) {
                /* error : close connection */
                av_freep(&c->packet_buffer);
                return -1;
            }
            break;
        }
        c->packet_buffer_ptr += len;
        if (c->packet_buffer_ptr >= c->packet_buffer_end) {
            /* all the buffer was sent : wait for a new request */
            av_freep(&c->packet_buffer);
            c->state = RTSPSTATE_WAIT_REQUEST;
        }
        break;
    case HTTPSTATE_READY:
        /* nothing to do */
        break;
    default:
        return -1;
    }
    return 0;

close_connection:
    av_freep(&c->pb_buffer);
    return -1;
}

int CFFStreamServer::modify_current_stream(HTTPContext *c, char *rates)
{
    int i;
    FFServerStream *req = c->stream;
    int action_required = 0;

    /* Not much we can do for a feed */
    if (!req->feed)
        return 0;

    for (i = 0; i < req->nb_streams; i++) {
        AVCodecContext *codec = req->streams[i]->codec;

        switch(rates[i]) {
            case 0:
                c->switch_feed_streams[i] = req->feed_streams[i];
                break;
            case 1:
                c->switch_feed_streams[i] = find_stream_in_feed(req->feed, codec, codec->bit_rate / 2);
                break;
            case 2:
                /* Wants off or slow */
                c->switch_feed_streams[i] = find_stream_in_feed(req->feed, codec, codec->bit_rate / 4);
#ifdef WANTS_OFF
                /* This doesn't work well when it turns off the only stream! */
                c->switch_feed_streams[i] = -2;
                c->feed_streams[i] = -2;
#endif
                break;
        }

        if (c->switch_feed_streams[i] >= 0 &&
            c->switch_feed_streams[i] != c->feed_streams[i]) {
            action_required = 1;
        }
    }

    return action_required;
}



void CFFStreamServer::fmt_bytecount(AVIOContext *pb, int64_t count)
{
    static const char suffix[] = " kMGTP";
    const char *s;

    for (s = suffix; count >= 100000 && s[1]; count /= 1000, s++);

    avio_printf(pb, "%"PRId64"%c", count, *s);
}

void CFFStreamServer::print_stream_params(AVIOContext *pb, FFServerStream *stream)
{
    int i, stream_no;
    const char *type = "unknown";
    char parameters[64];
    AVStream *st;
    AVCodec *codec;

    stream_no = stream->nb_streams;

    avio_printf(pb, "<table cellspacing=0 cellpadding=4><tr><th>Stream<th>"
                    "type<th>kbit/s<th align=left>codec<th align=left>"
                    "Parameters\n");

    for (i = 0; i < stream_no; i++) {
        st = stream->streams[i];
        codec = avcodec_find_encoder(st->codec->codec_id);

        parameters[0] = 0;

        switch(st->codec->codec_type) {
        case AVMEDIA_TYPE_AUDIO:
            type = "audio";
            snprintf(parameters, sizeof(parameters), "%d channel(s), %d Hz",
                     st->codec->channels, st->codec->sample_rate);
            break;
        case AVMEDIA_TYPE_VIDEO:
            type = "video";
            snprintf(parameters, sizeof(parameters),
                     "%dx%d, q=%d-%d, fps=%d", st->codec->width,
                     st->codec->height, st->codec->qmin, st->codec->qmax,
                     st->codec->time_base.den / st->codec->time_base.num);
            break;
        default:
            abort();
        }

        avio_printf(pb, "<tr><td align=right>%d<td>%s<td align=right>%"PRId64
                        "<td>%s<td>%s\n",
                    i, type, (int64_t)st->codec->bit_rate/1000,
                    codec ? codec->name : "", parameters);
     }

     avio_printf(pb, "</table>\n");
}

int CFFStreamServer::open_input_stream(HTTPContext *c, const char *info)
{
    char buf[128];
    char input_filename[1024];
    AVFormatContext *s = NULL;
    int buf_size, i, ret;
    int64_t stream_pos;

    /* find file name */
    {
        strcpy(input_filename, c->stream->feed_filename);
        buf_size = 0;
        /* compute position (relative time) */
        if (av_find_info_tag(buf, sizeof(buf), "date", info)) {
            if ((ret = av_parse_time(&stream_pos, buf, 1)) < 0) {
//                http_log("Invalid date specification '%s' for stream\n", buf);
                return ret;
            }
        } else
            stream_pos = 0;
    }
    if (!input_filename[0]) {
//        http_log("No filename was specified for stream\n");
        return AVERROR(EINVAL);
    }

    /* open stream */

	av_dict_set(&c->stream->in_opts, "rtsp_transport", "tcp", 0);
    ret = avformat_open_input(&s, input_filename, c->stream->ifmt, &c->stream->in_opts);
    if (ret < 0) {
//		http_log("Could not open input '%s': \n", input_filename);
        return ret;
    }

    /* set buffer size */
    if (buf_size > 0) {
        ret = ffio_set_buf_size(s->pb, buf_size);
        if (ret < 0) {
//            http_log("Failed to set buffer size\n");
            return ret;
        }
    }

    s->flags |= AVFMT_FLAG_GENPTS;
    c->fmt_in = s;
    if (strcmp(s->iformat->name, "ffm") &&
        (ret = avformat_find_stream_info(c->fmt_in, NULL)) < 0) {

        avformat_close_input(&s);
        return ret;
    }

    c->pts_stream_index = 0;
    for(i=0;i<c->stream->nb_streams;i++) {
        if (c->pts_stream_index == 0 &&
            c->stream->streams[i]->codec->codec_type == AVMEDIA_TYPE_VIDEO) {
            c->pts_stream_index = i;
        }
    }

    if (c->fmt_in->iformat->read_seek)
        av_seek_frame(c->fmt_in, -1, stream_pos, 0);
    
    c->start_time = cur_time;
    c->first_pts = AV_NOPTS_VALUE;
    return 0;
}

/* return the server clock (in us) */
int64_t CFFStreamServer::get_server_clock(HTTPContext *c)
{
    return (cur_time - c->start_time) * 1000;
}

int64_t CFFStreamServer::get_packet_send_clock(HTTPContext *c)
{
    int bytes_left, bytes_sent, frame_bytes;

    frame_bytes = c->cur_frame_bytes;
    if (frame_bytes <= 0)
        return c->cur_pts;

    bytes_left = c->buffer_end - c->buffer_ptr;
    bytes_sent = frame_bytes - bytes_left;
    return c->cur_pts + (c->cur_frame_duration * bytes_sent) / frame_bytes;
}