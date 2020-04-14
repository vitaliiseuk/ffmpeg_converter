#include "play_common.h"
#include "cmdutils.h"
#include "hbpmanager.h"


#include <Windows.h>
#include <sstream>

typedef struct
{
	char			szOutUrl[500];
	// -------for the recording-----------//
	AVFormatContext *pOutAVFormatContext;
	AVOutputFormat	*pOutFormat;
	AVStream		*pOutVidStream;
	AVStream		*pOutAudStream;
	bool			isRecording;
	bool			isVRecordingFirst;
	bool			isARecordingFirst;

	int				nFrameNo;
	////////////////////////////////////////
} XVR_RECORDER;

enum M
{
	FILE_HEAD = 0,	    		
	VIDEO_I_FRAME = 1,			
	VIDEO_B_FRAME = 2,			
	VIDEO_P_FRAME = 3,			
	VIDEO_BP_FRAME = 4,			
	VIDEO_BBP_FRAME = 5,		
	VIDEO_J_FRAME = 6,			
	AUDIO_PACKET = 10,			
};

typedef struct
{
	int		       nPacketType;			
	char*	       pPacketBuffer;		
	unsigned int   dwPacketSize;		

	?
	int		       nYear;				
	int		       nMonth;				
	int		       nDay;				
	int		       nHour;				
	int		       nMinute;				
	int		       nSecond;				
	unsigned int   dwTimeStamp;			
	unsigned int   dwTimeStampHigh;    	
	unsigned int   dwFrameNum;          
	unsigned int   dwFrameRate;         
	unsigned short uWidth;              
	unsigned short uHeight;             
	unsigned int   Reserved[6];     	
} PACKET_INFO_EX;

void __stdcall FFM_API_XVRRecorderPutPacket(HANDLE hRecorder, void* pPkt)
{
	if (!hRecorder) return;

	XVR_RECORDER* recorder = (XVR_RECORDER*)hRecorder;

	PACKET_INFO_EX *pkt = (PACKET_INFO_EX*)pPkt;

	if (pkt->nPacketType == FILE_HEAD)
		return;

	AVPacket packet;// = NULL;
	memset((void*)&packet, 0, sizeof(AVPacket));
	packet.data = (uint8_t*)pkt->pPacketBuffer;
	packet.size = pkt->dwPacketSize;
	packet.pts = pkt->dwTimeStamp;
	packet.dts = pkt->dwFrameNum;

	if (pkt->nPacketType == VIDEO_I_FRAME)
		packet.flags |= AV_PKT_FLAG_KEY;

	AVFormatContext *ofcx = recorder->pOutAVFormatContext;
	AVOutputFormat *ofmt = recorder->pOutFormat;
	AVStream *out_vid_strm = recorder->pOutVidStream;
	

	static int64_t recordingStartVidPTS = -1, recordingStartAudPTS = -1;
	static int64_t recordingStartVidDTS = -1, recordingStartAudDTS = -1;
	AVPacket outpkt;

	static int iCurPTS = 0;

	int64_t nGenedTime = 0;
	bool fWrite = false;

	//if (packet.stream_index == i_vid_index)
	{
		if (recorder->isVRecordingFirst /*&& (packet.flags & AV_PKT_FLAG_KEY)*/)
		{
			recorder->isVRecordingFirst = false;
			recordingStartVidPTS = packet.pts;
			recordingStartVidDTS = packet.dts;
		}

		if (!recorder->isVRecordingFirst)
		{
			av_init_packet(&outpkt);

			outpkt.data = packet.data;
			outpkt.size = packet.size;
			outpkt.stream_index = packet.stream_index;

			outpkt.flags = packet.flags;
			if (packet.pts > 0)
			{
				//outpkt.pts = av_rescale_q(packet.pts - recordingStartVidPTS, out_vid_strm->codec->time_base, out_vid_strm->time_base);
				//outpkt.dts = av_rescale_q(packet.dts - recordingStartVidDTS, out_vid_strm->codec->time_base, out_vid_strm->time_base);
			}
			else
			{
				outpkt.pts = packet.pts;
				outpkt.dts = packet.dts;
			}

			//if (outpkt.buf)
			{
				{

					if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
					{
						TRACE("Failed Video Write...\n");
					}
					else
					{
						out_vid_strm->codec->frame_number++;
					}
				}
			}
		}
	}
	
}

void __stdcall FFM_API_XVRRecorderClose(HANDLE hRecorder)
{
	XVR_RECORDER* recorder = (XVR_RECORDER*)hRecorder;

	AVFormatContext *ofcx = recorder->pOutAVFormatContext;
	AVOutputFormat  *ofmt = recorder->pOutFormat;

	if (ofcx)
	{
		av_write_trailer(ofcx);
		avio_close(ofcx->pb);
		avformat_free_context(ofcx);
	}
}

#define RS_NOT_OK -1
#define RS_OK 0

int AddVideoStream(AVStream *&video_st, AVFormatContext *&oc, AVCodec **codec, enum AVCodecID codec_id, int nWidth, int nHeight)
{

	AVCodecContext *c;

	/* find the encoder */
	*codec = avcodec_find_encoder(codec_id); //codec id = AV_CODEC_ID_H264

	if (!(*codec)) {
		return RS_NOT_OK;
	}

	video_st = avformat_new_stream(oc, *codec);
	if (!video_st) {
		return RS_NOT_OK;
	}
	video_st->id = oc->nb_streams - 1;
	c = video_st->codec;

	avcodec_get_context_defaults3(c, *codec);
	c->codec_id = codec_id;

	c->bit_rate = 500 * 1000;

	/* Resolution must be a multiple of two. */
	c->width = nWidth;
	c->height = nHeight;

	/* timebase: This is the fundamental unit of time (in seconds) in terms
	* of which frame timestamps are represented. For fixed-fps content,
	* timebase should be 1/framerate and timestamp increments should be
	* identical to 1. */
	c->time_base.den = 25 * 1000;
	c->time_base.num = 1000;
	c->gop_size = 12;//(int)(av_q2d(c->time_base) / 2);    // GOP size is framerate/2 
	c->pix_fmt = AV_PIX_FMT_YUV420P;

	/* Some formats want stream headers to be separate. */
	if (oc->oformat->flags & AVFMT_GLOBALHEADER)
		c->flags |= CODEC_FLAG_GLOBAL_HEADER;

	return RS_OK;
}

HANDLE	__stdcall FFM_API_XVRRecorderOpen(const char *szOutUrl, int nWidth, int nHeight)
{
	int ret = 0;

	// av register all
	avcodec_register_all();
	av_register_all();

	XVR_RECORDER* recorder = NULL;

	recorder = (XVR_RECORDER*)malloc(sizeof(XVR_RECORDER));
	memset(recorder, 0, sizeof(XVR_RECORDER));

	if (szOutUrl)
		strcpy(recorder->szOutUrl, szOutUrl);
	else
		goto xvr_recorder_open_fail; // return FALSE;

	AVFormatContext *ofcx = NULL;
	AVOutputFormat *ofmt = NULL;

	ofmt = av_guess_format(NULL, "tmp.avi", NULL);
	ofcx = avformat_alloc_context();
	ofcx->oformat = ofmt;

	// Create output stream
	AVCodec *out_vid_codec = NULL, *out_aud_codec = NULL;

	AVStream *out_vid_strm = NULL, *out_aud_strm = NULL;

	if (ofmt->video_codec != AV_CODEC_ID_NONE)
	{
		out_vid_codec = avcodec_find_encoder(AV_CODEC_ID_H264);
		//out_vid_codec = avcodec_find_encoder(ofmt->video_codec);
		if (NULL == out_vid_codec)
		{
			goto xvr_recorder_open_fail; //return NULL;
		}
		else
		{
			out_vid_strm = avformat_new_stream(ofcx, out_vid_codec);
			if (NULL == out_vid_strm)
			{
				goto xvr_recorder_open_fail; //return false;
			}
			else
			{
				out_vid_strm->id = 0;

				AVCodecContext* c = out_vid_strm->codec;
				avcodec_get_context_defaults3(c, out_vid_codec);
				c->codec_id = AV_CODEC_ID_H264;
				c->bit_rate = 500 * 1000;
				c->width = nWidth;
				c->height = nHeight;
				c->time_base.den = 25 * 1000;
				c->time_base.num = 1000;
				c->gop_size = 12;
				c->pix_fmt = AV_PIX_FMT_YUV420P;

			
			}
		}
	}


	if (!(ofmt->flags & AVFMT_NOFILE))
	{
		if (avio_open2(&ofcx->pb, recorder->szOutUrl, AVIO_FLAG_WRITE, NULL, NULL) < 0)
		{
			goto xvr_recorder_open_fail; //return NULL;
		}
	}
	/* Write the stream header, if any. */
	if (avformat_write_header(ofcx, NULL) < 0)
	{
		goto xvr_recorder_open_fail; //return NULL;
	}

	strcpy_s(ofcx->filename, recorder->szOutUrl);

	recorder->pOutFormat = ofmt;
	recorder->pOutAVFormatContext = ofcx;
	recorder->pOutVidStream = out_vid_strm;
	//recorder->pOutAudStream = out_aud_strm;

	recorder->isRecording = true;
	recorder->isVRecordingFirst = true;
	recorder->isARecordingFirst = true;

	return (HANDLE)recorder;

xvr_recorder_open_fail:
	free(recorder);
	recorder = NULL;
	return NULL;
}

struct HKeyHolder
{
private:
	HKEY m_Key;

public:
	HKeyHolder() :
		m_Key(nullptr)
	{
	}

	HKeyHolder(const HKeyHolder&) = delete;
	HKeyHolder& operator=(const HKeyHolder&) = delete;

	~HKeyHolder()
	{
		if (m_Key != nullptr)
			RegCloseKey(m_Key);
	}

	operator HKEY() const
	{
		return m_Key;
	}

	HKEY* operator&()
	{
		return &m_Key;
	}
};

BOOL	__stdcall HaveGPU()
{
	return TRUE;
}

BOOL __stdcall IsRunningOnWindows10()
{
	HKeyHolder currentVersion;
	if (RegOpenKeyEx(HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", 0, KEY_QUERY_VALUE, &currentVersion) != ERROR_SUCCESS)
		return false;

	DWORD valueType;
	BYTE buffer[256];
	DWORD bufferSize = 256;

	if (RegQueryValueEx(currentVersion, "CurrentBuild", nullptr, &valueType, buffer, &bufferSize) != ERROR_SUCCESS)
		return false;

	if (valueType != REG_SZ)
		return false;

	int version;
	std::istringstream versionStream(reinterpret_cast<char*>(buffer));
	versionStream >> version;

	return version > 9800;
}

/*void GetOSVersion(PLAYER* player)
{
	player->bUseDxva = !IsRunningOnWindows10();
}*/

BOOL    __stdcall FFM_API_Initialize()
{
	return ::CoInitialize(NULL);
}

BOOL    __stdcall FFM_API_UnInitialize()
{
	::CoUninitialize();
	return TRUE;
}

static DWORD WINAPI RecordThreadProc(PLAYER *player)
{
	AVPacket *packet = NULL;

	int i_vid_index = player->iVideoStreamIndex;
	int i_aud_index = player->iAudioStreamIndex;

	AVStream* in_vid_strm = player->pAVFormatContext->streams[i_vid_index];
	AVStream* in_aud_strm = player->pAVFormatContext->streams[i_aud_index];

	AVFormatContext *ofcx = player->pOutAVFormatContext;
	AVOutputFormat *ofmt = player->pOutFormat;
	AVStream *out_vid_strm = player->pOutVidStream;
	AVStream *out_aud_strm = player->pOutAudStream;

	int64_t recordingStartVidPTS = -1, recordingStartAudPTS = -1;
	int64_t recordingStartVidDTS = -1, recordingStartAudDTS = -1;
	AVPacket outpkt;

	int iCurPTS = 0;
	
	if (player->bDecode)
		iCurPTS = rendergetcurpts(player->hCoreRender);
	else
		iCurPTS = pktqueue_get_cur_pts(&(player->PacketQueue));

	iCurPTS /= player->dVideoTimeBase;

	long curpos = player->nRecStartPOS; //pktqueue_find_record_start_pos(&(player->PacketQueue), i_vid_index, iCurPTS, 3);

	int64_t nGenedTime = 0;
	bool fWrite = false;

	while (player->isRecording && player->nPlayerStatus == PLAYER_PLAY)
	{
		long fhead = player->PacketQueue.fhead;
		
		if (curpos == fhead)
		{
			pktqueue_read_done(&(player->PacketQueue));
			::Sleep(100);
			continue;
		}

		pktqueue_read_request(&(player->PacketQueue), &packet, curpos);

		if ((packet->flags & AV_PKT_FLAG_CORRUPT) == AV_PKT_FLAG_CORRUPT || (packet->pts < 0 || packet->dts < 0))
		{			
			pktqueue_read_done(&(player->PacketQueue));
			//TRACE("Corrupted...\n");
			curpos++;
			if (curpos == player->PacketQueue.fsize)
				curpos = 0;
			continue;
		}


		if (packet->stream_index == i_vid_index)
		{

			if (player->isVRecordingFirst /*&& (packet->flags & AV_PKT_FLAG_KEY)*/)
			{
				player->isVRecordingFirst = false;
				recordingStartVidPTS = packet->pts;
				recordingStartVidDTS = packet->dts;
			}

			if (!player->isVRecordingFirst)
			{
				av_init_packet(&outpkt);

				outpkt.data = packet->data;
				outpkt.size = packet->size;
				outpkt.stream_index = packet->stream_index;

				outpkt.flags = packet->flags;
				if (packet->pts > 0)
				{
					outpkt.pts = av_rescale_q(packet->pts - recordingStartVidPTS, in_vid_strm->time_base, out_vid_strm->time_base);
					outpkt.dts = av_rescale_q(packet->dts - recordingStartVidDTS, in_vid_strm->time_base, out_vid_strm->time_base);
				}
				else
				{
					outpkt.pts = packet->pts;
					outpkt.dts = packet->dts;
				}

				//if (outpkt.buf)
				{
					if (player->nRecMode == RECORD_ALWAYS || player->nRecMode == RECORD_MOTION_DETECT || player->nRecMode == RECORD_VOICE_DETECT ||
						(player->nRecMode == RECORD_KEYFRAME && (outpkt.flags & AV_PKT_FLAG_KEY) == AV_PKT_FLAG_KEY))
					{

						if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
						{
							//TRACE("Failed Video Write...\n");
						}
						else
						{
							out_vid_strm->codec->frame_number++;
						}
					}

					if (player->nRecMode == RECORD_SMART )
					{
						int64_t dur = 4000000;

						if (player->bDetected == true)
						{
							//nGenedTime = GetTickCount64(); // packet->pts;
							nGenedTime = packet->pts;
							//player->bDetected = false;
							player->nAfterRecTime /= player->dVideoTimeBase;
							fWrite = true;
						}
						
						if (fWrite && !player->bDetected)
						{
							//dur = GetTickCount64() - nGenedTime;//packet->pts - nGenedTime;
							dur = packet->pts - nGenedTime;

							if (fWrite && dur > player->nAfterRecTime * 1000 && (outpkt.flags & AV_PKT_FLAG_KEY))
							{
								fWrite = false;							
								nGenedTime = 0;
							}
						}

						if ((outpkt.flags & AV_PKT_FLAG_KEY) == AV_PKT_FLAG_KEY || fWrite)
						{												

							if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
							{
								//TRACE("Failed Video Write...\n");
							}
							else
							{
								out_vid_strm->codec->frame_number++;
							}
						}
					}
				}
			}
		}

		else if (packet->stream_index == i_aud_index)
		{
			if (!player->isVRecordingFirst && player->isARecordingFirst)
			{
				recordingStartAudPTS = packet->pts;
				recordingStartAudDTS = packet->pts;
				player->isARecordingFirst = false;
			}

			if (!player->isVRecordingFirst && !player->isARecordingFirst)
			{
				av_init_packet(&outpkt);
				outpkt.data = packet->data;
				outpkt.size = packet->size;
				outpkt.stream_index = packet->stream_index;
				outpkt.flags = packet->flags;

				if (packet->pts > 0)
				{
					outpkt.pts = av_rescale_q(packet->pts - recordingStartAudPTS, in_aud_strm->time_base, out_aud_strm->time_base);
					outpkt.dts = av_rescale_q(packet->dts - recordingStartAudDTS, in_aud_strm->time_base, out_aud_strm->time_base);
				}
				else
				{
					outpkt.pts = packet->pts;
					outpkt.dts = packet->dts;
				}

				//if (outpkt.buf)
				{
					if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
					{
						//TRACE("Failed Audio Write...\n");
					}
					else
					{
						out_aud_strm->codec->frame_number++;
					}
				}

			}
		}

		pktqueue_read_done(&(player->PacketQueue));

		curpos++;

		if (curpos == player->PacketQueue.fsize)
			curpos = 0;
	}

	return 0;
}

static DWORD WINAPI StopRecordThreadProc(PLAYER *player)
{
	::Sleep(player->nAfterRecTime * 1000);

	if (!player->hRecordThread)
		return true;

	{
		player->isRecording = false;

		//TRACE("WAIT HANDLE 0 : %x\n", player->hRecordThread);
		WaitForSingleObject(player->hRecordThread, -1);
		CloseHandle(player->hRecordThread);
		player->hRecordThread = NULL;

		AVFormatContext *ofcx = player->pOutAVFormatContext;
		AVOutputFormat *ofmt = player->pOutFormat;

		if (ofcx)
		{
			av_write_trailer(ofcx);
			avio_close(ofcx->pb);
			avformat_free_context(ofcx);
		}

		player->isARecordingFirst = true;
		player->isVRecordingFirst = true;
	}	

	return true;
}

void	__stdcall FFM_API_GenerateSignal(HANDLE hPlayer, int nAfterSec)
{
	PLAYER* player = (PLAYER*)hPlayer;

	if (!player->isRecording || player->nRecMode != RECORD_SMART)
		return;

	player->nAfterRecTime = nAfterSec;
	player->bDetected = !(player->bDetected);
}

BOOL	__stdcall FFM_API_StartRecording(HANDLE hPlayer, const char *szOutUrl, int mode, int nPreRecTime)
{
	int ret = 0;
	
	PLAYER* player = (PLAYER*)hPlayer;

	if (player->isRecording)
		return FALSE;

	if (szOutUrl)
		strcpy(player->szOutUrl, szOutUrl);
	else
		return FALSE;

	if (mode == RECORD_NO)
		return FALSE;

	if ( mode == RECORD_MOTION_DETECT || mode == RECORD_VOICE_DETECT)
		player->nPreRecTime = nPreRecTime;
	else
	{
		player->nPreRecTime = 0;
	}	

	////////////////// for the temp ////////////////////
	// player->nPreRecTime = 0;
	////////////////////////////////////////////////////

	AVFormatContext *ofcx = NULL;
	AVOutputFormat *ofmt = NULL;

	ofmt = av_guess_format(NULL, player->szOutUrl, NULL);
	ofmt = av_guess_format(NULL, "tmp.avi", NULL);
	ofcx = avformat_alloc_context();
	ofcx->oformat = ofmt;

	// Create output stream
	AVCodec *out_vid_codec = NULL, *out_aud_codec = NULL;

	AVStream *in_vid_strm = NULL, *in_aud_strm = NULL, *out_vid_strm = NULL, *out_aud_strm = NULL;

	if (player->iVideoStreamIndex == -1)
		in_vid_strm = NULL;
	else
		in_vid_strm = player->pAVFormatContext->streams[player->iVideoStreamIndex];

	if (player->iAudioStreamIndex == -1)
		in_aud_strm = NULL;
	else
		in_aud_strm = player->pAVFormatContext->streams[player->iAudioStreamIndex];

	if (ofmt->video_codec != AV_CODEC_ID_NONE && in_vid_strm != NULL)
	{
		out_vid_codec = avcodec_find_encoder(ofmt->video_codec);
		if (NULL == out_vid_codec)
		{
			ret = RTSP_CODEC_OPEN_FAILED;
			return false;
		}
		else
		{
			out_vid_strm = avformat_new_stream(ofcx, out_vid_codec);
			if (NULL == out_vid_strm)
			{
				ret = RTSP_CODEC_OPEN_FAILED;
				return false;
			}
			else
			{
				if (avcodec_copy_context(out_vid_strm->codec, in_vid_strm->codec) != 0)
				{
					ret = RTSP_CODEC_OPEN_FAILED;
					return false;
				}
				else
				{

				}
			}
		}
	}


	if (ofmt->audio_codec != AV_CODEC_ID_NONE && in_aud_strm != NULL)
	{
		out_aud_codec = avcodec_find_encoder(ofmt->audio_codec);
		if (NULL == out_aud_codec)
		{
			ret = RTSP_CODEC_OPEN_FAILED;
			return false;
		}
		else
		{
			out_aud_strm = avformat_new_stream(ofcx, out_aud_codec);
			if (NULL == out_aud_strm)
			{
				ret = RTSP_CODEC_OPEN_FAILED;
				return false;
			}
			else
			{
				if (avcodec_copy_context(out_aud_strm->codec, in_aud_strm->codec) != 0)
				{
					ret = RTSP_CODEC_OPEN_FAILED;
					return false;
				}
				else
				{

				}
			}
		}
	}

	if (!(ofmt->flags & AVFMT_NOFILE))
	{
		if (avio_open2(&ofcx->pb, player->szOutUrl, AVIO_FLAG_WRITE, NULL, NULL) < 0)
		{
			ret = RTSP_CODEC_OPEN_FAILED;
			return false;
		}
	}
	/* Write the stream header, if any. */
	if (avformat_write_header(ofcx, NULL) < 0)
	{
		ret = RTSP_CODEC_OPEN_FAILED;
		return false;
	}

	strcpy_s(ofcx->filename, player->szOutUrl);

	player->pOutFormat = ofmt;
	player->pOutAVFormatContext = ofcx;
	player->pOutVidStream = out_vid_strm;
	player->pOutAudStream = out_aud_strm;

	player->isRecording = true;
	player->isVRecordingFirst = true;
	player->isARecordingFirst = true;

	int i_vid_index = player->iVideoStreamIndex;
	int i_aud_index = player->iAudioStreamIndex;

	int iCurPTS = 0;
	if (player->bDecode)
		iCurPTS = rendergetcurpts(player->hCoreRender);
	else
		iCurPTS = pktqueue_get_cur_pts(&(player->PacketQueue));

	iCurPTS /= player->dVideoTimeBase;

	player->nRecStartPOS = pktqueue_find_record_start_pos(&(player->PacketQueue), i_vid_index, iCurPTS, player->nPreRecTime * player->nInputFps);

	player->nRecMode = (RECORD_MODE)mode;

	player->hRecordThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)RecordThreadProc, player, 0, 0);

	return true; 
}

void __stdcall FFM_API_StopRecording(HANDLE hPlayer, int nAfterRecTime)
{
	PLAYER* player = (PLAYER*)hPlayer;

	if (!player->hRecordThread)
		return;
	
	if (player->nRecMode == RECORD_MOTION_DETECT || player->nRecMode == RECORD_VOICE_DETECT)
		player->nAfterRecTime = nAfterRecTime;
	else
	{
		player->nAfterRecTime = 0;
	}

	TRACE("\n---------AfterRecTime---------%d\n", player->nAfterRecTime);

	player->hRecordStopThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)StopRecordThreadProc, player, 0, 0);

	WaitForSingleObject(player->hRecordStopThread, -1);
	CloseHandle(player->hRecordStopThread);
	player->hRecordStopThread = NULL;

/*	{
		player->isRecording = false;

		WaitForSingleObject(player->hRecordThread, -1);
		CloseHandle(player->hRecordThread);
		player->hRecordThread = NULL;

		AVFormatContext *ofcx = player->pOutAVFormatContext;
		AVOutputFormat *ofmt = player->pOutFormat;

		if (ofcx)
		{
			av_write_trailer(ofcx);
			avio_close(ofcx->pb);
			avformat_free_context(ofcx);
		}

		player->isARecordingFirst = true;
		player->isVRecordingFirst = true;
	}	*/

/*	PLAYER* player = (PLAYER*)hPlayer;

	if (!player->isRecording)
		return;

	{
		player->isRecording = false;

		AVFormatContext *ofcx = player->pOutAVFormatContext;
		AVOutputFormat *ofmt = player->pOutFormat;

		if (ofcx)
		{
			av_write_trailer(ofcx);
			avio_close(ofcx->pb);
			avformat_free_context(ofcx);
		}

		player->isARecordingFirst = true;
		player->isVRecordingFirst = true;
	} */
}

void NotifyCallBack(HANDLE handle, int nMainCode, int nAuxCode, char* param)
{
	PLAYER* player = (PLAYER*)handle;
	if (player == NULL)
		return;
	
	if (player->pNotifyCallBackFunc)
	{
		EnterCriticalSection(player->pcsNotify);
		if (player->pNotifyCallBackFunc(player, nMainCode, nAuxCode, param))
		{
			LeaveCriticalSection(player->pcsNotify);
		}
	}
}

static DWORD WINAPI DisconnectionNotifyThread(PLAYER *player)
{
	//FFM_API_Close(player);

#if 0
	if (player->hPlayerThread)
	{
		//TRACE("WAIT HANDLE 1 : %x\n", player->hPlayerThread);
		WaitForSingleObject(player->hPlayerThread, -1);
		if (player->hPlayerThread)
			CloseHandle(player->hPlayerThread);
		player->hPlayerThread = NULL;
	}
#endif


	NotifyCallBack(player, NOTIFY_CONNECTION_FAILED, 0, NULL);

	
	return 0;
}

static DWORD WINAPI ReconnectAfterDisconnectThread(PLAYER *player)
{
	//FFM_API_Release(player);
	 
	std::list<HWND> listRenderWindow;
	GetRenderWindowList(player->hCoreRender, listRenderWindow);
	
	FFM_API_Close(player);
	
	NotifyCallBack(player, NOTIFY_CONNECTION_FAILED, 0, NULL);

	int bRet = 0;
	while (bRet <= 0)
	{
		Sleep(1000);
		bRet = FFM_API_Open(player, player->szInUrl, NULL, player->bUseDxva, player->play_mode, player->szRtspPort, player->szRtspName, player->pNotifyCallBackFunc);
//		FFM_API_SetPlayFPS(player, 30);
//		if(bRet)
//			FFM_API_Resume(player);

	}

	std::list<HWND>::iterator iter;
	for (iter = listRenderWindow.begin(); iter != listRenderWindow.end(); iter++)
	{
		AddRenderWindow(player->hCoreRender, *iter);
	}
	return 0;

}

static DWORD WINAPI PlayThreadProc(PLAYER *player)
{
    AVPacket *packet = NULL;
	
    int       retv   = 0;
	int64_t	  prevPts = 0;
	int i_vid_index = player->iVideoStreamIndex;
	int i_aud_index = player->iAudioStreamIndex;

	av_read_play(player->pAVFormatContext);

    while (player->nPlayerStatus != PLAYER_STOP && player->nPlayerStatus != PLAYER_FAILED)
    {
        //++ for playerseek ++//
        if (player->nPlayerStatus != PLAYER_PLAY) {
            Sleep(50);
            continue;
        }
        //-- for playerseek --//

		if (!pktqueue_write_request(&(player->PacketQueue), &packet))
		{
			Sleep(10);
			continue;
		}

		if (packet)
		{
			av_packet_unref(packet);
			av_free_packet(packet);
		}

		retv = av_read_frame(player->pAVFormatContext, packet);
#if 0
		static int n = 0;
		//TRACE("count %d\n", n++);
		if (n == 500)
		{
			n = 0;
			{
				CreateThread(0, 0, (LPTHREAD_START_ROUTINE)ReconnectAfterDisconnectThread, player, 0, 0);
			}continue;
			break;

		}
#endif
			//
		//++ play completed ++//
        if (retv < 0)
        {
			{
				packet->pts = -1; // video packet pts == -1, means completed
				
				if (player->iVideoStreamIndex != -1) {
					pktqueue_write_done_v(&(player->PacketQueue), player->bDecode);
				}
				
				if (player->iAudioStreamIndex != -1) {
					pktqueue_write_done_a(&(player->PacketQueue), player->bDecode);
				}
				
				pktqueue_write_release(&(player->PacketQueue), false);

				player->nPlayerStatus = PLAYER_STOP;
			}
			

			if (TRUE)
			{
				CreateThread(0, 0, (LPTHREAD_START_ROUTINE)DisconnectionNotifyThread, player, 0, 0);
			}
			else
			{
				CreateThread(0, 0, (LPTHREAD_START_ROUTINE)ReconnectAfterDisconnectThread, player, 0, 0);
			}
			//continue;
			break;
        }
		//-- play completed --//

		if ((packet->flags & AV_PKT_FLAG_CORRUPT) == AV_PKT_FLAG_CORRUPT)
		{
			continue;
		}

		///////////////////// for recording ////////////////////////////////////////
/*		if (player->isRecording)
		{
			AVFormatContext *ofcx = player->pOutAVFormatContext;
			AVOutputFormat *ofmt = player->pOutFormat;
			AVStream *out_vid_strm = player->pOutVidStream;
			AVStream *out_aud_strm = player->pOutAudStream;

			/////////////////////// for the test ///////////////////////////////////////////////////////////////////
			int iCurPTS = rendergetcurpts(player->hCoreRender);
			iCurPTS /= player->dVideoTimeBase;

			player->nRecStartPOS = pktqueue_find_record_start_pos(&(player->PacketQueue), i_vid_index, iCurPTS, 3 * in_vid_strm->r_frame_rate.num);

			player->hRecordThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)RecordThreadProc, player, 0, 0);
		} */

		////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
			if (packet->stream_index == i_vid_index)
			{

				if (player->isVRecordingFirst && (packet->flags & AV_PKT_FLAG_KEY))
				{
					player->isVRecordingFirst = false;
					recordingStartTimePTS = packet->pts;
					recordingStartTimeDTS = packet->dts;
					//TRACE("recordingStartTimePTS ---------- %d \n", recordingStartTimePTS);
					//TRACE("recordingStartTimeDTS ---------- %d \n", recordingStartTimeDTS);
				}
				
				if (!player->isVRecordingFirst)
				{
					av_init_packet(&outpkt);

					outpkt.data = packet->data;
					outpkt.size = packet->size;
					outpkt.stream_index = packet->stream_index;

					outpkt.flags = packet->flags;
					if (packet->pts > 0)
					{
						outpkt.pts = av_rescale_q(packet->pts - recordingStartTimePTS, in_vid_strm->time_base, out_vid_strm->time_base);
						outpkt.dts = av_rescale_q(packet->dts - recordingStartTimeDTS, in_vid_strm->time_base, out_vid_strm->time_base);
					}
					else
					{
						outpkt.pts = packet->pts;
						outpkt.dts = packet->dts;
					}

					if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
					{
						//TRACE("Failed Video Write...\n");
					}
					else
					{
						out_vid_strm->codec->frame_number++;
					}
					av_packet_unref(&outpkt);
					av_free_packet(&outpkt);
				}
			}

			else if (packet->stream_index == i_aud_index)
			{
				if (!player->isVRecordingFirst && player->isARecordingFirst)
				{
					recordingStartAudPTS = packet->pts;
					recordingStartAudDTS = packet->pts;
					player->isARecordingFirst = false;
				}
				
				if (!player->isVRecordingFirst && !player->isARecordingFirst)
				{
					av_init_packet(&outpkt);
					outpkt.data = packet->data;
					outpkt.size = packet->size;
					outpkt.stream_index = packet->stream_index;
					outpkt.flags = packet->flags;

					if (packet->pts > 0)
					{
						outpkt.pts = av_rescale_q(packet->pts - recordingStartAudPTS, in_aud_strm->time_base, out_aud_strm->time_base);
						outpkt.dts = av_rescale_q(packet->dts - recordingStartAudDTS, in_aud_strm->time_base, out_aud_strm->time_base);
					}
					else
					{
						outpkt.pts = packet->pts;
						outpkt.dts = packet->dts;
					}

					if (av_interleaved_write_frame(ofcx, &outpkt) < 0)
					{
						//TRACE("Failed Audio Write...\n");
					}
					else
					{
						out_aud_strm->codec->frame_number++;
					}
					av_packet_unref(&outpkt);
					av_free_packet(&outpkt);
				}
			}
		} 
		*/

		if (player->bDecode)
		{

        // audio
			if (packet->stream_index == player->iAudioStreamIndex)
			{
				pktqueue_write_done_a(&(player->PacketQueue), player->bDecode);
			}

			// video
			if (packet->stream_index == player->iVideoStreamIndex)
			{				
				if (prevPts > 0)
				{
					player->nInputFps = 1000.0 / (packet->pts - prevPts) * 100;
					rendersetplayfps(player->hCoreRender, player->nInputFps);
					//TRACE("------------input fps-----------------%d\n", player->nInputFps);
				}

				prevPts = packet->pts; 

				pktqueue_write_done_v(&(player->PacketQueue), player->bDecode);
			}

			if (packet->stream_index != player->iAudioStreamIndex
				&& packet->stream_index != player->iVideoStreamIndex)
			{
				av_free_packet(packet);
				av_packet_unref(packet); //av_free_packet(packet); // free packet
				pktqueue_write_release(&(player->PacketQueue),false);
			}
			
		}
		else
		{
			pktqueue_write_release(&(player->PacketQueue), true);

			if (packet->stream_index == player->iVideoStreamIndex /*&& (packet->flags & AV_PKT_FLAG_KEY)*/)
			{
				if (packet->flags & AV_PKT_FLAG_KEY || player->nWatingPkts >= WAITING_PKTS_COUNT)
					player->nWatingPkts = 0;

				player->ppWatingPkts[player->nWatingPkts++] = packet;				
			}
		}
    }

	EnterCriticalSection(player->pcsBusy);
	av_read_pause(player->pAVFormatContext);
	TRACE("\n------------PlayThreadProcEnd------------\n");
	LeaveCriticalSection(player->pcsBusy);
	return 0;
}

static DWORD WINAPI AudioDecodeThreadProc(PLAYER *player)
{
	AVPacket *packet = NULL;
	AVFrame  *aframe = NULL;
	int       consumed = 0;
	int       gotaudio = 0;

	aframe = av_frame_alloc();
	if (!aframe) return 0;

	while (player->nPlayerStatus != PLAYER_STOP && player->nPlayerStatus != PLAYER_FAILED && player->bDecode)
	{
		if (!pktqueue_read_request_a(&(player->PacketQueue), &packet))
		{
			Sleep(10);
			continue;
		}

		//++ play completed ++//
		if (packet->pts == -1) {
			renderaudiowrite(player->hCoreRender, (AVFrame*)-1);
			pktqueue_read_done_a(&(player->PacketQueue));
			continue;
		}
		//-- play completed --//

		if (player->nPlayerStatus != PLAYER_SEEK && player->bDecode) {
			consumed = gotaudio = 0;
			while (packet->size > 0 ) {
				if (player->iAudioStreamIndex != -1) {
					consumed = avcodec_decode_audio(player->pAudioCodecContext, aframe, &gotaudio, packet);
				}

				if (consumed < 0) {
					TRACE("an error occurred during decoding audio.\n");
					break;
				}

				if (gotaudio) 
				{
					aframe->pts = (int64_t)(packet->pts * player->dAudioTimeBase);
					if (player->hCoreRender)
						renderaudiowrite(player->hCoreRender, aframe);
					else
						player->hCoreRender = 0;
				}
				packet->data += consumed;
				packet->size -= consumed;
			}

			// free packet
			// av_free_packet(packet);
		}

		pktqueue_read_done_a(&(player->PacketQueue));
	}

	av_frame_free(&aframe);
	return 0;
}

int save_frame_as_jpeg(AVCodecContext *pCtx, AVFrame* pFrm, int nNo)
{
/*	AVCodec* jCodec = avcodec_find_encoder(AV_CODEC_ID_MJPEG); // AV_CODEC_ID_MJPEG);
	if (!jCodec)
		return -1;

	AVCodecContext* jContext = avcodec_alloc_context3(jCodec);
	if (!jContext)
		return -1;

	jContext->bit_rate = 40000;
	jContext->time_base.den = 1;
	jContext->time_base.num = 25;
	jContext->pix_fmt = pCtx->pix_fmt;
	jContext->width = pFrm->width;
	jContext->height = pFrm->height;

	int ret = avcodec_open2(jContext, jCodec, NULL);
	if ( ret < 0)
	{
		avcodec_close(jContext);
		return -1;
	}
	FILE *jFile;
	char strFN[256];

	AVPacket pkt; // = { .data = NULL, .size = 0 };
	av_init_packet(&pkt);
	int got_picture = 0;

//	pFrm->pts = 0;
//	pFrm->pkt_dts = 0;

	if (avcodec_encode_video2(jContext, &pkt, pFrm, &got_picture) < 0)
	{
		avcodec_close(jContext);
		return -1;
	}

	sprintf(strFN, "c:/scene-%d.jpg", nNo);
	jFile = fopen(strFN, "wb");
	fwrite(pkt.data, 1, pkt.size, jFile);
	fclose(jFile);

	av_packet_unref(&pkt);
	av_free_packet(&pkt);
	avcodec_close(jContext);

	return 1;  */

	BITMAPINFOHEADER bmpinfo = { 0 };
	BITMAPFILEHEADER bmfh = { 0 };

	bmpinfo.biSize = sizeof(BITMAPINFOHEADER);
	bmpinfo.biWidth = 320;
	bmpinfo.biHeight = -240;
	bmpinfo.biClrImportant = 0;
	bmpinfo.biClrUsed = 0;
	bmpinfo.biBitCount = 32;
	bmpinfo.biCompression = BI_RGB;
	bmpinfo.biSizeImage = 320 * 240 * 4;

	bmfh.bfType = 'B' + ('M' << 8);
	bmfh.bfOffBits = sizeof(BITMAPINFOHEADER) + sizeof(BITMAPFILEHEADER);
	bmfh.bfSize = bmfh.bfOffBits + bmpinfo.biSizeImage;

	BYTE* pbmpbuf = NULL;

	//HBITMAP hbitmap = CreateDIBSection(CreateCompatibleDC(NULL), bmpinfo, DIB_RGB_COLORS, (void**)&(pbmpbuf), NULL, 0);
	pbmpbuf = (BYTE*)malloc(320 * 4 * 240);

	AVPicture picture = { 0 };
	int       stride = 0;	
	
	picture.data[0] = pbmpbuf;
	picture.linesize[0] = 320 * 4;
		
	SwsContext* pSWSContext = sws_getContext(pFrm->width, pFrm->height, (AVPixelFormat)(pFrm->format), 320, 240, AV_PIX_FMT_RGBA, SWS_BICUBIC, 0, 0, 0);

	sws_scale(pSWSContext, pFrm->data, pFrm->linesize, 0, pFrm->height, picture.data, picture.linesize);
	
	FILE *jFile;
	char strFN[256];

	sprintf(strFN, "d:/scene_%d.bmp", nNo);
	jFile = fopen(strFN, "wb");
	fwrite(&bmfh, 1, sizeof(BITMAPFILEHEADER), jFile);
	fwrite(&bmpinfo, 1, sizeof(BITMAPINFOHEADER), jFile);
	fwrite(pbmpbuf, 1, bmpinfo.biSizeImage, jFile);
	fclose(jFile);  

	free(pbmpbuf); 

	return 1;
}

void __stdcall FFM_API_Screenshot(HANDLE hPlayer, char* szShotPath)
{
	if (!hPlayer) return;

	PLAYER* player = (PLAYER*)hPlayer;

	strcpy(player->szShotPath,szShotPath);
	player->bScreenshot = true;
}

static DWORD WINAPI VideoDecodeThreadProc(PLAYER *player)
{
    AVPacket *packet   = NULL;
    AVFrame  *vframe   = NULL;
    int       gotvideo = 0;
	static int nPktCount = 0;
		
	float total_count = 0;
	
    vframe = av_frame_alloc();

    if (!vframe) 
		return 0;

	if (player->nPlayerStatus == PLAYER_STOP)
	{
		Sleep(0);
	}
	TRACE("Decode : %d %d\n", player->nPlayerStatus, player->bDecode);
	while (player->nPlayerStatus != PLAYER_STOP && player->nPlayerStatus != PLAYER_FAILED && player->bDecode)
	{
		if (!pktqueue_read_request_v(&(player->PacketQueue), &packet))
		{
			Sleep(10);
			continue;
		}


        //++ play completed ++//
        if (packet->pts == -1) {
            rendervideowrite(player, player->hCoreRender, (AVFrame*)-1, 0, 0, 0);
            pktqueue_read_done_v(&(player->PacketQueue));
            break;
		}
        //-- play completed --//

		
        if (player->nPlayerStatus != PLAYER_SEEK && player->bDecode) 
		{
            gotvideo = 0;
			//nPktCount++;
            if (player->iVideoStreamIndex != -1) 
			{
/*				if (player->bFirstStart)
				{
					player->bFirstStart = false;
					total_count = 1.0;
				}				

				if (player->nPlayFps == 0)
					goto next;
				
				float correct_interval = 1.0 * player->nPlayFps / player->nInputFps;
				
				total_count += correct_interval;
				
				
				if (correct_interval < 1)
				{
					if ((packet->flags & AV_PKT_FLAG_KEY) == AV_PKT_FLAG_KEY)
						avcodec_decode_video(player->pVideoCodecContext, vframe, &gotvideo, packet);
					else
						goto next;
				}
				else 
					avcodec_decode_video(player->pVideoCodecContext, vframe, &gotvideo, packet); */

				if (((player->nPlayFps < 25) && ((packet->flags & AV_PKT_FLAG_KEY) == AV_PKT_FLAG_KEY)) || (player->nPlayFps >= 25))
				{
					//if (player->bDecode||!player->isPixFmtSet)
						avcodec_decode_video(player->pVideoCodecContext, vframe, &gotvideo, packet);
				}
            }

			if (gotvideo /*|| !player->bDecode*/) 
			{
				if (!player->isPixFmtSet)
				{
					rendersetpixfomrat(player->hCoreRender, player->pVideoCodecContext->pix_fmt);
					player->isPixFmtSet = true;
				}

				
				vframe->pts = (int64_t)(packet->pts * player->dVideoTimeBase);

				nPktCount++;

				//if ()
				int nFrameCountInterval = player->nCaptureInterval / (1000.0 / player->nInputFps);
				if (player->bScreenshot)
					TRACE("\nShotPath %s\n", player->szShotPath);
				if (nPktCount >= nFrameCountInterval)
				{
					rendervideowrite(player, player->hCoreRender, vframe, true, player->bScreenshot, player->szShotPath);
					nPktCount = 0;
				}
				else
					rendervideowrite(player, player->hCoreRender, vframe, false, player->bScreenshot, player->szShotPath);
				
				player->bScreenshot = false;

/*				if (player->bScreenshot)
					int nRet = save_frame_as_jpeg(player->pVideoCodecContext, vframe, nPktCount); */
				
				// TRACE("nPktCount-------------%d\n", nPktCount);				
			}
			else
			{
				int tmp = 0;
				//TRACE("------------ - decoding failed ------------\n");
				packet->pts = packet->dts = AV_NOPTS_VALUE;
			}

        }

next:   pktqueue_read_done_v(&(player->PacketQueue));
    }
//	av_frame_unref(vframe);
	pktqueue_read_done_v(&(player->PacketQueue));
    av_frame_free(&vframe);
    return 0;
}

DWORD __stdcall FFM_API_GetLength(HANDLE handle)
{
	DWORD dwLen;
	FFM_API_GetParameter(handle, PARAM_GET_DURATION, &dwLen);
	
	return dwLen;
}


void playerstop(HANDLE hPlayer)
{
    if (!hPlayer) return;
    PLAYER *player = (PLAYER*)hPlayer;

    player->nPlayerStatus = PLAYER_STOP;
	//renderstart(player->hCoreRender);
	if (player->hPlayerThread)
    {
//		TRACE("WAIT HANDLE 2 : %x\n", player->hPlayerThread);
		DWORD dwThreadId = GetThreadId(player->hPlayerThread);
		//TRACE("Closing Play: %d\n", dwThreadId);

        WaitForSingleObject(player->hPlayerThread, -1);
		//TRACE("Closed Play: %d\n", dwThreadId);
		if(player->hPlayerThread)
			CloseHandle(player->hPlayerThread);
        player->hPlayerThread = NULL;
    }
	PKTQUEUE bufTmp = { 0 };
/*	if (memcmp(&player->PacketQueue, &bufTmp, sizeof(bufTmp)) != 0)
	{
		if (pktqueue_isempty_a(&(player->PacketQueue))) {
			pktqueue_write_request(&(player->PacketQueue), NULL);
			pktqueue_write_done_a(&(player->PacketQueue));
		}
		if (pktqueue_isempty_v(&(player->PacketQueue))) {
			pktqueue_write_request(&(player->PacketQueue), NULL);
			pktqueue_write_done_v(&(player->PacketQueue));
		}
		
	}*/
	if (player->hADecodeThread)
    {
//		TRACE("WAIT HANDLE 3 : %x\n", player->hADecodeThread);
        WaitForSingleObject(player->hADecodeThread, -1);
        CloseHandle(player->hADecodeThread);
        player->hADecodeThread = NULL;
    }
	if (player->hVDecodeThread)
    {
//		TRACE("WAIT HANDLE 4 : %x\n", player->hVDecodeThread);
        WaitForSingleObject(player->hVDecodeThread, -1);
        CloseHandle(player->hVDecodeThread);
        player->hVDecodeThread = NULL;
    }
	renderpause(player->hCoreRender);
}


void __stdcall MotionDetectProcByFrameChange(HANDLE hPlayer, AVPicture pit, int nWidth, int nHeight, int nType)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (player == NULL)
		return;

	
	float afDensity[BLOCK_NUM * BLOCK_NUM] = { 0 };

	int x, y, xx, yy;
	
	int nBlockWidth, nBlockHeight;
	nBlockWidth = nWidth / BLOCK_NUM;
	nBlockHeight = nHeight / BLOCK_NUM;
	
	BYTE* ptrY;
	ptrY = pit.data[0];
	for (x = 0; x < BLOCK_NUM; x++)
	{
		for (y = 0; y < BLOCK_NUM; y++)
		{
			for (xx = x * nBlockWidth; xx < (x + 1) * nBlockWidth; xx++)
			{
				for (yy = y*nBlockHeight; yy < (y + 1)*nBlockHeight; yy++)
				{
					afDensity[y*BLOCK_NUM + x] += *ptrY++;
				}
			}
			afDensity[y*BLOCK_NUM + x] /= (BLOCK_NUM*BLOCK_NUM);
		}
	}

	if (player->nFrameNo > 0)
	{
		int nBlockSize;
		float fDiffSum = 0;
		for (x = 0; x < BLOCK_NUM; x++)
		{
			for (y = 0; y < BLOCK_NUM; y++)
			{
				float f = afDensity[y*BLOCK_NUM + x] - player->afFrameDensity[y*BLOCK_NUM + x];
				if (f > 0.0f)
					fDiffSum += f;
				else
					fDiffSum -= f;
			}
		}

		long lSens = long(fDiffSum * 1000.0f/ (255 * BLOCK_NUM*BLOCK_NUM));
		if (lSens > player->lMotionSensitivity)
		{
			NotifyCallBack(hPlayer, NOTIFY_MOTION_DETECT, lSens, "Motion Detected");
		}
	}
	memcpy(player->afFrameDensity, afDensity, sizeof(float)*BLOCK_NUM*BLOCK_NUM);
	
	player->nFrameNo++;
}

void    __stdcall SetVideoFrameCallback(HANDLE hPlayer, void* pCallback)
{
	if (!hPlayer)
		return;

	PLAYER* player = (PLAYER*)hPlayer;

	rendersetvideocallback(player->hCoreRender, pCallback);
}


void __stdcall FFM_API_SetMotionDetectSignal(HANDLE hPlayer, long lSensitivity) // per milli
{
	if (!hPlayer)
		return;

	PLAYER* player = (PLAYER*)hPlayer;

	if (lSensitivity < 0)
	{
		player->lMotionSensitivity = 1000;
		SetVideoFrameCallback(hPlayer, NULL);
	}
	else
	{
		player->lMotionSensitivity = lSensitivity;
		SetVideoFrameCallback(hPlayer, MotionDetectProcByFrameChange);
	}
}

void	__stdcall FFM_API_SetPlayFPS(HANDLE hPlayer, int nFps)
{
	if (!hPlayer) return;

	PLAYER *player = (PLAYER*)hPlayer;

	player->nPlayFps = nFps;

	rendersetplayfps(player->hCoreRender, nFps);
}

void __stdcall FFM_API_SetParameter(HANDLE hPlayer, DWORD id, DWORD param)
{
    if (!hPlayer) return;
    PLAYER *player = (PLAYER*)hPlayer;
    switch (id)
    {
	case PARAM_SET_CAM_ID:
		player->nCamID = param;
		break;
	case PARAM_SET_PLAY_SPEED:
		player->nPlaySpeed =  param;
		break;
	case PARAM_SET_CALLBACK:
	{
		EnterCriticalSection(player->pcsNotify);
		player->pNotifyCallBackFunc = (NotifyCallBackFunc)param;
		LeaveCriticalSection(player->pcsNotify);
		break;
	}
    case PARAM_RENDER_MODE:
        player->nRenderMode = param;
        break;
	case PARAM_IS_STREAMING:
		player->isStreaming = param;
		break;
	case PARAM_SET_OUT_URL:
		strcpy(player->szOutUrl, (char*)(param));
		break;
	case PARAM_SET_PLAY_MODE:
		player->play_mode = (PLAY_MODE)param;
		break;
    }
}

void __stdcall FFM_API_GetParameter(HANDLE hPlayer, DWORD id, void *param)
{
    if (!hPlayer || !param) return;
    PLAYER *player = (PLAYER*)hPlayer;

    switch (id)
    {
    case PARAM_VIDEO_WIDTH:
        if (!player->pVideoCodecContext) *(int*)param = 0;
        else *(int*)param = player->pVideoCodecContext->width;
        break;

    case PARAM_VIDEO_HEIGHT:
        if (!player->pVideoCodecContext) *(int*)param = 0;
        else *(int*)param = player->pVideoCodecContext->height;
        break;

    case PARAM_GET_DURATION:
        if (!player->pAVFormatContext) *(DWORD*)param = 0;
        else *(DWORD*)param = (DWORD)(player->pAVFormatContext->duration / AV_TIME_BASE);
        break;

    case PARAM_GET_POSITION:
        renderplaytime(player->hCoreRender, (DWORD*)param);
        break;

    case PARAM_RENDER_MODE:
        *(int*)param = player->nRenderMode;
		break;

	case PARAM_ASPECT_RATIO:
		if (!player->pVideoCodecContext) *(double*)param = 0;
		else *(double*)param = av_q2d(player->pVideoCodecContext->sample_aspect_ratio);
		break;
    }
}

HANDLE	__stdcall FFM_API_Init()
{
	PLAYER        *player   = NULL;

	player = (PLAYER*)malloc(sizeof(PLAYER));
	memset(player, 0, sizeof(PLAYER));
	static int nCount = 0;
	player->nID = nCount++;
	player->pcsNotify = new CRITICAL_SECTION;
	player->pcsBusy = new CRITICAL_SECTION;
	InitializeCriticalSection(player->pcsNotify);
	InitializeCriticalSection(player->pcsBusy);

	return player;
}

static DWORD WINAPI StreamingThread_(StreamingServerStruct * server)
{
	return server->server.Start(server->szInUrl, server->szRtspPort, server->szRtspName);
	//return 0;
}

void*	__stdcall FFM_API_StartRtspStreaming(const char *uri, const char* szRtspPort, const char* szRtspName, int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*))
{
	StreamingServerStruct *server = new StreamingServerStruct;

	if (strlen(szRtspPort) > 0)
	{
		strcpy(server->szInUrl, uri);
		strcpy(server->szRtspPort, szRtspPort);
		strcpy(server->szRtspName, szRtspName);

		server->hServerThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)StreamingThread_, server, 0, 0);
	}

	return server;
}

void	__stdcall FFM_API_StopRtspStreaming(void* handle)
{
	StreamingServerStruct *server = (StreamingServerStruct*)handle;

	if (!server)
		return;

	if (server->hServerThread)
	{
		server->server.Stop();
//		TRACE("WAIT HANDLE 5 : %x\n", server->hServerThread);
		while (WaitForSingleObject(server->hServerThread, 0))
		{
			DWORD dwThreadId = GetThreadId(server->hServerThread);
			server->server.Stop();
			Sleep(0);
//			TRACE("WAIT HANDLE 5 : %x\n", server->hServerThread);
		}
		CloseHandle(server->hServerThread);
		server->hServerThread = NULL;
	}
}

void processClosing(HANDLE hPlayer, BOOL doCheckOpeningEnd = TRUE)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (doCheckOpeningEnd && player->stage == 1)
	{
		while (player->stage != 2)
		{
			Sleep(50);
		}
	}


	//TerminateThread(player->hStreamingThread, 0);
	//if (player->nPlayerStatus != PLAYER_STOP)
	{
		playerstop(hPlayer); 
	}
	std::list<HWND> listRenderWindow;
	HANDLE           hCoreRender = NULL;
	if (player->hCoreRender)
	{
		GetRenderWindowList(player->hCoreRender, listRenderWindow);
		hCoreRender = player->hCoreRender;
		renderclose(player->hCoreRender);
		//player->hCoreRender = NULL;
	}

	if (player->pVideoCodecContext)
	{
		if (player->bUseDxva)
		{
			//dxva2_uninit(player->pVideoCodecContext);
			//av_free(player->pVideoCodecContext->hwaccel_context);
		}
		avcodec_close(player->pVideoCodecContext);

		if (player->bUseDxva)
			dxva2_uninit(player->pVideoCodecContext);

		player->pVideoCodecContext = NULL;
	}

	if (player->pAudioCodecContext)
	{
		avcodec_close(player->pAudioCodecContext);
		player->pAudioCodecContext = NULL;
	}

	if (player->pAVFormatContext)
	{
		avformat_close_input(&(player->pAVFormatContext));
		player->pAVFormatContext = NULL;
	}

	// destroy packet queue
	pktqueue_destroy(&(player->PacketQueue));

	//Render object`
#if 0

	fields to save and restore
	player->szInUrl;
	(RenderObject*)((RENDER)player->hCoreRender)->pRenderObject;
	player->play_mode;
	player->szRtspPort;
	player->szRtspName;
	player->pNotifyCallBackFunc

#endif
	//

	char szInUrl[1024];
	void* pRenderObject;
	PLAY_MODE		play_mode;
	char szRtspPort[16];
	char szRtspName[128];
	NotifyCallBackFunc funcTmp;
	
	strcpy(szInUrl, player->szInUrl);
	play_mode = player->play_mode;
	strcpy(szRtspPort, player->szRtspPort);
	strcpy(szRtspName, player->szRtspName);

	EnterCriticalSection(player->pcsNotify);
	funcTmp = player->pNotifyCallBackFunc;

	CRITICAL_SECTION* pCS = player->pcsNotify;
	CRITICAL_SECTION* pCSBusy = player->pcsBusy;
	memset(player, 0, sizeof(PLAYER));

	strcpy(player->szInUrl, szInUrl);
	player->play_mode = play_mode;
	strcpy(player->szRtspPort, szRtspPort);
	strcpy(player->szRtspName, szRtspName);
	
	player->pcsNotify = pCS;
	player->pcsBusy = pCSBusy;

	player->pNotifyCallBackFunc = funcTmp;
	LeaveCriticalSection(player->pcsNotify);

	player->hCoreRender = hCoreRender;
	std::list<HWND>::iterator iter;
	for (iter = listRenderWindow.begin(); iter != listRenderWindow.end(); iter++)
	{
		AddRenderWindow(player->hCoreRender, *iter);
	}
}

//#ifdef USE_HWACCEL
AVPixelFormat GetHwFormat(AVCodecContext *s, const AVPixelFormat *pix_fmts)
{
	InputStream* ist = (InputStream*)s->opaque;
	ist->active_hwaccel_id = HWACCEL_DXVA2;
	ist->hwaccel_pix_fmt = AV_PIX_FMT_DXVA2_VLD;
	return ist->hwaccel_pix_fmt;
}
//#endif

int processVideoReset(PLAYER* player)
{

	// get video & audio codec context
	player->iAudioStreamIndex = -1;
	player->iVideoStreamIndex = -1;

	for (int i = 0; i<player->pAVFormatContext->nb_streams; i++)
	{
		switch (player->pAVFormatContext->streams[i]->codec->codec_type)
		{
		case AVMEDIA_TYPE_AUDIO:
			player->iAudioStreamIndex = i;
			player->pAudioCodecContext = player->pAVFormatContext->streams[i]->codec;
			player->dAudioTimeBase = av_q2d(player->pAVFormatContext->streams[i]->time_base) * 1000;
			break;

		case AVMEDIA_TYPE_VIDEO:
			player->iVideoStreamIndex = i;
			//#ifndef USE_HWACCEL
			if (!player->bUseDxva)
				player->pVideoCodecContext = player->pAVFormatContext->streams[i]->codec;
			//#endif
			player->dVideoTimeBase = av_q2d(player->pAVFormatContext->streams[i]->time_base) * 1000;
			player->vrate = player->pAVFormatContext->streams[i]->r_frame_rate;
			break;
		}
	}
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		return 0; // goto stop_handler;
	}

	AVCodec* pAVCodec = NULL;

	// open audio codec
	if (player->iAudioStreamIndex != -1)
	{
		pAVCodec = avcodec_find_decoder(player->pAudioCodecContext->codec_id);
		if (pAVCodec)
		{
			if (avcodec_open2(player->pAudioCodecContext, pAVCodec, NULL) < 0)
			{
				player->iAudioStreamIndex = -1;
			}
		}
		else player->iAudioStreamIndex = -1;
	}

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		return 0; // goto stop_handler;
	}

	
	//#ifdef USE_HWACCEL
	int bRet = 1;
	if (player->bUseDxva)
	{
		player->pVideoCodecContext = avcodec_alloc_context3(nullptr);

		if (!player->pVideoCodecContext)
			return -1;

		if (avcodec_parameters_to_context(player->pVideoCodecContext, player->pAVFormatContext->streams[player->iVideoStreamIndex]->codecpar) < 0)
			return -1;
	}
//#endif
	// open video codec
	if (player->iVideoStreamIndex != -1)
	{
		pAVCodec = avcodec_find_decoder(player->pVideoCodecContext->codec_id);

//#ifdef USE_HWACCEL
		if (player->bUseDxva)
		{
			player->pVideoCodecContext->coded_width = player->pVideoCodecContext->width;
			player->pVideoCodecContext->coded_height = player->pVideoCodecContext->height;

			player->pVideoCodecContext->thread_count = 1;  // Multithreading is apparently not compatible with hardware decoding
			InputStream *ist = new InputStream();
			ist->hwaccel_id = HWACCEL_AUTO;
			ist->hwaccel_device = "dxva2";
			ist->dec = pAVCodec;
			ist->dec_ctx = player->pVideoCodecContext;

			player->pVideoCodecContext->opaque = ist;
			if (dxva2_init(player->pVideoCodecContext) >= 0)
			{
				player->pVideoCodecContext->get_buffer2 = ist->hwaccel_get_buffer;
				player->pVideoCodecContext->get_format = GetHwFormat;
				player->pVideoCodecContext->thread_safe_callbacks = 1;
			}
			else
			{
				delete ist;
				bRet = -1;
				player->pVideoCodecContext->opaque = nullptr;

				player->pVideoCodecContext->thread_count = 2;
				player->pVideoCodecContext->flags2 |= CODEC_FLAG2_FAST;
			}
		}
//#endif		

		if (pAVCodec)
		{
			if (avcodec_open2(player->pVideoCodecContext, pAVCodec, NULL) < 0)
			{
				player->iVideoStreamIndex = -1;
			}
		}
		else player->iVideoStreamIndex = -1;
		
	}

	// for video
	if (player->iVideoStreamIndex != -1)
	{
		player->nInputFps = player->pAVFormatContext->streams[player->iVideoStreamIndex]->r_frame_rate.num;
	}

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		return 0; //goto  stop_handler;
	}

	// for audio
	if (player->iAudioStreamIndex != -1)
	{
		player->alayout = player->pAudioCodecContext->channel_layout;

		if (player->alayout == 0)
			player->alayout = av_get_default_channel_layout(player->pAudioCodecContext->channels);

		player->aformat = player->pAudioCodecContext->sample_fmt;
		player->arate = player->pAudioCodecContext->sample_rate;
	}

	return bRet;
}

void __stdcall PlayerCallBack(HANDLE hPlayer, int nMode)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (nMode == 0)
	{
		SuspendThread(player->hVDecodeThread);
		int bRet = processVideoReset(player);
		if (bRet == 1)
			ResumeThread(player->hVDecodeThread);
		else if (bRet < 1)
		{
			player->bUseDxva = false;
			player->nPlayerStatus = PLAYER_FAILED;
			FFM_API_Close(hPlayer);
		}		
	}
	if (nMode == 4) // RENDER_FAILED
	{
		//player->nPlayerStatus = PLAYER_FAILED;
		//FFM_API_Close(hPlayer); 
		FFM_API_StopDecodingAndRendering(hPlayer);
	}
}

static DWORD WINAPI StreamingThread(PLAYER *player)
{
	player->streamServer.Start(player->szInUrl, player->szRtspPort, player->szRtspName);
	return 0;
}

void	__stdcall FFM_API_SetCaptureInterval(HANDLE hPlayer, int nInterval)
{
	PLAYER* player = (PLAYER*)hPlayer;

	if (player == NULL)
		return;

	player->nCaptureInterval = nInterval;
}

void	StartPlayThread(HANDLE hPlayer);
int __stdcall FFM_API_Open(HANDLE hPlayer, const char *uri, HWND hwnd, BOOL bUseDxva, PLAY_MODE play_mode, const char* szRtspPort, const char* szRtspName, int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*))
{
	//bUseDxva = FALSE;
	PLAYER* player = (PLAYER*)hPlayer;

 	if (player == NULL)
		return FALSE;

open_again:
	EnterCriticalSection(player->pcsNotify);
	player->pNotifyCallBackFunc = NotifyCallBack;
	LeaveCriticalSection(player->pcsNotify);

	player->nCaptureInterval = 500;

//	GetOSVersion(player);
	player->bUseDxva = bUseDxva;

	player->isPixFmtSet = false;

	player->stage = 1;

	player->bDecode = false;
	player->hWnd = hwnd;

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	AVInputFormat  *iFormat = NULL;

	// av register all
	avcodec_register_all();
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}
	av_register_all();
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}
	avformat_network_init();
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	int ret = 0;
	AVDictionary* options = NULL;

	av_dict_set(&player->format_opts, "analyzeduration", "2000", 0);	

	if (play_mode == MJPEG_PLAY)		
		av_dict_set(&player->format_opts, "f", "mjpeg", 0);
	else
	{
		av_dict_set(&player->format_opts, "stimeout", "8000000", 0);
		av_dict_set(&player->format_opts, "rtsp_transport", "tcp", 0);
		av_dict_set(&player->format_opts, "rtbufsize", "10000000", 0); 
	}

	// create packet queue
	pktqueue_create(&(player->PacketQueue));

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}	
	
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	// open input file		
	if (avformat_open_input(&(player->pAVFormatContext), uri, iFormat, &player->format_opts) != 0)
	{
		goto error_handler;
	}

	if (player->pAVFormatContext == NULL)
	{
		Sleep(0);
	}

	AVCodec       *pAVCodec = NULL;
	player->vrate = { 1, 1 };	
	uint32_t       i = 0;
	AVDictionary **opts = NULL;
	AVDictionaryEntry *t;

	//	if (play_mode != RTSP_PLAY_FILE)
	{
		if ((t = av_dict_get(player->format_opts, "", NULL, AV_DICT_IGNORE_SUFFIX))) {
			av_log(NULL, AV_LOG_ERROR, "Option %s not found.\n", t->key);
			ret = RTSP_CONNECTION_FAILED;
			goto error_handler;
		}
		opts = setup_find_stream_info_opts((player->pAVFormatContext), player->codec_opts);
	}  

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}
	// find stream info

	if (avformat_find_stream_info(player->pAVFormatContext, opts) < 0)
	{
		ret = RTSP_CONNECTION_FAILED;
		goto error_handler;
	}

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	player->pAVFormatContext->flags |= AVFMT_FLAG_DISCARD_CORRUPT;
	player->pAVFormatContext->flags |= AVFMT_FLAG_NOBUFFER;


	int bRet = processVideoReset(player);
	if (bRet == -1)
	{
		player->bUseDxva = false;
		ret = DXVA_INIT_FAILED;
		goto error_handler;
	}
	else if (bRet == 0)
	{
		goto error_handler;
	}

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}	


	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	if (player->iAudioStreamIndex == -1 && player->iVideoStreamIndex == -1)
	{
		ret = RTSP_CODEC_OPEN_FAILED;
		goto error_handler;
	}

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}

	// ----------------------for the recording.............
	player->play_mode = play_mode;

	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}
	
	if (player->nPlayerStatus == PLAYER_STOP || player->nPlayerStatus == PLAYER_FAILED)
	{
		goto stop_handler;
	}
	

	player->stage = 2;

	player->nPlayerStatus = PLAYER_PLAY;

	StartPlayThread(player);

	avcodec_close(player->pVideoCodecContext);

	if (player->bUseDxva)
		dxva2_uninit(player->pVideoCodecContext);

	player->pVideoCodecContext = NULL;

	return TRUE;

error_handler:
	processClosing(hPlayer, FALSE);

	if (ret == DXVA_INIT_FAILED)
	{
		bUseDxva = false;
		goto open_again;
	}
	
	return ret;

stop_handler:
	player->stage = 2;
	return FALSE;
}

void	__stdcall FFM_API_Close(HANDLE hPlayer)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	NotifyCallBack(player, (int)NOTIFY_PROCESS_CANCELED, 0, NULL);
	if (player->closing == 1)
		return;
//	TRACE("FFM_CLOSE\n");
	player->closing = 1;
	player->nPlayerStatus = PLAYER_STOP;
	processClosing(hPlayer);
	NotifyCallBack(player, (int)NOTIFY_PROCESS_CANCELED, 0, NULL);
	
	player->closing = 2;
	// stop player first

//	renderclose(player->hCoreRender);
	renderrelease(player->hCoreRender);
	player->hCoreRender = NULL;

	free(player->ppWatingPkts);
}

void	__stdcall FFM_API_Release(HANDLE hPlayer)
{
	
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	
//	TRACE("Player Release %d\n", GetThreadId(player->hPlayerThread));
	FFM_API_Close(hPlayer);
	DeleteCriticalSection(player->pcsNotify);
	DeleteCriticalSection(player->pcsBusy);
	delete player->pcsNotify;
	delete player->pcsBusy;
	free(player);
	player = NULL;
}


void	__stdcall FFM_API_SetColorAdjusting(HANDLE hPlayer, /*int nAlpha ,*/ int nBright , int nContrast , int nHue , int nSaturation )
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;

	rendersetcoloradjusting(player->hCoreRender, /*nAlpha,*/ nBright, nContrast, nHue, nSaturation);
}

void	__stdcall FFM_API_GetDefaultColorAdjusting(HANDLE hPlayer, int& nDefBright, int& nDefContrast, int& nDefHue, int& nDefSaturation)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;

	int nnBright, nnContrast, nnHue, nnSaturation;

	rendergetdefaultcoloradjusting(player->hCoreRender, nnBright, nnContrast, nnHue, nnSaturation);

	nDefBright = nnBright; nDefContrast = nnContrast; nDefHue = nnHue; nDefSaturation = nnSaturation;
}

void	__stdcall FFM_API_GetColorAdjusting(HANDLE hPlayer, /*int nAlpha ,*/ int& nBright, int& nContrast, int& nHue, int& nSaturation)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;

	int nnBright, nnContrast, nnHue, nnSaturation;

	rendergetcoloradjusting(player->hCoreRender, /*nAlpha,*/ nnBright, nnContrast, nnHue, nnSaturation);

	nBright = nnBright; nContrast = nnContrast; nHue = nnHue; nSaturation = nnSaturation;
}

BOOL	__stdcall FFM_API_StartDecodingAndRendering(HANDLE hPlayer, HWND hwnd)
{
	if (!hPlayer) return FALSE;

	PLAYER* player = (PLAYER*)hPlayer;
	if (player->nPlayerStatus == PLAYER_STOP)
	{
		return FALSE;
	}
	EnterCriticalSection(player->pcsBusy);
	TRACE("FFM_API_StartDecodingAndRendering : 01 %x\n", player->nPlayerStatus);
	int bRet = processVideoReset(player);
	TRACE("FFM_API_StartDecodingAndRendering : 02 %x\n", hPlayer);
	if (bRet < 0)
	{
		LeaveCriticalSection(player->pcsBusy);
		return FALSE;
	}

	if (player->hCoreRender) return FALSE;

	if (player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL)
	{
		LeaveCriticalSection(player->pcsBusy);

		return FALSE;
	}
	TRACE("FFM_API_StartDecodingAndRendering : 03 %x\n", hPlayer);
	
	
	if (player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL)
	{
		LeaveCriticalSection(player->pcsBusy);

		return FALSE;
	}
	

	if (hwnd == NULL)
		hwnd = player->hWnd;

	TRACE("FFM_API_StartDecodingAndRendering : 04 %x\n", hPlayer);
	if (player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL)
	{
		LeaveCriticalSection(player->pcsBusy);

		return FALSE;
	}
	
	TRACE("FFM_API_StartDecodingAndRendering : 05 %d\n", player->nPlayerStatus);
	pktqueue_create_decPkts(&player->PacketQueue);
	
	TRACE("FFM_API_StartDecodingAndRendering : 06 %d\n", player->nPlayerStatus);
	if (player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL || player->pVideoCodecContext == NULL)
	{
		LeaveCriticalSection(player->pcsBusy);

		return FALSE;
	}
	
	player->hCoreRender = renderopen(hwnd, 
									player->bUseDxva, 
									player->bDecode, 
									player->vrate, 
									player->pVideoCodecContext->pix_fmt,
									player->pVideoCodecContext->width, 
									player->pVideoCodecContext->height, 
									player->alayout, 
									(AVSampleFormat)player->aformat, 
									player->pVideoCodecContext, 
									player->arate); 

	rendersetdecodemode(player->hCoreRender, true);

	TRACE("FFM_API_StartDecodingAndRendering : 06 %d\n", player->nPlayerStatus);
	SetPlayerCallback(player->hCoreRender, player, PlayerCallBack);
	TRACE("FFM_API_StartDecodingAndRendering : 07 %d\n", player->nPlayerStatus);
	FFM_API_SetPlayFPS(hPlayer, player->vrate.num);

	TRACE("waiting packets count ---------- %d\n", player->nPlayerStatus);
	TRACE("XXXXXXXXXX %x\n", player->pVideoCodecContext);
	avcodec_flush_buffers(player->pVideoCodecContext);
	
	TRACE("FFM_API_StartDecodingAndRendering : 08 %x\n", hPlayer);
	for (int i = 0; i < player->nWatingPkts; i++)
	{
		AVPacket* packet = player->ppWatingPkts[i];

		AVFrame* vframe = NULL; int gotvideo = 0;
		vframe = av_frame_alloc();
		avcodec_decode_video(player->pVideoCodecContext, vframe, &gotvideo, packet);
		av_frame_unref(vframe);
		av_frame_free(&vframe);

	}
	
	TRACE("FFM_API_StartDecodingAndRendering : 09 %x\n", hPlayer);
	player->bDecode = true;
	{
		player->bFirstStart = player->bAudFirstStart = true;

		if (!player->hADecodeThread) {
			player->hADecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)AudioDecodeThreadProc, player, 0, 0);
		}

		if (!player->hVDecodeThread) {
			TRACE("FFM_API_StartDecodingAndRendering : VideoDecodeThreadProc\n");
			player->hVDecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)VideoDecodeThreadProc, player, 0, 0);
		}

		renderstart(player->hCoreRender);
	}

	LeaveCriticalSection(player->pcsBusy);

	return TRUE;
}

void	__stdcall FFM_API_StopDecodingAndRendering(HANDLE hPlayer)
{
	if (!hPlayer) return;

	PLAYER* player = (PLAYER*)hPlayer;

	rendersetdecodemode(player->hCoreRender, false);

	player->nWatingPkts = 0;

	player->bDecode = false;

	//HANDLE hCoreRender = player->hCoreRender;
	//player->hCoreRender = NULL;

	if (player->hADecodeThread)
	{
		//		TRACE("WAIT HANDLE 3 : %x\n", player->hADecodeThread);
		WaitForSingleObject(player->hADecodeThread, -1);
		CloseHandle(player->hADecodeThread);
		player->hADecodeThread = NULL;
	}
	if (player->hVDecodeThread)
	{
		//		TRACE("WAIT HANDLE 4 : %x\n", player->hVDecodeThread);
		WaitForSingleObject(player->hVDecodeThread, -1);
		CloseHandle(player->hVDecodeThread);
		player->hVDecodeThread = NULL;
	}
	renderpause(player->hCoreRender);

	renderclose(player->hCoreRender);
	renderrelease(player->hCoreRender);


	player->hCoreRender = NULL;

	pktqueue_destroy_decPkts(&(player->PacketQueue));
	//if (player->PacketQueue.vpkts)
	//{
	//	free(player->PacketQueue.vpkts);
	//	player->PacketQueue.vpkts = NULL;
	//	player->PacketQueue.vhead = player->PacketQueue.vtail = 0;
	//}

	//if (player->PacketQueue.apkts)
	//{
	//	free(player->PacketQueue.apkts);
	//	player->PacketQueue.apkts = NULL;
	//	player->PacketQueue.ahead = player->PacketQueue.atail = 0;
	//}

	//if (player-)

	avcodec_close(player->pVideoCodecContext);

	if (player->bUseDxva)
		dxva2_uninit(player->pVideoCodecContext);

	player->pVideoCodecContext = NULL;  

}

void	StartPlayThread(HANDLE hPlayer)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	
	if (player->pAVFormatContext == NULL)
	{
		Sleep(0);
	}

	player->ppWatingPkts = (AVPacket**)malloc(WAITING_PKTS_COUNT * sizeof(AVPacket*));
	player->nWatingPkts = 0;

	if (!player->hPlayerThread) {
		if (player->pAVFormatContext == NULL)
		{
			Sleep(0);
		}
		player->hPlayerThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)PlayThreadProc, player, 0, 0);
		DWORD dwThreadId = GetThreadId(player->hPlayerThread);
		//TRACE("Create Play StartPlay: %d\n", dwThreadId);

	}

	//{
	//	player->bFirstStart = player->bAudFirstStart = true;

	//	if (!player->hADecodeThread) {
	//		player->hADecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)AudioDecodeThreadProc, player, 0, 0);
	//	}

	//	if (!player->hVDecodeThread) {
	//		player->hVDecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)VideoDecodeThreadProc, player, 0, 0);
	//	}

	//	renderstart(player->hCoreRender);
	//}

}

void	__stdcall FFM_API_Resume(HANDLE hPlayer)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	player->nPlayerStatus = PLAYER_PLAY;

	if (player->pAVFormatContext == NULL)
	{
		Sleep(0);
	}

	if (!player->hPlayerThread) {
		if (player->pAVFormatContext == NULL)
		{
			Sleep(0);
		}
		player->hPlayerThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)PlayThreadProc, player, 0, 0);
		DWORD dwThreadId = GetThreadId(player->hPlayerThread);
		//TRACE("Create Play Resume: %d\n", dwThreadId);

	}

	//{
	//	player->bFirstStart = player->bAudFirstStart = true;

	//	if (!player->hADecodeThread) {
	//		player->hADecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)AudioDecodeThreadProc, player, 0, 0);
	//	}

	//	if (!player->hVDecodeThread) {
	//		player->hVDecodeThread = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)VideoDecodeThreadProc, player, 0, 0);
	//	}

	//	renderstart(player->hCoreRender);
	//}
	
}

void	__stdcall FFM_API_Pause(HANDLE hPlayer)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	player->nPlayerStatus = PLAYER_PAUSE;
	player->bFirstStart = true;
	player->bAudFirstStart = true;
	renderpause(player->hCoreRender);
}

void	__stdcall FFM_API_SetActive(HANDLE hPlayer, BOOL bActive)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;

	player->bActive = bActive!=FALSE? true:false;

	rendersetactive(player->hCoreRender, bActive);
}

BOOL	__stdcall FFM_API_IsDecoding(HANDLE handle)
{
	if (handle == NULL)
		return FALSE;
	return (((PLAYER*)handle)->bDecode != false);
}

BOOL	__stdcall FFM_API_IsRecording(HANDLE handle)
{
	if (handle == NULL)
		return FALSE;
	return ((PLAYER*)handle)->isRecording;
}

void	__stdcall FFM_API_SetPos(HANDLE hPlayer, DWORD sec)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;

	BOOL ispaused = (player->nPlayerStatus == PLAYER_PAUSE);
	//if (ispaused) FFM_API_Resume(hPlayer);

	player->nPlayerStatus = PLAYER_SEEK;
	while (!pktqueue_isempty_a(&(player->PacketQueue))) Sleep(50);
	while (!pktqueue_isempty_v(&(player->PacketQueue))) Sleep(50);

	// seek frame
	av_seek_frame(player->pAVFormatContext, -1, (int64_t)sec * AV_TIME_BASE, 0);
	if (player->iAudioStreamIndex != -1) avcodec_flush_buffers(player->pAudioCodecContext);
	if (player->iVideoStreamIndex != -1) avcodec_flush_buffers(player->pVideoCodecContext);

	// flush render
	renderflush(player->hCoreRender, sec);

	// return to PLAYER_PLAY status
	player->nPlayerStatus = PLAYER_PLAY;

	if (ispaused) FFM_API_Pause(hPlayer);
}
void	__stdcall FFM_API_SetRenderMode(HANDLE hPlayer, BOOL bMode)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	SetRenderMode(player->hCoreRender, bMode != FALSE? true: false);
}

void	__stdcall FFM_API_SetPlayRect(HANDLE hPlayer, int left, int top, int right, int bottom)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	SetRenderRect(player->hCoreRender, left, top, right, bottom);
}

void	setplayrect(HANDLE hPlayer, int left, int top, int right, int bottom)
{
	if (!hPlayer) return;
	PLAYER *player = (PLAYER*)hPlayer;
	double aspect;
	int vw, vh;
	FFM_API_GetParameter(hPlayer, PARAM_VIDEO_WIDTH , &vw);
	FFM_API_GetParameter(hPlayer, PARAM_VIDEO_HEIGHT, &vh);

	int x, y;
	if(left == 0 && top == 0 && right == -1 && bottom == -1)
	{
		left = top = 0;
		right = vw;
		bottom = vh;
	}
	x = left;
	y = top;
	int w, h;
	w = right - left;
	h = bottom - top;

	int rw, rh;

	if (!vw || !vh) return;

	FFM_API_GetParameter(hPlayer, PARAM_ASPECT_RATIO, &aspect);

	switch (player->nRenderMode)
	{
	case RENDER_MATCH_ASPECT:
		//if (aspect > 0.0) {
		//vw *= aspect;
		//} else {
		vw = vh * 4.0/3.0;
		//}

	case RENDER_LETTERBOX:
		if (w * vh < h * vw) { rw = w; rh = rw * vh / vw; }
		else                 { rh = h; rw = rh * vw / vh; }
		break;

	case RENDER_STRETCHED:
		rw = w;
		rh = h;
		break;

	}
	rendersetrect(player->hCoreRender, x + (w - rw) / 2, y + (h - rh) / 2, rw, rh);

}

void __stdcall FFM_API_AddRenderWindow(HANDLE hPlayer, HWND hWnd)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (player)
	{
		if (player->hCoreRender)
		{
			AddRenderWindow(player->hCoreRender, hWnd);
		}
	}
}

void __stdcall FFM_API_RemoveRenderWindow(HANDLE hPlayer, HWND hWnd)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (player)
	{
		if (player->hCoreRender)
		{
			RemoveRenderWindow(player->hCoreRender, hWnd);
		}
	}
}

void __stdcall FFM_API_SetNotifyProc(HANDLE hPlayer, int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*))
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (player)
	{
		EnterCriticalSection(player->pcsNotify);
		player->pNotifyCallBackFunc = NotifyCallBack;
		LeaveCriticalSection(player->pcsNotify);
	}
}

void	__stdcall FFM_API_RemoveNotifyProc(HANDLE hPlayer)
{
	PLAYER* player = (PLAYER*)hPlayer;
	if (player)
	{
		EnterCriticalSection(player->pcsNotify);
		player->pNotifyCallBackFunc = NULL;
		LeaveCriticalSection(player->pcsNotify);
	}
}
