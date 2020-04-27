#ifndef _PLAYER_H_
#define _PLAYER_H_
#define _WINSOCKAPI_ 
#include <Windows.h>

#ifdef __cplusplus
extern "C" {
#endif

// message
#define MSG_COREPLAYER  (WM_APP + 1)
#define PLAY_COMPLETED  (('E' << 24) | ('N' << 16) | ('D' << 8))

// render mode
enum {
    RENDER_LETTERBOX,
	RENDER_STRETCHED,
	RENDER_MATCH_ASPECT,
};

// param
enum {
	PARAM_SET_CAM_ID,
	PARAM_SET_PLAY_SPEED,
    PARAM_VIDEO_WIDTH,
    PARAM_VIDEO_HEIGHT,
    PARAM_GET_DURATION,
    PARAM_GET_POSITION,
    PARAM_RENDER_MODE,
	PARAM_ASPECT_RATIO,
	PARAM_IS_STREAMING,
	PARAM_SET_PLAY_MODE,
	PARAM_SET_OUT_URL,
	PARAM_SET_CALLBACK
};

typedef enum { 
	RTSP_PLAY = 0,
	MJPEG_PLAY = 1,
	LOCAL_PLAY = 2
}PLAY_MODE;

typedef enum {
//	RTSP_CONNECTION_SUCCESSED = 0,
	RTSP_CONNECTION_FAILED = -1,
	RTSP_DISCONNECTED = -2,
	RTSP_RENDER_OPEN_FAILED = -3,
	RTSP_CODEC_OPEN_FAILED = -4,
	DXVA_INIT_FAILED = -5
};

HANDLE	 __stdcall FFM_API_XVRRecorderOpen(const char *szOutUrl, int nWidth, int nHeight);
void	 __stdcall FFM_API_XVRRecorderPutPacket(HANDLE hRecorder, void* pPkt);
void	 __stdcall FFM_API_XVRRecorderClose(HANDLE hRecorder);


HANDLE	__stdcall FFM_API_Init();
void	__stdcall FFM_API_Release(HANDLE hPlayer);
int		__stdcall FFM_API_Open(HANDLE hPlayer, const char *uri, HWND hwnd, BOOL bUseDxva, PLAY_MODE play_mode, const char* szRtspPort, const char* szRtspName,
	int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*));
BOOL	__stdcall FFM_API_StartDecodingAndRendering(HANDLE hPlayer, HWND hwnd);
void	__stdcall FFM_API_StopDecodingAndRendering(HANDLE hPlayer);
BOOL	__stdcall FFM_API_StartRecording(HANDLE hPlayer, const char *szOutUrl, int mode, int nPreRecTime);
void	__stdcall FFM_API_StopRecording(HANDLE hPlayer, int nAfterRecTime);
void	__stdcall FFM_API_GenerateSignal(HANDLE hPlayer, int nAfterSec);
void	__stdcall FFM_API_Close(HANDLE hPlayer);
void	__stdcall FFM_API_Resume(HANDLE hPlayer);
void	__stdcall FFM_API_Screenshot(HANDLE hPlayer, char* szShotPath);
void	__stdcall FFM_API_SetColorAdjusting
		(
			HANDLE hPlayer, /*int nAlpha,*/ 
			int nBright /* default 50*/, 
			int nContrast /*default 10*/, 
			int nHue /*default 50*/,
			int nSaturation/*default 10*/ 
		);
void	__stdcall FFM_API_GetColorAdjusting
		(
			HANDLE hPlayer, /*int nAlpha,*/
			int &nBright /* default 50*/,
			int &nContrast /*default 10*/,
			int &nHue /*default 50*/,
			int &nSaturation/*default 10*/
		);
void	__stdcall FFM_API_GetDefaultColorAdjusting
		(
			HANDLE hPlayer, /*int nAlpha,*/
			int &nDefBright /* default 50*/,
			int &nDefContrast /*default 10*/,
			int &nDefHue /*default 50*/,
			int &nDefSaturation/*default 10*/
		);
void	__stdcall FFM_API_Pause(HANDLE hPlayer);
void	__stdcall FFM_API_SetActive(HANDLE hPlayer, BOOL bActive = TRUE);
BOOL	__stdcall FFM_API_IsDecoding(HANDLE hPlayer);
BOOL	__stdcall FFM_API_IsRecording(HANDLE hPlayer);
void	__stdcall FFM_API_SetPos(HANDLE hPlayer, DWORD sec);
void	__stdcall FFM_API_SetPlayRect(HANDLE hPlayer, int left, int top, int right, int bottom);
void	__stdcall FFM_API_SetRenderMode(HANDLE hPlayer, BOOL bMode);
DWORD	__stdcall FFM_API_GetLength(HANDLE hPlayer);
void	__stdcall FFM_API_SetCaptureInterval(HANDLE hPlayer, int nInterval);
void*	__stdcall FFM_API_StartRtspStreaming(const char *uri, const char* szRtspPort, const char* szRtspName, int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*));
void	__stdcall FFM_API_StopRtspStreaming(void* handle);
void	__stdcall FFM_API_SetParameter(HANDLE hPlayer, DWORD id, DWORD param);
void	__stdcall FFM_API_GetParameter(HANDLE hPlayer, DWORD id, void *param);
void	__stdcall FFM_API_AddRenderWindow(HANDLE hPlayer, HWND hWnd);
void	__stdcall FFM_API_RemoveRenderWindow(HANDLE hPlayer, HWND hWnd);
void	__stdcall FFM_API_SetNotifyProc(HANDLE hPlayer, int(__stdcall *NotifyCallBack)(HANDLE, int, int, char*));
void	__stdcall FFM_API_RemoveNotifyProc(HANDLE hPlayer);
void	__stdcall FFM_API_SetPlayFPS(HANDLE hPlayer, int nFps);
void	__stdcall FFM_API_SetMotionDetectSignal(HANDLE hPlayer, long lSensitivity); //if lSensitivity = -1, Stop Motion Detection 

BOOL    __stdcall FFM_API_Initialize();
BOOL    __stdcall FFM_API_UnInitialize();

BOOL	__stdcall IsRunningOnWindows10();
BOOL	__stdcall HaveGPU();
#ifdef __cplusplus
}
#endif

#endif















