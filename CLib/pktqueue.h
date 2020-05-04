#ifndef _PKT_QUEUE_H_
#define _PKT_QUEUE_H_
#define _WINSOCKAPI_ 
#include <windows.h>
#include <queue>

#ifdef __cplusplus
extern "C" {
#endif

// avformat.h
#include "libavformat/avformat.h"

#define DEF_PKT_QUEUE_ASIZE  1000 // 512
#define DEF_PKT_QUEUE_VSIZE  250 // 512

/*typedef struct frmque
{
	long       fsize;
	long       asize;
	long       vsize;
	long       fhead;
	long       ftail;
	long       ahead;
	long       atail;
	long       vhead;
	long       vtail;
	long       ffrmnum;
	long       afrmnum;
	long       vfrmnum;
	CRITICAL_SECTION csVFrm;
	CRITICAL_SECTION csAFrm;
	AVFrame		**afrms; // audio packets
	AVFrame		**vfrms; // video packets
}FRMQUEUE; */

typedef struct pktqueue
{
	long       fsize;
	long       asize;
	long       vsize;
	long       fhead;
	long       ftail;
	long       ahead;
	long       atail;
	long       vhead;
	long       vtail;
	long       fpktnum;
	long       apktnum;
	long       vpktnum;
	HANDLE     fsemr;
	HANDLE     asemr;
	HANDLE     asemw;
	HANDLE     vsemr;
	HANDLE     vsemw;
	AVPacket  *bpkts; // packet buffers
	AVPacket **fpkts; // free packets
	AVPacket **apkts; // audio packets
	AVPacket **vpkts; // video packets
}PKTQUEUE;

BOOL pktqueue_create (PKTQUEUE *ppq);
void pktqueue_destroy(PKTQUEUE *ppq);
void pktqueue_create_decPkts(PKTQUEUE* ppq);
void pktqueue_destroy_decPkts(PKTQUEUE* ppq);

bool pktqueue_write_request(PKTQUEUE *ppq, AVPacket **pppkt);
void pktqueue_write_release(PKTQUEUE *ppq, bool bIncrease);
void pktqueue_write_done_a(PKTQUEUE *ppq, bool bDecode);
void pktqueue_write_done_v(PKTQUEUE *ppq, bool bDecode);
BOOL pktqueue_isempty_a(PKTQUEUE *ppq);
BOOL pktqueue_isempty_v(PKTQUEUE *ppq);


int64_t pktqueue_get_cur_pts(PKTQUEUE *ppq);

void pktqueue_read_request(PKTQUEUE *ppq, AVPacket **pppkt, long pos);
void pktqueue_read_done(PKTQUEUE *ppq);

bool pktqueue_read_request_a(PKTQUEUE *ppq, AVPacket **pppkt);
void pktqueue_read_done_a  (PKTQUEUE *ppq);

bool pktqueue_read_request_v(PKTQUEUE *ppq, AVPacket **pppkt);
void pktqueue_read_done_v  (PKTQUEUE *ppq);

long pktqueue_find_record_start_pos(PKTQUEUE* ppq, int index, int64_t iCurPTS, int preSec);
#ifdef __cplusplus
}
#endif

#endif





