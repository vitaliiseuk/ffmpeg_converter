//#include "FFServerStream.h"

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
		/* getaddrinfo returns a linked list of addrinfo structs.
		* Even if we set ai_family = AF_INET above, make sure
		* that the returned one actually is of the correct type. */
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

int CFFStreamServer::ffserver_save_avoption(const char *opt, const char *arg, int type,	FFServerConfig *config)
{
	static int hinted = 0;
	int ret = -1;
	AVDictionaryEntry *e;
	const AVOption *o = NULL;
	const char *option = NULL;
	const char *codec_name = NULL;
	char buff[1024];
	AVCodecContext *ctx;
	AVDictionary **dict;
	enum AVCodecID guessed_codec_id;

	switch (type) 
	{
	case AV_OPT_FLAG_VIDEO_PARAM:
		ctx = config->dummy_vctx;
		dict = &config->video_opts;
		guessed_codec_id = config->guessed_video_codec_id != AV_CODEC_ID_NONE ?	config->guessed_video_codec_id : AV_CODEC_ID_H264;
		break;
	case AV_OPT_FLAG_AUDIO_PARAM:
		ctx = config->dummy_actx;
		dict = &config->audio_opts;
		guessed_codec_id = config->guessed_audio_codec_id != AV_CODEC_ID_NONE ?	config->guessed_audio_codec_id : AV_CODEC_ID_AAC;
		break;
	default:
		av_assert0(0);
	}

	if (strchr(opt, ':')) 
	{
		//explicit private option
		snprintf(buff, sizeof(buff), "%s", opt);
		codec_name = buff;
		if (!(option = strchr(buff, ':')))
		{
			return -1;
		}
		buff[option - buff] = '\0';
		option++;
		if ((ret = ffserver_set_codec(ctx, codec_name, config)) < 0)
			return ret;
		if (!ctx->codec || !ctx->priv_data)
			return -1;
	}
	else 
	{
		option = opt;
	}

	o = av_opt_find(ctx, option, NULL, type | AV_OPT_FLAG_ENCODING_PARAM, AV_OPT_SEARCH_CHILDREN);

	if (!o && (!strcmp(option, "time_base") || !strcmp(option, "pixel_format") || !strcmp(option, "video_size") || !strcmp(option, "codec_tag")))
		o = av_opt_find(ctx, option, NULL, 0, 0);
	if (!o) 
	{
		if (!hinted && ctx->codec_id == AV_CODEC_ID_NONE) 
		{
			hinted = 1;
		}
	}
	else if ((ret = av_opt_set(ctx, option, arg, AV_OPT_SEARCH_CHILDREN)) < 0) 
	{
		ret = -1;
		//report_config_error(config->filename, config->line_num, AV_LOG_ERROR, &config->errors, "Invalid value for option %s (%s): \n", opt, arg);
	} 
	else if ((e = av_dict_get(*dict, option, NULL, 0))) 
	{
		if ((o->type == AV_OPT_TYPE_FLAGS) && arg && (arg[0] == '+' || arg[0] == '-'))
			return av_dict_set(dict, option, arg, AV_DICT_APPEND);

		// report_config_error(config->filename, config->line_num, AV_LOG_ERROR,	&config->errors, "Redeclaring value of option '%s'." "Previous value was: '%s'.\n", opt, e->value); */
	}
	else if (av_dict_set(dict, option, arg, 0) < 0) 
	{
		return AVERROR(ENOMEM);
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


void CFFStreamServer::add_codec(FFServerStream *stream, AVCodecContext *av, FFServerConfig *config)
{
	AVStream *st;
	AVDictionary **opts, *recommended = NULL;
	char *enc_config;

	if (stream->nb_streams >= FF_ARRAY_ELEMS(stream->streams))
		return;

	opts = av->codec_type == AVMEDIA_TYPE_AUDIO ?
		&config->audio_opts : &config->video_opts;
	av_dict_copy(&recommended, *opts, 0);
	av_opt_set_dict2(av->priv_data, opts, AV_OPT_SEARCH_CHILDREN);
	av_opt_set_dict2(av, opts, AV_OPT_SEARCH_CHILDREN);

	if (av_dict_count(*opts))
	{

		av_log(NULL, AV_LOG_WARNING, "Something is wrong, %d options are not set!\n", av_dict_count(*opts));
		TRACE("Something is wrong, %d options are not set!\n", av_dict_count(*opts));
	}
	if (!config->stream_use_defaults) {
		switch (av->codec_type) {
		case AVMEDIA_TYPE_AUDIO:
/*			if (av->bit_rate == 0)
				report_config_error(config->filename, config->line_num,	AV_LOG_ERROR, &config->errors,	"audio bit rate is not set\n");
			if (av->sample_rate == 0)
				report_config_error(config->filename, config->line_num,	AV_LOG_ERROR, &config->errors,  "audio sample rate is not set\n"); */
			break;
		case AVMEDIA_TYPE_VIDEO:
/*			if (av->width == 0 || av->height == 0)
				report_config_error(config->filename, config->line_num,	AV_LOG_ERROR, &config->errors,	"video size is not set\n"); */
			break;
		default:
			av_assert0(0);
		}
		goto done;
	}

	/* stream_use_defaults = true */

	/* compute default parameters */
	switch (av->codec_type) {
	case AVMEDIA_TYPE_AUDIO:
		if (!av_dict_get(recommended, "b", NULL, 0)) 
		{
			av->bit_rate = 64000;
			av_dict_set_int(&recommended, "b", av->bit_rate, 0);

/*			WARNING("Setting default value for audio bit rate = %d. "	"Use NoDefaults to disable it.\n",	av->bit_rate); */
		}
		if (!av_dict_get(recommended, "ar", NULL, 0)) 
		{
			av->sample_rate = 22050;
			av_dict_set_int(&recommended, "ar", av->sample_rate, 0);
/*			WARNING("Setting default value for audio sample rate = %d. " "Use NoDefaults to disable it.\n",	av->sample_rate); */
		}
		if (!av_dict_get(recommended, "ac", NULL, 0)) 
		{
			av->channels = 1;
			av_dict_set_int(&recommended, "ac", av->channels, 0);
/*			WARNING("Setting default value for audio channel count = %d. "	"Use NoDefaults to disable it.\n",	av->channels); */
		}
		break;
	case AVMEDIA_TYPE_VIDEO:
		if (!av_dict_get(recommended, "b", NULL, 0)) 
		{
			av->bit_rate = 64000;
			av_dict_set_int(&recommended, "b", av->bit_rate, 0);
/*			WARNING("Setting default value for video bit rate = %d. " "Use NoDefaults to disable it.\n", av->bit_rate); */
		}
		if (!av_dict_get(recommended, "time_base", NULL, 0))
		{
			av->time_base.den = 5;
			av->time_base.num = 1;
			av_dict_set(&recommended, "time_base", "1/5", 0);

/*			WARNING("Setting default value for video frame rate = %d. "	"Use NoDefaults to disable it.\n",	av->time_base.den); */
		}
		if (!av_dict_get(recommended, "video_size", NULL, 0)) {
			av->width = 160;
			av->height = 128;
			av_dict_set(&recommended, "video_size", "160x128", 0);
/*			WARNING("Setting default value for video size = %dx%d. "  "Use NoDefaults to disable it.\n", av->width, av->height); */
		}
		/* Bitrate tolerance is less for streaming */
		if (!av_dict_get(recommended, "bt", NULL, 0)) {
			av->bit_rate_tolerance = FFMAX(av->bit_rate / 4, (int64_t)av->bit_rate*av->time_base.num / av->time_base.den);
			av_dict_set_int(&recommended, "bt", av->bit_rate_tolerance, 0);
/*			WARNING("Setting default value for video bit rate tolerance = %d. "	"Use NoDefaults to disable it.\n",	av->bit_rate_tolerance); */
		}

		if (!av_dict_get(recommended, "rc_eq", NULL, 0)) {
			av->rc_eq = av_strdup("tex^qComp");
			av_dict_set(&recommended, "rc_eq", "tex^qComp", 0);
/*			WARNING("Setting default value for video rate control equation = " 	"%s. Use NoDefaults to disable it.\n",	av->rc_eq); */
		}
		if (!av_dict_get(recommended, "maxrate", NULL, 0)) 
		{
			av->rc_max_rate = av->bit_rate * 2;
			av_dict_set_int(&recommended, "maxrate", av->rc_max_rate, 0);
/*			WARNING("Setting default value for video max rate = %d. " "Use NoDefaults to disable it.\n", av->rc_max_rate); */
		}

		if (av->rc_max_rate && !av_dict_get(recommended, "bufsize", NULL, 0)) 
		{
			av->rc_buffer_size = av->rc_max_rate;
			av_dict_set_int(&recommended, "bufsize", av->rc_buffer_size, 0);
/*			WARNING("Setting default value for video buffer size = %d. "  "Use NoDefaults to disable it.\n", av->rc_buffer_size); */
		}
		break;
	default:
		abort();
	}

done:
	st = (AVStream*)av_mallocz(sizeof(AVStream));
	if (!st)
		return;
	av_dict_get_string(recommended, &enc_config, '=', ',');
	av_dict_free(&recommended);
	av_stream_set_recommended_encoder_configuration(st, enc_config);
	st->codec = av;
	st->codecpar = avcodec_parameters_alloc();
	avcodec_parameters_from_context(st->codecpar, av);
	stream->streams[stream->nb_streams++] = st;
}

int CFFStreamServer::ffserver_set_codec(AVCodecContext *ctx, const char *codec_name,	FFServerConfig *config)
{
	int ret;
	AVCodec *codec = avcodec_find_encoder_by_name(codec_name);
	
	if (!codec || codec->type != ctx->codec_type) 
	{
/*		report_config_error(config->filename, config->line_num, AV_LOG_ERROR,	&config->errors,	"Invalid codec name: '%s'\n", codec_name); */
		return 0;
	}
	if (ctx->codec_id == AV_CODEC_ID_NONE && !ctx->priv_data) 
	{
		if ((ret = avcodec_get_context_defaults3(ctx, codec)) < 0)
			return ret;
		ctx->codec = codec;
	}
	
/*	if (ctx->codec_id != codec->id)
		report_config_error(config->filename, config->line_num, AV_LOG_ERROR,	&config->errors, "Inconsistent configuration: trying to set '%s' "	"codec option, but '%s' codec is used previously\n", codec_name, avcodec_get_name(ctx->codec_id)); */

	return 0;
}

int CFFStreamServer::ffserver_opt_preset(const char *arg, int type, FFServerConfig *config)
{
	FILE *f = NULL;
	char filename[1000], tmp[1000], tmp2[1000], line[1000];
	int ret = -1;
	AVCodecContext *avctx;
	const AVCodec *codec;

	switch (type) {
	case AV_OPT_FLAG_AUDIO_PARAM:
		avctx = config->dummy_actx;
		break;
	case AV_OPT_FLAG_VIDEO_PARAM:
		avctx = config->dummy_vctx;
		break;
	default:
		av_assert0(0);
	}
	codec = avcodec_find_encoder(avctx->codec_id);

	if (!(f = get_preset_file(filename, sizeof(filename), arg, 0, codec ? codec->name : NULL))) 
	{
		av_log(NULL, AV_LOG_ERROR, "File for preset '%s' not found\n", arg);
		TRACE("File for preset '%s' not found\n", arg);
		return AVERROR(EINVAL);
	}

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

AVOutputFormat* CFFStreamServer::ffserver_guess_format(const char *short_name, const char *filename, const char *mime_type)
{
	AVOutputFormat *fmt = av_guess_format(short_name, filename, mime_type);

	if (fmt) 
	{
		AVOutputFormat *stream_fmt;
		char stream_format_name[64];

		snprintf(stream_format_name, sizeof(stream_format_name), "%s_stream", fmt->name);
		stream_fmt = av_guess_format(stream_format_name, NULL, NULL);

		if (stream_fmt)
			fmt = stream_fmt;
	}

	return fmt;
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
error:
/*	if (config) 
	{
		va_list vl;
		va_start(vl, error_msg);
		vreport_config_error(config->filename, config->line_num, AV_LOG_ERROR,	&config->errors, error_msg, vl);
		va_end(vl);
	} */
	return AVERROR(EINVAL);
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
error:
/*	if (config) {
		va_list vl;
		va_start(vl, error_msg);
		vreport_config_error(config->filename, config->line_num, AV_LOG_ERROR,
			&config->errors, error_msg, vl);
		va_end(vl);
	} */
	return AVERROR(EINVAL);
}

int CFFStreamServer::ffserver_save_avoption_int(const char *opt, int64_t arg,	int type, FFServerConfig *config)
{
	char buf[22];
	snprintf(buf, sizeof(buf), "%"PRId64, arg);
	return ffserver_save_avoption(opt, buf, type, config);
}

int CFFStreamServer::ffserver_parse_config_global(FFServerConfig *config, const char *cmd, const char *p)
{
	int val;
	char arg[1024];
	int ret = 0;
	if (!av_strcasecmp(cmd, "Port") || !av_strcasecmp(cmd, "HTTPPort")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, 1, 65535, config, "Invalid port: %s\n", arg);
		config->http_addr.sin_port = htons(val);
	}
	else if (!av_strcasecmp(cmd, "HTTPBindAddress") ||	!av_strcasecmp(cmd, "BindAddress")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);

		if (resolve_host(&config->http_addr.sin_addr, arg))
			ret = -1;
	}
	else if (!av_strcasecmp(cmd, "RTSPPort")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, 1, 65535, config,	"Invalid port: %s\n", arg);
		config->rtsp_addr.sin_port = htons(val);
	}
	else if (!av_strcasecmp(cmd, "RTSPBindAddress")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		if (resolve_host(&config->rtsp_addr.sin_addr, arg))
			ret = -1;
	}
	else if (!av_strcasecmp(cmd, "MaxHTTPConnections")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, 1, 65535, config,	"Invalid MaxHTTPConnections: %s\n", arg);
		config->nb_max_http_connections = val;
		if (config->nb_max_connections > config->nb_max_http_connections) 
		{
			ret = -1;
		}
	}
	else if (!av_strcasecmp(cmd, "MaxClients")) 
	{
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, 1, 65535, config,	"Invalid MaxClients: '%s'\n", arg);
		config->nb_max_connections = val;
		if (config->nb_max_connections > config->nb_max_http_connections) 
		{
			ret = -1;
		}
	}
	else if (!av_strcasecmp(cmd, "MaxBandwidth")) 
	{
		int64_t llval;
		char *tailp;
		ffserver_get_arg(arg, sizeof(arg), p);
		errno = 0;
		llval = strtoll(arg, &tailp, 10);
		if (llval < 10 || llval > 10000000 || tailp[0] || errno)
			ret = -1;
		else
			config->max_bandwidth = llval;
	}
	else if (!av_strcasecmp(cmd, "LoadModule")) 
	{
		// ERROR("Loadable modules are no longer supported\n");
		ret = -1;
	}
	else if (!av_strcasecmp(cmd, "NoDefaults")) 
	{
		config->use_defaults = 0;
	}
	else if (!av_strcasecmp(cmd, "UseDefaults"))
	{
		config->use_defaults = 1;
	}
	else
		ret = -1;
	return ret;
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
	else if (!av_strcasecmp(cmd, "VideoFrameRate")) {
		ffserver_get_arg(&arg[2], sizeof(arg)-2, p);
		arg[0] = '1'; arg[1] = '/';
		if (ffserver_save_avoption("time_base", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "PixelFormat")) {
		enum AVPixelFormat pix_fmt;
		ffserver_get_arg(arg, sizeof(arg), p);
		pix_fmt = av_get_pix_fmt(arg);
		if (pix_fmt == AV_PIX_FMT_NONE)
			ERROR("Unknown pixel format: '%s'\n", arg);
		else if (ffserver_save_avoption("pixel_format", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoGopSize")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("g", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoIntraOnly")) {
		if (ffserver_save_avoption("g", "1", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoHighQuality")) {
		if (ffserver_save_avoption("mbd", "+bits", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "Video4MotionVector")) {
		if (ffserver_save_avoption("mbd", "+bits", AV_OPT_FLAG_VIDEO_PARAM, config) < 0 || //FIXME remove
			ffserver_save_avoption("flags", "+mv4", AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
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
	else if (!av_strcasecmp(cmd, "VideoQDiff")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("qdiff", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoQMax")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("qmax", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "VideoQMin")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("qmin", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "LumiMask")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("lumi_mask", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "DarkMask")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (ffserver_save_avoption("dark_mask", arg, AV_OPT_FLAG_VIDEO_PARAM, config) < 0)
			goto nomem;
	}
	else if (!av_strcasecmp(cmd, "NoVideo")) {
		config->no_video = 1;
	}
	else if (!av_strcasecmp(cmd, "NoAudio")) {
		config->no_audio = 1;
	}
/*	else if (!av_strcasecmp(cmd, "ACL")) {
		ffserver_parse_acl_row(stream, NULL, NULL, *p, config->filename,
			config->line_num);
	}
	else if (!av_strcasecmp(cmd, "DynamicACL")) {
		ffserver_get_arg(stream->dynamic_acl, sizeof(stream->dynamic_acl), p);
	}*/
	else if (!av_strcasecmp(cmd, "RTSPOption")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		av_freep(&stream->rtsp_option);
		stream->rtsp_option = av_strdup(arg);
	}
	else if (!av_strcasecmp(cmd, "MulticastAddress")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		if (resolve_host(&stream->multicast_ip, arg))
			ERROR("Invalid host/IP address: '%s'\n", arg);
		stream->is_multicast = 1;
		stream->loop = 1; /* default is looping */
	}
	else if (!av_strcasecmp(cmd, "MulticastPort")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, 1, 65535, config,
			"Invalid MulticastPort: '%s'\n", arg);
		stream->multicast_port = val;
	}
	else if (!av_strcasecmp(cmd, "MulticastTTL")) {
		ffserver_get_arg(arg, sizeof(arg), p);
		ffserver_set_int_param(&val, arg, 0, INT_MIN, INT_MAX, config,
			"Invalid MulticastTTL: '%s'\n", arg);
		stream->multicast_ttl = val;
	}
	else if (!av_strcasecmp(cmd, "NoLoop")) {
		stream->loop = 0;
	}
	else if (!av_strcasecmp(cmd, "/Stream")) {
		config->stream_use_defaults &= 1;
		av_dict_free(&config->video_opts);
		av_dict_free(&config->audio_opts);
		avcodec_free_context(&config->dummy_vctx);
		avcodec_free_context(&config->dummy_actx);
		config->no_video = 0;
		config->no_audio = 0;
		*pstream = NULL;
	}
	else if (!av_strcasecmp(cmd, "File") ||	!av_strcasecmp(cmd, "ReadOnlyFile")) 
	{
		ffserver_get_arg(stream->feed_filename, sizeof(stream->feed_filename), p);
	}
	else if (!av_strcasecmp(cmd, "UseDefaults")) {
/*		if (config->stream_use_defaults > 1)
			WARNING("Multiple UseDefaults/NoDefaults entries.\n"); */
		config->stream_use_defaults = 3;
	}
	else if (!av_strcasecmp(cmd, "NoDefaults")) {
/*		if (config->stream_use_defaults > 1)
			WARNING("Multiple UseDefaults/NoDefaults entries.\n"); */
		config->stream_use_defaults = 2;
	}
	else {
		ERROR("Invalid entry '%s' inside <Stream></Stream>\n", cmd);
	}
	return 0;
nomem:
	av_log(NULL, AV_LOG_ERROR, "Out of memory. Aborting.\n");
	TRACE("Out of memory. Aborting.\n");
	av_dict_free(&config->video_opts);
	av_dict_free(&config->audio_opts);
	avcodec_free_context(&config->dummy_vctx);
	avcodec_free_context(&config->dummy_actx);
	return AVERROR(ENOMEM);
}

int CFFStreamServer::ffserver_parse_config_redirect(FFServerConfig *config, const char *cmd, const char **p, FFServerStream **predirect)
{
/*	FFServerStream *redirect;
	av_assert0(predirect);
	redirect = *predirect;

	if (!av_strcasecmp(cmd, "<Redirect")) {
		char *q;
		redirect = (FFServerStream*)av_mallocz(sizeof(FFServerStream));
		if (!redirect)
			return AVERROR(ENOMEM);

		ffserver_get_arg(redirect->filename, sizeof(redirect->filename), p);
		q = strrchr(redirect->filename, '>');
		if (*q)
			*q = '\0';
		redirect->stream_type = STREAM_TYPE_REDIRECT;
		*predirect = redirect;
		return 0;
	}
	av_assert0(redirect);
	if (!av_strcasecmp(cmd, "URL")) {
		ffserver_get_arg(redirect->feed_filename,
			sizeof(redirect->feed_filename), p);
	}
	else if (!av_strcasecmp(cmd, "</Redirect>")) {
		if (!redirect->feed_filename[0])
			ERROR("No URL found for <Redirect>\n");
		*predirect = NULL;
	}
	else {
		ERROR("Invalid entry '%s' inside <Redirect></Redirect>\n", cmd);
	}*/
	return 0;
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

//	ffserver_parse_config_global(config, "HTTPPort", "9999");
	ffserver_parse_config_global(config, "RTSPPort", szRtspPort);
//	ffserver_parse_config_global(config, "HTTPBindAddress", "0.0.0.0");
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

void CFFStreamServer::ffserver_free_child_args(void *argsp)
{
	int i;
	char **args;
	if (!argsp)
		return;
	args = *(char ***)argsp;
	if (!args)
		return;
	for (i = 0; i < MAX_CHILD_ARGS; i++)
		av_free(args[i]);
	av_freep(argsp);
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

	/* Note: getaddrinfo allows service to be a string, which
	* should be looked up using getservbyname. */
	if (service)
		sin->sin_port = htons(atoi(service));

	ai = (addrinfo*)av_mallocz(sizeof(struct addrinfo));
	if (!ai) {
		av_free(sin);
		return EAI_FAIL;
	}

	*res = ai;
	ai->ai_family = AF_INET;
	ai->ai_socktype = hints ? hints->ai_socktype : 0;
	switch (ai->ai_socktype) {
	case SOCK_STREAM:
		ai->ai_protocol = IPPROTO_TCP;
		break;
	case SOCK_DGRAM:
		ai->ai_protocol = IPPROTO_UDP;
		break;
	default:
		ai->ai_protocol = 0;
		break;
	}

	ai->ai_addr = (struct sockaddr *)sin;
	ai->ai_addrlen = sizeof(struct sockaddr_in);
	if (hints && (hints->ai_flags & AI_CANONNAME))
		ai->ai_canonname = h ? av_strdup(h->h_name) : NULL;

	ai->ai_next = NULL;
	return 0;
}

void CFFStreamServer::ff_freeaddrinfo(struct addrinfo *res)
{
#if HAVE_WINSOCK2_H
	void (WSAAPI *win_freeaddrinfo)(struct addrinfo *res);
	HMODULE ws2mod = GetModuleHandle("ws2_32.dll");
	win_freeaddrinfo = (void (WSAAPI *)(struct addrinfo *res))
		GetProcAddress(ws2mod, "freeaddrinfo");
	if (win_freeaddrinfo) {
		win_freeaddrinfo(res);
		return;
	}
#endif /* HAVE_WINSOCK2_H */

	av_freep(&res->ai_canonname);
	av_freep(&res->ai_addr);
	av_freep(&res);
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

/* start all multicast streams */
void CFFStreamServer::start_multicast(void)
{
    FFServerStream *stream;
    char session_id[32];
    HTTPContext *rtp_c;
    struct sockaddr_in dest_addr = {0};
    int default_port, stream_index;
    unsigned int random0, random1;

    default_port = 6000;
    for(stream = config.first_stream; stream; stream = stream->next) {

        if (!stream->is_multicast)
            continue; 

        random0 = av_lfg_get(&random_state);
        random1 = av_lfg_get(&random_state);

        /* open the RTP connection */
        snprintf(session_id, sizeof(session_id), "%08x%08x", random0, random1);

        /* choose a port if none given */
        if (stream->multicast_port == 0) {
            stream->multicast_port = default_port;
            default_port += 100;
        }

        dest_addr.sin_family = AF_INET;
        dest_addr.sin_addr = stream->multicast_ip;
        dest_addr.sin_port = htons(stream->multicast_port);

		rtp_c = rtp_new_connection(&dest_addr, stream, session_id, RTSP_LOWER_TRANSPORT_UDP_MULTICAST);
        if (!rtp_c)
            continue;

        if (open_input_stream(rtp_c, "") < 0) {
            //http_log("Could not open input stream for stream '%s'\n", stream->filename);
            continue;
        }

        /* open each RTP stream */
        for(stream_index = 0; stream_index < stream->nb_streams; stream_index++) 
		{
            dest_addr.sin_port = htons(stream->multicast_port + 2 * stream_index);
            if (rtp_new_av_stream(rtp_c, stream_index, &dest_addr, NULL) >= 0)
                continue;

            //http_log("Could not open output stream '%s/streamid=%d'\n", stream->filename, stream_index);
            exit(1);
        }

        rtp_c->state = HTTPSTATE_SEND_DATA;
    }
}

/* main loop of the HTTP server */

int CFFStreamServer::http_server(void)
{
    int server_fd = 0, rtsp_server_fd = 0;
    int ret, delay;
    pollfd *poll_table, *poll_entry;
    HTTPContext *c, *c_next;

    poll_table = (pollfd*)av_mallocz_array(config.nb_max_http_connections + 2, sizeof(*poll_table));
    if(!poll_table) 
	{
        //http_log("Impossible to allocate a poll table handling %d " "connections.\n", config.nb_max_http_connections);
        return -1;
    }

	if (config.rtsp_addr.sin_port) 
	{
		rtsp_server_fd = socket_open_listen(&config.rtsp_addr);
		if (rtsp_server_fd < 0) 
		{
			closesocket(server_fd);
			goto quit;
		}
	}

    if (!rtsp_server_fd && !server_fd) 
	{
		goto quit;
    }

    for(;;) 
	{
        poll_entry = poll_table;

		if (rtsp_server_fd) 
		{
            poll_entry->fd = rtsp_server_fd;
            poll_entry->events = POLLIN;
            poll_entry++;
        }

        /* wait for events on each HTTP handle */
        c = first_http_ctx;
        delay = 1000;
        while (c) 
		{
            int fd;
            fd = c->fd;
            switch(c->state) 
			{
            case HTTPSTATE_SEND_HEADER:
            case RTSPSTATE_SEND_REPLY:
            case RTSPSTATE_SEND_PACKET:
                c->poll_entry = poll_entry;
                poll_entry->fd = fd;
                poll_entry->events = POLLOUT;
                poll_entry++;
                break;
            case HTTPSTATE_SEND_DATA_HEADER:
            case HTTPSTATE_SEND_DATA:
            case HTTPSTATE_SEND_DATA_TRAILER:
                if (!c->is_packetized) 
				{
                    /* for TCP, we output as much as we can
                     * (may need to put a limit) */
                    c->poll_entry = poll_entry;
                    poll_entry->fd = fd;
                    poll_entry->events = POLLOUT;
                    poll_entry++;
                } 
				else 
				{
                    /* when ffserver is doing the timing, we work by
                     * looking at which packet needs to be sent every
                     * 10 ms (one tick wait XXX: 10 ms assumed) */
                    if (delay > 10)
                        delay = 10;
                }
                break;
            case HTTPSTATE_WAIT_REQUEST:
            case HTTPSTATE_RECEIVE_DATA:
            case HTTPSTATE_WAIT_FEED:
            case RTSPSTATE_WAIT_REQUEST:
                /* need to catch errors */
                c->poll_entry = poll_entry;
                poll_entry->fd = fd;
                poll_entry->events = POLLIN;/* Maybe this will work */
                poll_entry++;
                break;
            default:
                c->poll_entry = NULL;
                break;
            }
            c = c->next;
        }

        /* wait for an event on one connection. We poll at least every
         * second to handle timeouts */
        do {
            ret = WSAPoll(poll_table, poll_entry - poll_table, delay);
            if (ret < 0 && ff_neterrno() != AVERROR(EAGAIN) &&
                ff_neterrno() != AVERROR(EINTR)) {
                goto quit;
            }
        } while (ret < 0);

		////TRACE("STREAMING. %d \n", fStop);
		if (!fStop)
		{
			cur_time = av_gettime() / 1000;

			if (need_to_start_children) {
				need_to_start_children = 0;
			}

			/* now handle the events */
			for (c = first_http_ctx; c; c = c_next) {
				c_next = c->next;
				if (handle_connection(c) < 0)
				{
					//log_connection(c);
					/* close and free the connection */
					close_connection(c);
				}
			}

			poll_entry = poll_table;
			/*        if (server_fd) {
						/* new HTTP connection request ? */
			/*            if (poll_entry->revents & POLLIN)
							new_connection(server_fd, 0);
							poll_entry++;
							} */
			if (rtsp_server_fd) {
				/* new RTSP connection request ? */
				if (poll_entry->revents & POLLIN)
					new_connection(rtsp_server_fd, 1);
			}
		}
		else
		{
			for (c = first_http_ctx; c; c = c_next) 
			{
				c_next = c->next;
				{
					close_connection(c);
				}
			}

			closesocket(rtsp_server_fd);
			break;
		}
    }

quit:
    av_free(poll_table);
    return 0;
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

void CFFStreamServer::http_send_too_busy_reply(int fd)
{
    char buffer[400];
    int len = snprintf(buffer, sizeof(buffer),
                       "HTTP/1.0 503 Server too busy\r\n"
                       "Content-type: text/html\r\n"
                       "\r\n"
                       "<!DOCTYPE html>\n"
                       "<html><head><title>Too busy</title></head><body>\r\n"
                       "<p>The server is too busy to serve your request at "
                       "this time.</p>\r\n"
                       "<p>The number of current connections is %u, and this "
                       "exceeds the limit of %u.</p>\r\n"
                       "</body></html>\r\n",
                       nb_connections, config.nb_max_connections);
    av_assert0(len < sizeof(buffer));
	if (send(fd, buffer, len, 0) < len)
	{
		av_log(NULL, AV_LOG_WARNING, "Could not send too-busy reply, send() failed\n");
		TRACE("Could not send too-busy reply, send() failed\n");
	}
}

void CFFStreamServer::new_connection(int server_fd, int is_rtsp)
{
    struct sockaddr_in from_addr;
    socklen_t len;
    int fd;
    HTTPContext *c = NULL;

    len = sizeof(from_addr);
    fd = accept(server_fd, (struct sockaddr *)&from_addr, &len);
    if (fd < 0) 
	{
//        http_log("error during accept %s\n", strerror(errno));
		TRACE("error during accept %s\n", strerror(errno));
        return;
    }
	if (ff_socket_nonblock(fd, 1) < 0)
	{
		av_log(NULL, AV_LOG_WARNING, "ff_socket_nonblock failed\n");
		TRACE("ff_socket_nonblock failed\n");
	}

    if (nb_connections >= config.nb_max_connections) {
        http_send_too_busy_reply(fd);
        goto fail;
    }

    /* add a new connection */
    c = (HTTPContext *)av_mallocz(sizeof(HTTPContext));
    if (!c)
        goto fail;

    c->fd = fd;
    c->poll_entry = NULL;
    c->from_addr = from_addr;
    c->buffer_size = IOBUFFER_INIT_SIZE;
    c->buffer = (uint8_t*)av_malloc(c->buffer_size);
    if (!c->buffer)
        goto fail;

    c->next = first_http_ctx;
    first_http_ctx = c;
    nb_connections++;

    start_wait_request(c, is_rtsp);

    return;

 fail:
    if (c) {
        av_freep(&c->buffer);
        av_free(c);
    }
    closesocket(fd);
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
        /* for packetized output, we consider we can always write (the
         * input streams set the speed). It may be better to verify
         * that we do not rely too much on the kernel queues */
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
    case HTTPSTATE_RECEIVE_DATA:
        /* no need to read if no events */
/*        if (c->poll_entry->revents & (POLLERR | POLLHUP))
            return -1;
        if (!(c->poll_entry->revents & POLLIN))
            return 0;
        if (http_receive_data(c) < 0)
            return -1; */
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

int CFFStreamServer::find_stream_in_feed(FFServerStream *feed, AVCodecContext *codec, int bit_rate)
{
    int i;
    int best_bitrate = 100000000;
    int best = -1;

    for (i = 0; i < feed->nb_streams; i++) {
        AVCodecContext *feed_codec = feed->streams[i]->codec;

        if (feed_codec->codec_id != codec->codec_id ||
            feed_codec->sample_rate != codec->sample_rate ||
            feed_codec->width != codec->width ||
            feed_codec->height != codec->height)
            continue;

        /* Potential stream */

        /* We want the fastest stream less than bit_rate, or the slowest
         * faster than bit_rate
         */

        if (feed_codec->bit_rate <= bit_rate) {
            if (best_bitrate > bit_rate ||
                feed_codec->bit_rate > best_bitrate) {
                best_bitrate = feed_codec->bit_rate;
                best = i;
            }
            continue;
        }
        if (feed_codec->bit_rate < best_bitrate) {
            best_bitrate = feed_codec->bit_rate;
            best = i;
        }
    }
    return best;
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
 //       http_log("Could not find stream info for input '%s'\n", input_filename);
        avformat_close_input(&s);
        return ret;
    }

    /* choose stream as clock source (we favor the video stream if
     * present) for packet sending */
    c->pts_stream_index = 0;
    for(i=0;i<c->stream->nb_streams;i++) {
        if (c->pts_stream_index == 0 &&
            c->stream->streams[i]->codec->codec_type == AVMEDIA_TYPE_VIDEO) {
            c->pts_stream_index = i;
        }
    }

    if (c->fmt_in->iformat->read_seek)
        av_seek_frame(c->fmt_in, -1, stream_pos, 0);
    /* set the start time (needed for maxtime and RTP packet timing) */
    c->start_time = cur_time;
    c->first_pts = AV_NOPTS_VALUE;
    return 0;
}

/* return the server clock (in us) */
int64_t CFFStreamServer::get_server_clock(HTTPContext *c)
{
    /* compute current pts value from system time */
    return (cur_time - c->start_time) * 1000;
}

/* return the estimated time (in us) at which the current packet must be sent */
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

int CFFStreamServer::http_prepare_data(HTTPContext *c)
{
    int i, len, ret;
    AVFormatContext *ctx;

    av_freep(&c->pb_buffer);
    switch(c->state) {
    case HTTPSTATE_SEND_DATA_HEADER:
        ctx = avformat_alloc_context();
        if (!ctx)
            return AVERROR(ENOMEM);
        c->fmt_ctx = *ctx;
        av_freep(&ctx);
        av_dict_copy(&(c->fmt_ctx.metadata), c->stream->metadata, 0);
        c->fmt_ctx.streams = (AVStream**)av_mallocz_array(c->stream->nb_streams,   sizeof(AVStream *));
        if (!c->fmt_ctx.streams)
            return AVERROR(ENOMEM);

        for(i=0;i<c->stream->nb_streams;i++) {
            AVStream *src;
            c->fmt_ctx.streams[i] = (AVStream*)av_mallocz(sizeof(AVStream));

            /* if file or feed, then just take streams from FFServerStream
             * struct */
            if (!c->stream->feed ||
                c->stream->feed == c->stream)
                src = c->stream->streams[i];
            else
                src = c->stream->feed->streams[c->stream->feed_streams[i]];

            *(c->fmt_ctx.streams[i]) = *src;
            c->fmt_ctx.streams[i]->priv_data = 0;
            /* XXX: should be done in AVStream, not in codec */
            c->fmt_ctx.streams[i]->codec->frame_number = 0;
        }
        /* set output format parameters */
        c->fmt_ctx.oformat = c->stream->fmt;
        c->fmt_ctx.nb_streams = c->stream->nb_streams;

        c->got_key_frame = 0;

        /* prepare header and save header data in a stream */
        if (avio_open_dyn_buf(&c->fmt_ctx.pb) < 0) {
            /* XXX: potential leak */
            return -1;
        }
        c->fmt_ctx.pb->seekable = 0;

        /*
         * HACK to avoid MPEG-PS muxer to spit many underflow errors
         * Default value from FFmpeg
         * Try to set it using configuration option
         */
        c->fmt_ctx.max_delay = (int)(0.7*AV_TIME_BASE);

        if ((ret = avformat_write_header(&c->fmt_ctx, NULL)) < 0) {
//            http_log("Error writing output header for stream '%s': \n",  c->stream->filename);
            return ret;
        }
        av_dict_free(&c->fmt_ctx.metadata);

        len = avio_close_dyn_buf(c->fmt_ctx.pb, &c->pb_buffer);
        c->buffer_ptr = c->pb_buffer;
        c->buffer_end = c->pb_buffer + len;

        c->state = HTTPSTATE_SEND_DATA;
        c->last_packet_sent = 0;
        break;
    case HTTPSTATE_SEND_DATA:
        /* find a new packet */
        /* read a packet from the input stream */
        if (c->stream->feed)
            ffm_set_write_index(c->fmt_in,
                                c->stream->feed->feed_write_index,
                                c->stream->feed->feed_size);

        if (c->stream->max_time &&
            c->stream->max_time + c->start_time - cur_time < 0)
            /* We have timed out */
            c->state = HTTPSTATE_SEND_DATA_TRAILER;
        else {
            AVPacket pkt;
        redo:
            ret = av_read_frame(c->fmt_in, &pkt);
            if (ret < 0) {
                if (c->stream->feed) {
                    /* if coming from feed, it means we reached the end of the
                     * ffm file, so must wait for more data */
                    c->state = HTTPSTATE_WAIT_FEED;
                    return 1; /* state changed */
                }
                if (ret == AVERROR(EAGAIN)) {
                    /* input not ready, come back later */
                    return 0;
                }
                if (c->stream->loop) {
                    avformat_close_input(&c->fmt_in);
                    if (open_input_stream(c, "") < 0)
                        goto no_loop;
                    goto redo;
                } else {
                    no_loop:
                        /* must send trailer now because EOF or error */
                        c->state = HTTPSTATE_SEND_DATA_TRAILER;
                }
            } else {
                int source_index = pkt.stream_index;
                /* update first pts if needed */
                if (c->first_pts == AV_NOPTS_VALUE && pkt.dts != AV_NOPTS_VALUE) {
					AVRational tmpTB;
					tmpTB.num = 1; tmpTB.den = AV_TIME_BASE;
					c->first_pts = av_rescale_q(pkt.dts, c->fmt_in->streams[pkt.stream_index]->time_base, tmpTB);
                    c->start_time = cur_time;
                }
                /* send it to the appropriate stream */
                if (c->stream->feed) {
                    /* if coming from a feed, select the right stream */
                    if (c->switch_pending) {
                        c->switch_pending = 0;
                        for(i=0;i<c->stream->nb_streams;i++) {
                            if (c->switch_feed_streams[i] == pkt.stream_index)
                                if (pkt.flags & AV_PKT_FLAG_KEY)
                                    c->switch_feed_streams[i] = -1;
                            if (c->switch_feed_streams[i] >= 0)
                                c->switch_pending = 1;
                        }
                    }
                    for(i=0;i<c->stream->nb_streams;i++) {
                        if (c->stream->feed_streams[i] == pkt.stream_index) {
                            AVStream *st = c->fmt_in->streams[source_index];
                            pkt.stream_index = i;
                            if (pkt.flags & AV_PKT_FLAG_KEY &&
                                (st->codec->codec_type == AVMEDIA_TYPE_VIDEO ||
                                 c->stream->nb_streams == 1))
                                c->got_key_frame = 1;
                            if (!c->stream->send_on_key || c->got_key_frame)
                                goto send_it;
                        }
                    }
                } else {
                    AVCodecContext *codec;
                    AVStream *ist, *ost;
                send_it:
                    ist = c->fmt_in->streams[source_index];
                    /* specific handling for RTP: we use several
                     * output streams (one for each RTP connection).
                     * XXX: need more abstract handling */
                    if (c->is_packetized) {
                        /* compute send time and duration */
                        if (pkt.dts != AV_NOPTS_VALUE) {
							AVRational tmpTB;
							tmpTB.num = 1; tmpTB.den = AV_TIME_BASE;
                            c->cur_pts = av_rescale_q(pkt.dts, ist->time_base, tmpTB);
                            c->cur_pts -= c->first_pts;
                        }
						AVRational tmpTB;
						tmpTB.num = 1; tmpTB.den = AV_TIME_BASE;
                        c->cur_frame_duration = av_rescale_q(pkt.duration, ist->time_base, tmpTB);
                        /* find RTP context */
                        c->packet_stream_index = pkt.stream_index;
                        ctx = c->rtp_ctx[c->packet_stream_index];
                        if(!ctx) {
                            av_packet_unref(&pkt);
                            break;
                        }
                        codec = ctx->streams[0]->codec;
                        /* only one stream per RTP connection */
                        pkt.stream_index = 0;
                    } else {
                        ctx = &c->fmt_ctx;
                        /* Fudge here */
                        codec = ctx->streams[pkt.stream_index]->codec;
                    }

                    if (c->is_packetized) {
                        int max_packet_size;
                        if (c->rtp_protocol == RTSP_LOWER_TRANSPORT_TCP)
                            max_packet_size = RTSP_TCP_MAX_PACKET_SIZE;
                        else
                            max_packet_size = c->rtp_handles[c->packet_stream_index]->max_packet_size;
                        ret = ffio_open_dyn_packet_buf(&ctx->pb,
                                                       max_packet_size);
                    } else
                        ret = avio_open_dyn_buf(&ctx->pb);

                    if (ret < 0) {
                        /* XXX: potential leak */
                        return -1;
                    }
                    ost = ctx->streams[pkt.stream_index];

                    ctx->pb->seekable = 0;
                    if (pkt.dts != AV_NOPTS_VALUE)
                        pkt.dts = av_rescale_q(pkt.dts, ist->time_base,
                                               ost->time_base);
                    if (pkt.pts != AV_NOPTS_VALUE)
                        pkt.pts = av_rescale_q(pkt.pts, ist->time_base,
                                               ost->time_base);
                    pkt.duration = av_rescale_q(pkt.duration, ist->time_base,
                                                ost->time_base);
                    if ((ret = av_write_frame(ctx, &pkt)) < 0) {
//                        http_log("Error writing frame to output for stream '%s': \n", c->stream->filename);
                        c->state = HTTPSTATE_SEND_DATA_TRAILER;
                    }

                    av_freep(&c->pb_buffer);
                    len = avio_close_dyn_buf(ctx->pb, &c->pb_buffer);
                    ctx->pb = NULL;
                    c->cur_frame_bytes = len;
                    c->buffer_ptr = c->pb_buffer;
                    c->buffer_end = c->pb_buffer + len;

                    codec->frame_number++;
                    if (len == 0) {
                        av_packet_unref(&pkt);
                        goto redo;
                    }
                }
                av_packet_unref(&pkt);
            }
        }
        break;
    default:
    case HTTPSTATE_SEND_DATA_TRAILER:
        /* last packet test ? */
        if (c->last_packet_sent || c->is_packetized)
            return -1;
        ctx = &c->fmt_ctx;
        /* prepare header */
        if (avio_open_dyn_buf(&ctx->pb) < 0) {
            /* XXX: potential leak */
            return -1;
        }
        c->fmt_ctx.pb->seekable = 0;
        av_write_trailer(ctx);
        len = avio_close_dyn_buf(ctx->pb, &c->pb_buffer);
        c->buffer_ptr = c->pb_buffer;
        c->buffer_end = c->pb_buffer + len;

        c->last_packet_sent = 1;
        break;
    }
    return 0;
}

/* should convert the format at the same time */
/* send data starting at c->buffer_ptr to the output connection
 * (either UDP or TCP)
 */
int CFFStreamServer::http_send_data(HTTPContext *c)
{
    int len, ret;

    for(;;) 
	{
		if (fStop)
			return 0;

        if (c->buffer_ptr >= c->buffer_end) 
		{
            ret = http_prepare_data(c);
            if (ret < 0)
                return -1;
            else if (ret)
                /* state change requested */
                break;
        } 
		else 
		{
            if (c->is_packetized) 
			{
                /* RTP data output */
                len = c->buffer_end - c->buffer_ptr;
                if (len < 4) 
				{
                    /* fail safe - should never happen */
                fail1:
                    c->buffer_ptr = c->buffer_end;
                    return 0;
                }
                len = (c->buffer_ptr[0] << 24) | (c->buffer_ptr[1] << 16) | (c->buffer_ptr[2] << 8) | (c->buffer_ptr[3]);
                if (len > (c->buffer_end - c->buffer_ptr))
                    goto fail1;
                if ((get_packet_send_clock(c) - get_server_clock(c)) > 0) 
				{
                    /* nothing to send yet: we can wait */
                    return 0;
                }

                c->data_count += len;
                update_datarate(&c->datarate, c->data_count);
                if (c->stream)
                    c->stream->bytes_served += len;

                if (c->rtp_protocol == RTSP_LOWER_TRANSPORT_TCP) 
				{
                    /* RTP packets are sent inside the RTSP TCP connection */
                    AVIOContext *pb;
                    int interleaved_index, size;
                    uint8_t header[4];
                    HTTPContext *rtsp_c;

                    rtsp_c = c->rtsp_c;
                    /* if no RTSP connection left, error */
                    if (!rtsp_c)
                        return -1;
                    /* if already sending something, then wait. */
                    if (rtsp_c->state != RTSPSTATE_WAIT_REQUEST)
                        break;
                    if (avio_open_dyn_buf(&pb) < 0)
                        goto fail1;
                    interleaved_index = c->packet_stream_index * 2;
                    /* RTCP packets are sent at odd indexes */
                    if (c->buffer_ptr[1] == 200)
                        interleaved_index++;
                    /* write RTSP TCP header */
                    header[0] = '$';
                    header[1] = interleaved_index;
                    header[2] = len >> 8;
                    header[3] = len;
                    avio_write(pb, header, 4);
                    /* write RTP packet data */
                    c->buffer_ptr += 4;
                    avio_write(pb, c->buffer_ptr, len);
                    size = avio_close_dyn_buf(pb, &c->packet_buffer);
                    /* prepare asynchronous TCP sending */
                    rtsp_c->packet_buffer_ptr = c->packet_buffer;
                    rtsp_c->packet_buffer_end = c->packet_buffer + size;
                    c->buffer_ptr += len;

                    /* send everything we can NOW */
                    len = send(rtsp_c->fd, (const char *)(rtsp_c->packet_buffer_ptr),
                               rtsp_c->packet_buffer_end - rtsp_c->packet_buffer_ptr, 0);
                    if (len > 0)
                        rtsp_c->packet_buffer_ptr += len;
                    if (rtsp_c->packet_buffer_ptr < rtsp_c->packet_buffer_end) 
					{
                        /* if we could not send all the data, we will
                         * send it later, so a new state is needed to
                         * "lock" the RTSP TCP connection */
                        rtsp_c->state = RTSPSTATE_SEND_PACKET;
                        break;
                    } else
                        /* all data has been sent */
                        av_freep(&c->packet_buffer);
                } 
				else 
				{
                    /* send RTP packet directly in UDP */
                    c->buffer_ptr += 4;
                    ffurl_write(c->rtp_handles[c->packet_stream_index],
                                c->buffer_ptr, len);
                    c->buffer_ptr += len;
                    /* here we continue as we can send several packets
                     * per 10 ms slot */
                }
            } else {
                /* TCP data output */
                len = send(c->fd, (const char*)(c->buffer_ptr), c->buffer_end - c->buffer_ptr, 0);
                if (len < 0) {
                    if (ff_neterrno() != AVERROR(EAGAIN) && ff_neterrno() != AVERROR(EINTR))
                        /* error : close connection */
                        return -1;
                    else
                        return 0;
                }
                c->buffer_ptr += len;

                c->data_count += len;
                update_datarate(&c->datarate, c->data_count);
                if (c->stream)
                    c->stream->bytes_served += len;
                break;
            }
        }
    } /* for(;;) */

    return 0;
}



/********************************************************************/
/* RTSP handling */

void CFFStreamServer::rtsp_reply_header(HTTPContext *c, enum RTSPStatusCode error_number)
{
    const char *str;
    time_t ti;
    struct tm *tm;
    char buf2[32];

    str = RTSP_STATUS_CODE2STRING(error_number);
    if (!str)
        str = "Unknown Error";

	avio_printf(c->pb, "RTSP/1.0 %d %s\r\n", error_number, str);
	
	avio_printf(c->pb, "CSeq: %d\r\n", c->seq);

    /* output GMT time */
    ti = time(NULL);
    tm = gmtime(&ti);
    strftime(buf2, sizeof(buf2), "%a, %d %b %Y %H:%M:%S", tm);
    avio_printf(c->pb, "Date: %s GMT\r\n", buf2);
}

void CFFStreamServer::rtsp_reply_error(HTTPContext *c, enum RTSPStatusCode error_number)
{
    rtsp_reply_header(c, error_number);
    avio_printf(c->pb, "\r\n");
}

int CFFStreamServer::rtsp_parse_request(HTTPContext *c)
{
    const char *p, *p1, *p2;
    char cmd[32];
    char url[1024];
    char protocol[32];
    char line[1024];
    int len;
    RTSPMessageHeader header1 = { 0 }, *header = &header1;

    c->buffer_ptr[0] = '\0';
    p = (const char*)(c->buffer);

    get_word(cmd, sizeof(cmd), &p);
    get_word(url, sizeof(url), &p);
    get_word(protocol, sizeof(protocol), &p);

    av_strlcpy(c->method, cmd, sizeof(c->method));
    av_strlcpy(c->url, url, sizeof(c->url));
    av_strlcpy(c->protocol, protocol, sizeof(c->protocol));

    if (avio_open_dyn_buf(&c->pb) < 0) {
        /* XXX: cannot do more */
        c->pb = NULL; /* safety */
        return -1;
    }

    /* check version name */
    if (strcmp(protocol, "RTSP/1.0")) {
        rtsp_reply_error(c, RTSP_STATUS_VERSION);
        goto the_end;
    }

    /* parse each header line */
    /* skip to next line */
    while (*p != '\n' && *p != '\0')
        p++;
    if (*p == '\n')
        p++;
    while (*p != '\0') {
        p1 = (const char*)(memchr(p, '\n', (char *)c->buffer_ptr - p));
        if (!p1)
            break;
        p2 = p1;
        if (p2 > p && p2[-1] == '\r')
            p2--;
        /* skip empty line */
        if (p2 == p)
            break;
        len = p2 - p;
        if (len > sizeof(line) - 1)
            len = sizeof(line) - 1;
        memcpy(line, p, len);
        line[len] = '\0';
        ff_rtsp_parse_line(NULL, header, line, NULL, NULL);
        p = p1 + 1;
    }

    /* handle sequence number */
    c->seq = header->seq;

    if (!strcmp(cmd, "DESCRIBE"))
        rtsp_cmd_describe(c, url);
    else if (!strcmp(cmd, "OPTIONS"))
        rtsp_cmd_options(c, url);
    else if (!strcmp(cmd, "SETUP"))
        rtsp_cmd_setup(c, url, header);
    else if (!strcmp(cmd, "PLAY"))
        rtsp_cmd_play(c, url, header);
    else if (!strcmp(cmd, "PAUSE"))
        rtsp_cmd_interrupt(c, url, header, 1);
    else if (!strcmp(cmd, "TEARDOWN"))
        rtsp_cmd_interrupt(c, url, header, 0);
    else
        rtsp_reply_error(c, RTSP_STATUS_METHOD);

 the_end:
    len = avio_close_dyn_buf(c->pb, &c->pb_buffer);
    c->pb = NULL; /* safety */
    if (len < 0)
        /* XXX: cannot do more */
        return -1;

    c->buffer_ptr = c->pb_buffer;
    c->buffer_end = c->pb_buffer + len;
    c->state = RTSPSTATE_SEND_REPLY;
    return 0;
}

int CFFStreamServer::prepare_sdp_description(FFServerStream *stream, uint8_t **pbuffer,
                                   struct in_addr my_ip)
{
    AVFormatContext *avc;
    AVStream *avs = NULL;
    AVOutputFormat *rtp_format = av_guess_format("rtp", NULL, NULL);
    AVDictionaryEntry *entry = av_dict_get(stream->metadata, "title", NULL, 0);
    int i;

    *pbuffer = NULL;

    avc =  avformat_alloc_context();
    if (!avc || !rtp_format)
        return -1;

    avc->oformat = rtp_format;
    av_dict_set(&avc->metadata, "title",
                entry ? entry->value : "No Title", 0);
    avc->nb_streams = stream->nb_streams;
    if (stream->is_multicast) {
        snprintf(avc->filename, 1024, "rtp://%s:%d?multicast=1?ttl=%d",
                 inet_ntoa(stream->multicast_ip),
                 stream->multicast_port, stream->multicast_ttl);
    } else
        snprintf(avc->filename, 1024, "rtp://0.0.0.0");

    avc->streams = (AVStream**)av_malloc_array(avc->nb_streams, sizeof(*avc->streams));
    if (!avc->streams)
        goto sdp_done;

    avs = (AVStream*)av_malloc_array(avc->nb_streams, sizeof(*avs));
    if (!avs)
        goto sdp_done;

    for(i = 0; i < stream->nb_streams; i++) {
        avc->streams[i] = &avs[i];
        avc->streams[i]->codec = stream->streams[i]->codec;
        avcodec_parameters_from_context(stream->streams[i]->codecpar, stream->streams[i]->codec);
        avc->streams[i]->codecpar = stream->streams[i]->codecpar;
    }
    *pbuffer = (uint8_t*)av_mallocz(2048);
    if (!*pbuffer)
        goto sdp_done;
    av_sdp_create(&avc, 1, (char*)(*pbuffer), 2048);

 sdp_done:
    av_freep(&avc->streams);
    av_dict_free(&avc->metadata);
    av_free(avc);
    av_free(avs);

    return *pbuffer ? strlen((char*)(*pbuffer)) : AVERROR(ENOMEM);
}

void CFFStreamServer::rtsp_cmd_options(HTTPContext *c, const char *url)
{
    /* rtsp_reply_header(c, RTSP_STATUS_OK); */
    avio_printf(c->pb, "RTSP/1.0 %d %s\r\n", RTSP_STATUS_OK, "OK");
    avio_printf(c->pb, "CSeq: %d\r\n", c->seq);
    avio_printf(c->pb, "Public: %s\r\n",
                "OPTIONS, DESCRIBE, SETUP, TEARDOWN, PLAY, PAUSE");
    avio_printf(c->pb, "\r\n");
}

void CFFStreamServer::rtsp_cmd_describe(HTTPContext *c, const char *url)
{
    FFServerStream *stream;
    char path1[1024];
    const char *path;
    uint8_t *content;
    int content_length;
    socklen_t len;
    struct sockaddr_in my_addr;

    /* find which URL is asked */
    av_url_split(NULL, 0, NULL, 0, NULL, 0, NULL, path1, sizeof(path1), url);
    path = path1;
    if (*path == '/')
        path++;

    for(stream = config.first_stream; stream; stream = stream->next) {
        if (!stream->is_feed &&
            stream->fmt && !strcmp(stream->fmt->name, "rtp") &&
            !strcmp(path, stream->filename)) {
            goto found;
        }
    }
    /* no stream found */
    rtsp_reply_error(c, RTSP_STATUS_NOT_FOUND);
    return;

 found:
    /* prepare the media description in SDP format */

    /* get the host IP */
    len = sizeof(my_addr);
    getsockname(c->fd, (struct sockaddr *)&my_addr, &len);
    content_length = prepare_sdp_description(stream, &content,
                                             my_addr.sin_addr);
    if (content_length < 0) {
        rtsp_reply_error(c, RTSP_STATUS_INTERNAL);
        return;
    }
    rtsp_reply_header(c, RTSP_STATUS_OK);
    avio_printf(c->pb, "Content-Base: %s/\r\n", url);
    avio_printf(c->pb, "Content-Type: application/sdp\r\n");
    avio_printf(c->pb, "Content-Length: %d\r\n", content_length);
    avio_printf(c->pb, "\r\n");
    avio_write(c->pb, content, content_length);
    av_free(content);
}

HTTPContext * CFFStreamServer::find_rtp_session(const char *session_id)
{
    HTTPContext *c;

    if (session_id[0] == '\0')
        return NULL;

    for(c = first_http_ctx; c; c = c->next) {
        if (!strcmp(c->session_id, session_id))
            return c;
    }
    return NULL;
}

RTSPTransportField * CFFStreamServer::find_transport(RTSPMessageHeader *h, enum RTSPLowerTransport lower_transport)
{
    RTSPTransportField *th;
    int i;

    for(i=0;i<h->nb_transports;i++) {
        th = &h->transports[i];
        if (th->lower_transport == lower_transport)
            return th;
    }
    return NULL;
}

void CFFStreamServer::rtsp_cmd_setup(HTTPContext *c, const char *url, RTSPMessageHeader *h)
{
    FFServerStream *stream;
    int stream_index, rtp_port, rtcp_port;
    char buf[1024];
    char path1[1024];
    const char *path;
    HTTPContext *rtp_c;
    RTSPTransportField *th;
    struct sockaddr_in dest_addr;
    RTSPActionServerSetup setup;

    /* find which URL is asked */
    av_url_split(NULL, 0, NULL, 0, NULL, 0, NULL, path1, sizeof(path1), url);
    path = path1;
    if (*path == '/')
        path++;

    /* now check each stream */
    for(stream = config.first_stream; stream; stream = stream->next) {
        if (stream->is_feed || !stream->fmt ||
            strcmp(stream->fmt->name, "rtp")) {
            continue;
        }
        /* accept aggregate filenames only if single stream */
        if (!strcmp(path, stream->filename)) {
            if (stream->nb_streams != 1) {
                rtsp_reply_error(c, RTSP_STATUS_AGGREGATE);
                return;
            }
            stream_index = 0;
            goto found;
        }

        for(stream_index = 0; stream_index < stream->nb_streams;
            stream_index++) {
            snprintf(buf, sizeof(buf), "%s/streamid=%d",
                     stream->filename, stream_index);
            if (!strcmp(path, buf))
                goto found;
        }
    }
    /* no stream found */
    rtsp_reply_error(c, RTSP_STATUS_SERVICE); /* XXX: right error ? */
    return;
 found:

    /* generate session id if needed */
    if (h->session_id[0] == '\0') {
        unsigned random0 = av_lfg_get(&random_state);
        unsigned random1 = av_lfg_get(&random_state);
        snprintf(h->session_id, sizeof(h->session_id), "%08x%08x",
                 random0, random1);
    }

    /* find RTP session, and create it if none found */
    rtp_c = find_rtp_session(h->session_id);
    if (!rtp_c) {
        /* always prefer TCP */
        th = find_transport(h, RTSP_LOWER_TRANSPORT_TCP);
        if (!th) {
            th = find_transport(h, RTSP_LOWER_TRANSPORT_UDP);
            if (!th) {
                rtsp_reply_error(c, RTSP_STATUS_TRANSPORT);
                return;
            }
        }

        rtp_c = rtp_new_connection(&c->from_addr, stream, h->session_id,
                                   th->lower_transport);
        if (!rtp_c) {
            rtsp_reply_error(c, RTSP_STATUS_BANDWIDTH);
            return;
        }

        /* open input stream */
        if (open_input_stream(rtp_c, "") < 0) {
            rtsp_reply_error(c, RTSP_STATUS_INTERNAL);
            return;
        }
    }

    /* test if stream is OK (test needed because several SETUP needs
     * to be done for a given file) */
    if (rtp_c->stream != stream) {
        rtsp_reply_error(c, RTSP_STATUS_SERVICE);
        return;
    }

    /* test if stream is already set up */
    if (rtp_c->rtp_ctx[stream_index]) {
        rtsp_reply_error(c, RTSP_STATUS_STATE);
        return;
    }

    /* check transport */
    th = find_transport(h, rtp_c->rtp_protocol);
    if (!th || (th->lower_transport == RTSP_LOWER_TRANSPORT_UDP &&
                th->client_port_min <= 0)) {
        rtsp_reply_error(c, RTSP_STATUS_TRANSPORT);
        return;
    }

    /* setup default options */
    setup.transport_option[0] = '\0';
    dest_addr = rtp_c->from_addr;
    dest_addr.sin_port = htons(th->client_port_min);

    /* setup stream */
    if (rtp_new_av_stream(rtp_c, stream_index, &dest_addr, c) < 0) {
        rtsp_reply_error(c, RTSP_STATUS_TRANSPORT);
        return;
    }

    /* now everything is OK, so we can send the connection parameters */
    rtsp_reply_header(c, RTSP_STATUS_OK);
    /* session ID */
    avio_printf(c->pb, "Session: %s\r\n", rtp_c->session_id);

    switch(rtp_c->rtp_protocol) {
    case RTSP_LOWER_TRANSPORT_UDP:
        rtp_port = ff_rtp_get_local_rtp_port(rtp_c->rtp_handles[stream_index]);
        rtcp_port = ff_rtp_get_local_rtcp_port(rtp_c->rtp_handles[stream_index]);
        avio_printf(c->pb, "Transport: RTP/AVP/UDP;unicast;"
                    "client_port=%d-%d;server_port=%d-%d",
                    th->client_port_min, th->client_port_max,
                    rtp_port, rtcp_port);
        break;
    case RTSP_LOWER_TRANSPORT_TCP:
        avio_printf(c->pb, "Transport: RTP/AVP/TCP;interleaved=%d-%d",
                    stream_index * 2, stream_index * 2 + 1);
        break;
    default:
        break;
    }
    if (setup.transport_option[0] != '\0')
        avio_printf(c->pb, ";%s", setup.transport_option);
    avio_printf(c->pb, "\r\n");


    avio_printf(c->pb, "\r\n");
}

/**
 * find an RTP connection by using the session ID. Check consistency
 * with filename
 */
HTTPContext * CFFStreamServer::find_rtp_session_with_url(const char *url, const char *session_id)
{
    HTTPContext *rtp_c;
    char path1[1024];
    const char *path;
    char buf[1024];
    int s, len;

    rtp_c = find_rtp_session(session_id);
    if (!rtp_c)
        return NULL;

    /* find which URL is asked */
    av_url_split(NULL, 0, NULL, 0, NULL, 0, NULL, path1, sizeof(path1), url);
    path = path1;
    if (*path == '/')
        path++;
    if(!strcmp(path, rtp_c->stream->filename)) return rtp_c;
    for(s=0; s<rtp_c->stream->nb_streams; ++s) {
      snprintf(buf, sizeof(buf), "%s/streamid=%d",
        rtp_c->stream->filename, s);
      if(!strncmp(path, buf, sizeof(buf)))
        /* XXX: Should we reply with RTSP_STATUS_ONLY_AGGREGATE
         * if nb_streams>1? */
        return rtp_c;
    }
    len = strlen(path);
    if (len > 0 && path[len - 1] == '/' &&
        !strncmp(path, rtp_c->stream->filename, len - 1))
        return rtp_c;
    return NULL;
}

void CFFStreamServer::rtsp_cmd_play(HTTPContext *c, const char *url, RTSPMessageHeader *h)
{
    HTTPContext *rtp_c;

    rtp_c = find_rtp_session_with_url(url, h->session_id);
    if (!rtp_c) {
        rtsp_reply_error(c, RTSP_STATUS_SESSION);
        return;
    }

    if (rtp_c->state != HTTPSTATE_SEND_DATA &&
        rtp_c->state != HTTPSTATE_WAIT_FEED &&
        rtp_c->state != HTTPSTATE_READY) {
        rtsp_reply_error(c, RTSP_STATUS_STATE);
        return;
    }

    rtp_c->state = HTTPSTATE_SEND_DATA;

    /* now everything is OK, so we can send the connection parameters */
    rtsp_reply_header(c, RTSP_STATUS_OK);
    /* session ID */
    avio_printf(c->pb, "Session: %s\r\n", rtp_c->session_id);
    avio_printf(c->pb, "\r\n");
}

void CFFStreamServer::rtsp_cmd_interrupt(HTTPContext *c, const char *url,  RTSPMessageHeader *h, int pause_only)
{
    HTTPContext *rtp_c;

    rtp_c = find_rtp_session_with_url(url, h->session_id);
    if (!rtp_c) {
        rtsp_reply_error(c, RTSP_STATUS_SESSION);
        return;
    }

    if (pause_only) {
        if (rtp_c->state != HTTPSTATE_SEND_DATA &&
            rtp_c->state != HTTPSTATE_WAIT_FEED) {
            rtsp_reply_error(c, RTSP_STATUS_STATE);
            return;
        }
        rtp_c->state = HTTPSTATE_READY;
        rtp_c->first_pts = AV_NOPTS_VALUE;
    }

    /* now everything is OK, so we can send the connection parameters */
    rtsp_reply_header(c, RTSP_STATUS_OK);
    /* session ID */
    avio_printf(c->pb, "Session: %s\r\n", rtp_c->session_id);
    avio_printf(c->pb, "\r\n");

    if (!pause_only)
        close_connection(rtp_c);
}

/********************************************************************/
/* RTP handling */

HTTPContext * CFFStreamServer::rtp_new_connection(struct sockaddr_in *from_addr,  FFServerStream *stream,  const char *session_id,  enum RTSPLowerTransport rtp_protocol)
{
    HTTPContext *c = NULL;
    const char *proto_str;

    /* XXX: should output a warning page when coming
     * close to the connection limit */
    if (nb_connections >= config.nb_max_connections)
        goto fail;

    /* add a new connection */
    c = (HTTPContext*)av_mallocz(sizeof(HTTPContext));
    if (!c)
        goto fail;

    c->fd = -1;
    c->poll_entry = NULL;
    c->from_addr = *from_addr;
    c->buffer_size = IOBUFFER_INIT_SIZE;
    c->buffer = (uint8_t*)av_malloc(c->buffer_size);
    if (!c->buffer)
        goto fail;
    nb_connections++;
    c->stream = stream;
    av_strlcpy(c->session_id, session_id, sizeof(c->session_id));
    c->state = HTTPSTATE_READY;
    c->is_packetized = 1;
    c->rtp_protocol = rtp_protocol;

    /* protocol is shown in statistics */
    switch(c->rtp_protocol) {
    case RTSP_LOWER_TRANSPORT_UDP_MULTICAST:
        proto_str = "MCAST";
        break;
    case RTSP_LOWER_TRANSPORT_UDP:
        proto_str = "UDP";
        break;
    case RTSP_LOWER_TRANSPORT_TCP:
        proto_str = "TCP";
        break;
    default:
        proto_str = "???";
        break;
    }
    av_strlcpy(c->protocol, "RTP/", sizeof(c->protocol));
    av_strlcat(c->protocol, proto_str, sizeof(c->protocol));

    current_bandwidth += stream->bandwidth;

    c->next = first_http_ctx;
    first_http_ctx = c;
    return c;

 fail:
    if (c) {
        av_freep(&c->buffer);
        av_free(c);
    }
    return NULL;
}

/**
 * add a new RTP stream in an RTP connection (used in RTSP SETUP
 * command). If RTP/TCP protocol is used, TCP connection 'rtsp_c' is
 * used.
 */
int CFFStreamServer::rtp_new_av_stream(HTTPContext *c, int stream_index, struct sockaddr_in *dest_addr, HTTPContext *rtsp_c)
{
    AVFormatContext *ctx;
    AVStream *st;
    char *ipaddr;
    URLContext *h = NULL;
    uint8_t *dummy_buf;
    int max_packet_size;
    void *st_internal;

    /* now we can open the relevant output stream */
    ctx = avformat_alloc_context();
    if (!ctx)
        return -1;
    ctx->oformat = av_guess_format("rtp", NULL, NULL);

    st = avformat_new_stream(ctx, NULL);
    if (!st)
        goto fail;

    av_freep(&st->codec);
    av_freep(&st->info);
    st_internal = st->internal;

    if (!c->stream->feed ||
        c->stream->feed == c->stream)
        memcpy(st, c->stream->streams[stream_index], sizeof(AVStream));
    else
        memcpy(st,
               c->stream->feed->streams[c->stream->feed_streams[stream_index]],
               sizeof(AVStream));
    st->priv_data = NULL;
    st->internal = (AVStreamInternal*)(st_internal);

    /* build destination RTP address */
    ipaddr = inet_ntoa(dest_addr->sin_addr);

    switch(c->rtp_protocol) {
    case RTSP_LOWER_TRANSPORT_UDP:
    case RTSP_LOWER_TRANSPORT_UDP_MULTICAST:
        /* RTP/UDP case */

        /* XXX: also pass as parameter to function ? */
        if (c->stream->is_multicast) {
            int ttl;
            ttl = c->stream->multicast_ttl;
            if (!ttl)
                ttl = 16;
            snprintf(ctx->filename, sizeof(ctx->filename),
                     "rtp://%s:%d?multicast=1&ttl=%d",
                     ipaddr, ntohs(dest_addr->sin_port), ttl);
        } else {
            snprintf(ctx->filename, sizeof(ctx->filename),
                     "rtp://%s:%d", ipaddr, ntohs(dest_addr->sin_port));
        }

        if (ffurl_open(&h, ctx->filename, AVIO_FLAG_WRITE, NULL, NULL) < 0)
            goto fail;
        c->rtp_handles[stream_index] = h;
        max_packet_size = h->max_packet_size;
        break;
    case RTSP_LOWER_TRANSPORT_TCP:
        /* RTP/TCP case */
        c->rtsp_c = rtsp_c;
        max_packet_size = RTSP_TCP_MAX_PACKET_SIZE;
        break;
    default:
        goto fail;
    }

//    http_log("%s:%d - - \"PLAY %s/streamid=%d %s\"\n",  ipaddr, ntohs(dest_addr->sin_port), c->stream->filename, stream_index, c->protocol);

    /* normally, no packets should be output here, but the packet size may
     * be checked */
    if (ffio_open_dyn_packet_buf(&ctx->pb, max_packet_size) < 0)
        /* XXX: close stream */
        goto fail;

    if (avformat_write_header(ctx, NULL) < 0) {
    fail:
        if (h)
            ffurl_close(h);
        av_free(st);
        av_free(ctx);
        return -1;
    }
    avio_close_dyn_buf(ctx->pb, &dummy_buf);
    ctx->pb = NULL;
    av_free(dummy_buf);

    c->rtp_ctx[stream_index] = ctx;
    return 0;
}

/********************************************************************/
/* ffserver initialization */

/* FIXME: This code should use avformat_new_stream() */
AVStream * CFFStreamServer::add_av_stream1(FFServerStream *stream, AVCodecContext *codec, int copy)
{
    AVStream *fst;

    if(stream->nb_streams >= FF_ARRAY_ELEMS(stream->streams))
        return NULL;

    fst = (AVStream*)av_mallocz(sizeof(AVStream));
    if (!fst)
        return NULL;
    if (copy) {
        fst->codec = avcodec_alloc_context3(codec->codec);
        if (!fst->codec) {
            av_free(fst);
            return NULL;
        }
        avcodec_copy_context(fst->codec, codec);
    } else
        /* live streams must use the actual feed's codec since it may be
         * updated later to carry extradata needed by them.
         */
        fst->codec = codec;

    fst->priv_data = av_mallocz(sizeof(FeedData));
	fst->internal = (AVStreamInternal *)av_mallocz(sizeof(*fst->internal));
    fst->internal->avctx = avcodec_alloc_context3(NULL);
    fst->codecpar = avcodec_parameters_alloc();
    fst->index = stream->nb_streams;
    avpriv_set_pts_info(fst, 33, 1, 90000);
    fst->sample_aspect_ratio = codec->sample_aspect_ratio;
    stream->streams[stream->nb_streams++] = fst;
    return fst;
}

/* return the stream number in the feed */
int CFFStreamServer::add_av_stream(FFServerStream *feed, AVStream *st)
{
    AVStream *fst;
    AVCodecContext *av, *av1;
    int i;

    av = st->codec;
    for(i=0;i<feed->nb_streams;i++) {
        av1 = feed->streams[i]->codec;
        if (av1->codec_id == av->codec_id &&
            av1->codec_type == av->codec_type &&
            av1->bit_rate == av->bit_rate) {

            switch(av->codec_type) {
            case AVMEDIA_TYPE_AUDIO:
                if (av1->channels == av->channels &&
                    av1->sample_rate == av->sample_rate)
                    return i;
                break;
            case AVMEDIA_TYPE_VIDEO:
                if (av1->width == av->width &&
                    av1->height == av->height &&
                    av1->time_base.den == av->time_base.den &&
                    av1->time_base.num == av->time_base.num &&
                    av1->gop_size == av->gop_size)
                    return i;
                break;
            default:
                abort();
            }
        }
    }

    fst = add_av_stream1(feed, av, 0);
    if (!fst)
        return -1;
    if (av_stream_get_recommended_encoder_configuration(st))
        av_stream_set_recommended_encoder_configuration(fst,
            av_strdup(av_stream_get_recommended_encoder_configuration(st)));
    return feed->nb_streams - 1;
}

void CFFStreamServer::remove_stream(FFServerStream *stream)
{
    FFServerStream **ps;
    ps = &config.first_stream;
    while (*ps) {
        if (*ps == stream)
            *ps = (*ps)->next;
        else
            ps = &(*ps)->next;
    }
}

/* specific MPEG4 handling : we extract the raw parameters */
void CFFStreamServer::extract_mpeg4_header(AVFormatContext *infile)
{
    int mpeg4_count, i, size;
    AVPacket pkt;
    AVStream *st;
    const uint8_t *p;

    infile->flags |= AVFMT_FLAG_NOFILLIN | AVFMT_FLAG_NOPARSE;

	TRACE("*********************extract mpeg4 header Call in********************************\n");

    mpeg4_count = 0;
    for(i=0;i<infile->nb_streams;i++) {
        st = infile->streams[i];
        if (st->codec->codec_id == AV_CODEC_ID_MPEG4 &&
            st->codec->extradata_size == 0) {
            mpeg4_count++;
        }
    }
    if (!mpeg4_count)
        return;

    printf("MPEG4 without extra data: trying to find header in %s\n",
           infile->filename);
    while (mpeg4_count > 0) {
        if (av_read_frame(infile, &pkt) < 0)
            break;
        st = infile->streams[pkt.stream_index];
        if (st->codec->codec_id == AV_CODEC_ID_MPEG4 &&
            st->codec->extradata_size == 0) {
            av_freep(&st->codec->extradata);
            /* fill extradata with the header */
            /* XXX: we make hard suppositions here ! */
            p = pkt.data;
            while (p < pkt.data + pkt.size - 4) {
                /* stop when vop header is found */
                if (p[0] == 0x00 && p[1] == 0x00 &&
                    p[2] == 0x01 && p[3] == 0xb6) {
                    size = p - pkt.data;
                    st->codec->extradata = (uint8_t*)av_mallocz(size + AV_INPUT_BUFFER_PADDING_SIZE);
                    st->codec->extradata_size = size;
                    memcpy(st->codec->extradata, pkt.data, size);
                    break;
                }
                p++;
            }
            mpeg4_count--;
        }
        av_packet_unref(&pkt);
    }

	TRACE("*********************extract mpeg4 header Call out********************************\n");
}

/* compute the needed AVStream for each file */
void CFFStreamServer::build_file_streams(void)
{
    FFServerStream *stream;
    AVFormatContext *infile;
    int i, ret;

    /* gather all streams */
    for(stream = config.first_stream; stream; stream = stream->next) {
        infile = NULL;

        if (stream->stream_type != STREAM_TYPE_LIVE || stream->feed)
            continue;

        /* the stream comes from a file */
        /* try to open the file */
        /* open stream */


        /* specific case: if transport stream output to RTP,
         * we use a raw transport stream reader */
        if (stream->fmt && !strcmp(stream->fmt->name, "rtp"))
            av_dict_set(&stream->in_opts, "mpeg2ts_compute_pcr", "1", 0);

        if (!stream->feed_filename[0]) {
//            http_log("Unspecified feed file for stream '%s'\n", stream->filename);
            goto fail;
        }

//        http_log("Opening feed file '%s' for stream '%s'\n",  stream->feed_filename, stream->filename);

		av_dict_set(&stream->in_opts, "rtsp_transport", "tcp", 0);		
		av_dict_set(&stream->in_opts, "analyzeduration", "25000", 0); 
		av_dict_set(&stream->in_opts, "stimeout", "8000000", 0);
        ret = avformat_open_input(&infile, stream->feed_filename, stream->ifmt, &stream->in_opts);
		TRACE("*********************build file streams Call in after format open input=%d********************************\n", ret);
        if (ret < 0) {
//            http_log("Could not open '%s': \n", stream->feed_filename );
            /* remove stream (no need to spend more time on it) */
			TRACE("*********************build file streams Call in after format open input fail********************************\n");
        fail:
            remove_stream(stream);
        } else {
            /* find all the AVStreams inside and reference them in
             * 'stream' */
			TRACE("*********************build file streams Call in after format open input success********************************\n");
            if (avformat_find_stream_info(infile, NULL) < 0) {
				TRACE("*********************format find stream info failed********************************\n");
                avformat_close_input(&infile);
				
                goto fail;
            }
			TRACE("*********************format find stream info successed********************************\n");
            extract_mpeg4_header(infile);

            for(i=0;i<infile->nb_streams;i++)
                add_av_stream1(stream, infile->streams[i]->codec, 1);

            avformat_close_input(&infile);
			TRACE("*********************build file streams Call in after format close input********************************\n");
        }
    }
	TRACE("*********************build file streams Call out********************************\n");
}

/* compute the bandwidth used by each stream */
void CFFStreamServer::compute_bandwidth(void)
{
    unsigned bandwidth;
    int i;
    FFServerStream *stream;

    for(stream = config.first_stream; stream; stream = stream->next) 
	{
        bandwidth = 0;
        for(i=0;i<stream->nb_streams;i++) {
            AVStream *st = stream->streams[i];
            switch(st->codec->codec_type) {
            case AVMEDIA_TYPE_AUDIO:
            case AVMEDIA_TYPE_VIDEO:
                bandwidth += st->codec->bit_rate;
                break;
            default:
                break;
            }
        }
        stream->bandwidth = (bandwidth + 999) / 1000;
    }
}

void CFFStreamServer::update_datarate(DataRateData *drd, int64_t count)
{
	if (!drd->time1 && !drd->count1) {
		drd->time1 = drd->time2 = cur_time;
		drd->count1 = drd->count2 = count;
	}
	else if (cur_time - drd->time2 > 5000) {
		drd->time1 = drd->time2;
		drd->count1 = drd->count2;
		drd->time2 = cur_time;
		drd->count2 = count;
	}
}

int CFFStreamServer::compute_datarate(DataRateData *drd, int64_t count)
{
	if (cur_time == drd->time1)
		return 0;

	return (int)(((count - drd->count1) * 1000) / (cur_time - drd->time1));
}

/**
* compute the real filename of a file by matching it without its
* extensions to all the stream's filenames
*/
void CFFStreamServer::compute_real_filename(char *filename, int max_size)
{
	char file1[1024];
	char file2[1024];
	char *p;
	FFServerStream *stream;

	av_strlcpy(file1, filename, sizeof(file1));
	p = strrchr(file1, '.');
	if (p)
		*p = '\0';
	for (stream = config.first_stream; stream; stream = stream->next) {
		av_strlcpy(file2, stream->filename, sizeof(file2));
		p = strrchr(file2, '.');
		if (p)
			*p = '\0';
		if (!strcmp(file1, file2)) {
			av_strlcpy(filename, stream->filename, max_size);
			break;
		}
	}
}

int CFFStreamServer::Start(char *szInUrl, char* szRtspPort, char* szRtspName)
{
	TRACE("*********************Streaming Thread In********************************\n");
	fStop = false;
	config.nb_max_http_connections = 2000;
	config.nb_max_connections = 100;
	config.max_bandwidth = 10000; 
	config.use_defaults = 1;

	config.video_opts = NULL;
	config.audio_opts = NULL;

    int cfg_parsed;
    int ret = EXIT_FAILURE;

    init_dynload();

    config.filename = av_strdup("ffserver.conf");

    av_register_all();
    avformat_network_init();

    putenv("http_proxy");             /* Kill the http_proxy */

    av_lfg_init(&random_state, av_get_random_seed());

    if ((cfg_parsed = ffserver_parse_ffconfig(szInUrl, szRtspPort, szRtspName, &config)) < 0) 
	{
        fprintf(stderr, "Error reading configuration file '%s': \n", config.filename );
        goto fail;
    }

	TRACE("*********************build file streams Call Before********************************\n");
    build_file_streams();

	TRACE("*********************compute bandwidth Call Before********************************\n");
    compute_bandwidth();

	TRACE("*********************HTTP Server Call Before********************************\n");
    if (http_server() < 0) 
	{
        goto fail;
    }
	TRACE("*********************HTTP Server Call After********************************\n");

    ret=EXIT_SUCCESS;

fail:
    av_freep (&config.filename);
    avformat_network_deinit();
    return ret;
}
#ifdef _DEBUG
#include "hbpmanager.h"
#endif
void CFFStreamServer::Stop()
{
	fStop = true;
}