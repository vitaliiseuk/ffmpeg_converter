
#ifndef AVFORMAT_RTSPCODES_H
#define AVFORMAT_RTSPCODES_H

#include "libavutil/common.h"
#include "libavformat/http.h"

/** RTSP handling */
enum RTSPStatusCode {
		RTSP_STATUS_CONTINUE = 100,
		RTSP_STATUS_OK = 200,
		RTSP_STATUS_CREATED = 201,
		RTSP_STATUS_LOW_ON_STORAGE_SPACE = 250,
		RTSP_STATUS_MULTIPLE_CHOICES = 300,
		RTSP_STATUS_MOVED_PERMANENTLY = 301,
		RTSP_STATUS_MOVED_TEMPORARILY = 302,
		RTSP_STATUS_SEE_OTHER = 303,
		RTSP_STATUS_NOT_MODIFIED = 304,
		RTSP_STATUS_USE_PROXY = 305,
		RTSP_STATUS_BAD_REQUEST = 400,
		RTSP_STATUS_UNAUTHORIZED = 401,
		RTSP_STATUS_PAYMENT_REQUIRED = 402,
		RTSP_STATUS_FORBIDDEN = 403,
		RTSP_STATUS_NOT_FOUND = 404,
		RTSP_STATUS_METHOD = 405,
		RTSP_STATUS_NOT_ACCEPTABLE = 406,
		RTSP_STATUS_PROXY_AUTH_REQUIRED = 407,
		RTSP_STATUS_REQ_TIME_OUT = 408,
		RTSP_STATUS_GONE = 410,
		RTSP_STATUS_LENGTH_REQUIRED = 411,
		RTSP_STATUS_PRECONDITION_FAILED = 412,
		RTSP_STATUS_REQ_ENTITY_2LARGE = 413,
		RTSP_STATUS_REQ_URI_2LARGE = 414,
		RTSP_STATUS_UNSUPPORTED_MTYPE = 415,
		RTSP_STATUS_PARAM_NOT_UNDERSTOOD = 451,
		RTSP_STATUS_CONFERENCE_NOT_FOUND = 452,
		RTSP_STATUS_BANDWIDTH = 453,
		RTSP_STATUS_SESSION = 454,
		RTSP_STATUS_STATE = 455,
		RTSP_STATUS_INVALID_HEADER_FIELD = 456,
		RTSP_STATUS_INVALID_RANGE = 457,
		RTSP_STATUS_RONLY_PARAMETER = 458,
		RTSP_STATUS_AGGREGATE = 459,
		RTSP_STATUS_ONLY_AGGREGATE = 460,
		RTSP_STATUS_TRANSPORT = 461,
		RTSP_STATUS_UNREACHABLE = 462,
		RTSP_STATUS_INTERNAL = 500,
		RTSP_STATUS_NOT_IMPLEMENTED = 501,
		RTSP_STATUS_BAD_GATEWAY = 502,
		RTSP_STATUS_SERVICE = 503,
		RTSP_STATUS_GATEWAY_TIME_OUT = 504,
		RTSP_STATUS_VERSION = 505,
		RTSP_STATUS_UNSUPPORTED_OPTION = 551,
};

static char * const rtsp_status_strings[] = {
						"Continue", 
						"OK", 
						"Created", 
						"Low on Storage Space", 
						"Multiple Choices", 
						"Moved Permanently", 
						"Moved Temporarily",
						"See Other",
						"Not Modified",
						"Use Proxy",
						"Bad Request",
						"Unauthorized",
						"Payment Required",
						"Forbidden",
						"Not Found",
						"Method Not Allowed",
						"Not Acceptable",
						"Proxy Authentication Required",
						"Request Time-out",
						"Gone",
						"Length Required",
						"Precondition Failed",
						"Request Entity Too Large",
						"Request URI Too Large",
						"Unsupported Media Type",
						"Parameter Not Understood",
						"Conference Not Found",
						"Not Enough Bandwidth",
						"Session Not Found",
						"Method Not Valid in This State",
						"Header Field Not Valid for Resource",
						"Invalid Range",
						"Parameter Is Read-Only",
						"Aggregate Operation no Allowed",
						"Only Aggregate Operation Allowed",
						"Unsupported Transport",
						"Destination Unreachable",
						"Internal Server Error",
						"Not Implemented",
						"Bad Gateway",
						"Service Unavailable",
						"Gateway Time-out",
						"RTSP Version not Supported",
						"Option not supported"
};

#define RTSP_STATUS_CODE2STRING(x) (\
x >= 100 && x < FF_ARRAY_ELEMS(rtsp_status_strings) && rtsp_status_strings[x] \
)? rtsp_status_strings[x] : NULL

enum RTSPMethod {
    DESCRIBE,
    ANNOUNCE,
    OPTIONS,
    SETUP,
    PLAY,
    PAUSE,
    TEARDOWN,
    GET_PARAMETER,
    SET_PARAMETER,
    REDIRECT,
    RECORD,
    UNKNOWN = -1,
};

static inline int ff_rtsp_averror(enum RTSPStatusCode status_code, int default_averror)
{
    return ff_http_averror(status_code, default_averror);
}

#endif /* AVFORMAT_RTSPCODES_H */
