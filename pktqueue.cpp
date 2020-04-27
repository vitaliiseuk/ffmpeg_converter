#define _WINSOCKAPI_ 
#include <windows.h>
#include "pktqueue.h"
#include "play_common.h"

void pktqueue_create_decPkts(PKTQUEUE* ppq)
{
	// default size
	if (ppq->asize == 0) ppq->asize = DEF_PKT_QUEUE_ASIZE;
	if (ppq->vsize == 0) ppq->vsize = DEF_PKT_QUEUE_VSIZE;

	ppq->apkts = (AVPacket**)malloc(ppq->asize * sizeof(AVPacket*));
	ppq->vpkts = (AVPacket**)malloc(ppq->vsize * sizeof(AVPacket*));

	memset(ppq->apkts, 0, ppq->asize * sizeof(AVPacket*));
	memset(ppq->vpkts, 0, ppq->vsize * sizeof(AVPacket*));

	ppq->asemr = CreateSemaphore(NULL, 0, ppq->asize, NULL);
	ppq->asemw = CreateSemaphore(NULL, ppq->asize, ppq->asize, NULL);
	ppq->vsemr = CreateSemaphore(NULL, 0, ppq->vsize, NULL);
	ppq->vsemw = CreateSemaphore(NULL, ppq->vsize, ppq->vsize, NULL);
}

void pktqueue_destroy_decPkts(PKTQUEUE* ppq)
{
	if (ppq->apkts) free(ppq->apkts);
	if (ppq->vpkts) free(ppq->vpkts);

	ppq->apkts = ppq->vpkts = NULL;

	// close
	if (ppq->asemr) CloseHandle(ppq->asemr);
	if (ppq->asemw) CloseHandle(ppq->asemw);
	if (ppq->vsemr) CloseHandle(ppq->vsemr);
	if (ppq->vsemw) CloseHandle(ppq->vsemw);

	ppq->asemr = ppq->asemw = 0;
	ppq->vsemr = ppq->vsemw = 0;
}

BOOL pktqueue_create(PKTQUEUE *ppq)
{
    int i;

    // default size
    if (ppq->asize == 0) ppq->asize = DEF_PKT_QUEUE_ASIZE;
    if (ppq->vsize == 0) ppq->vsize = DEF_PKT_QUEUE_VSIZE;
    ppq->fsize = ppq->asize + ppq->vsize;

    // alloc buffer & semaphore
    ppq->bpkts = (AVPacket* )malloc(ppq->fsize * sizeof(AVPacket ));
    ppq->fpkts = (AVPacket**)malloc(ppq->fsize * sizeof(AVPacket*));
//    ppq->apkts = (AVPacket**)malloc(ppq->asize * sizeof(AVPacket*));
//    ppq->vpkts = (AVPacket**)malloc(ppq->vsize * sizeof(AVPacket*));
#if 1
    ppq->fsemr = CreateSemaphore(NULL, ppq->fsize, ppq->fsize, NULL);
    //ppq->asemr = CreateSemaphore(NULL, 0         , ppq->asize, NULL);
    //ppq->asemw = CreateSemaphore(NULL, ppq->asize, ppq->asize, NULL);
    //ppq->vsemr = CreateSemaphore(NULL, 0         , ppq->vsize, NULL);
    //ppq->vsemw = CreateSemaphore(NULL, ppq->vsize, ppq->vsize, NULL);
#else
	ppq->fsemr = CreateSemaphore(NULL, 1, 1, NULL);
	ppq->asemr = CreateSemaphore(NULL, 0, 1, NULL);
	ppq->asemw = CreateSemaphore(NULL, 1, 1, NULL);
	ppq->vsemr = CreateSemaphore(NULL, 0, 1, NULL);
	ppq->vsemw = CreateSemaphore(NULL, 1, 1, NULL);

#endif

    // check invalid
    if (  !ppq->bpkts || !ppq->fpkts || /*!ppq->apkts || !ppq->vpkts ||*/ !ppq->fsemr /*|| !ppq->asemr || !ppq->asemw || !ppq->vsemr || !ppq->vsemw*/) {
        pktqueue_destroy(ppq);
        return FALSE;
    }

    // clear packets
    memset(ppq->bpkts, 0, ppq->fsize * sizeof(AVPacket ));
    //memset(ppq->apkts, 0, ppq->asize * sizeof(AVPacket*));
    //memset(ppq->vpkts, 0, ppq->vsize * sizeof(AVPacket*));

    // init fpkts & fpktnum
    for ( i = 0 ; i < ppq->fsize ; i++ ) 
	{
        ppq->fpkts[i] = &(ppq->bpkts[i]);
    }
    ppq->fpktnum = ppq->fsize;
    return TRUE;
}

void pktqueue_destroy(PKTQUEUE *ppq)
{ 
    // free 
	for (int i = 0; i < ppq->fsize; i++)
	{
		if (ppq->fpkts[i])
		{
			av_packet_unref(ppq->fpkts[i]);

			//if (ppq->fpkts[i]->buf)
			av_free_packet((ppq->fpkts[i]));
		}
	}

    if (ppq->bpkts) free(ppq->bpkts);
    if (ppq->fpkts) free(ppq->fpkts);
    if (ppq->apkts) free(ppq->apkts);
    if (ppq->vpkts) free(ppq->vpkts);

    // close
    if (ppq->fsemr) CloseHandle(ppq->fsemr);
    if (ppq->asemr) CloseHandle(ppq->asemr);
    if (ppq->asemw) CloseHandle(ppq->asemw);
    if (ppq->vsemr) CloseHandle(ppq->vsemr);
    if (ppq->vsemw) CloseHandle(ppq->vsemw);

    // clear members
    memset(ppq, 0, sizeof(PKTQUEUE));
}

long pktqueue_find_record_start_pos(PKTQUEUE* ppq, int index, int64_t iCurPTS, int preSec)
{
//	//////TRACE("WAIT HANDLE 6 : %x\n", ppq->fsemr);
	WaitForSingleObject(ppq->fsemr, -1);

	long fhead = ppq->fhead - 1, ftail = ppq->ftail;
	
	if (fhead < 0) fhead = ppq->fsize - 1;

	while (1)
	{
		if (ppq->fpkts[fhead]->buf == NULL)
		{
			fhead++;
			if (fhead == ppq->fsize)
				fhead = 0;

			ReleaseSemaphore(ppq->fsemr, 1, NULL);
			return fhead;
		}

		if (ppq->fpkts[fhead]->stream_index == index)
		{
			if (ppq->fpkts[fhead]->pts <= iCurPTS)
				break;
		}

		fhead--;
		
		if (fhead < 0)
			fhead = ppq->fsize - 1;

		if (fhead == ppq->fhead)
		{
			fhead++;

			if (fhead == ppq->fsize)
				fhead = 0;

			ReleaseSemaphore(ppq->fsemr, 1, NULL);
			return fhead;
		}
	}

	int count = preSec;

	while (count > 0 || !(ppq->fpkts[fhead]->stream_index == index && ppq->fpkts[fhead]->flags & AV_PKT_FLAG_KEY))
	{
		fhead--;

		if (fhead < 0)
			fhead = ppq->fsize - 1;

		if (ppq->fpkts[fhead]->stream_index == index)
			count--;

		if (ppq->fpkts[fhead]->buf == NULL)
		{
			fhead++;
			if (fhead == ppq->fsize)
				fhead = 0;

			ReleaseSemaphore(ppq->fsemr, 1, NULL);
			return fhead;
		}

		if (fhead == ppq->fhead)
		{
			fhead++;

			if (fhead == ppq->fsize)
				fhead = 0;

			ReleaseSemaphore(ppq->fsemr, 1, NULL);
			return fhead;
		}
	}

	ReleaseSemaphore(ppq->fsemr, 1, NULL);

	return fhead;
}

bool pktqueue_write_request(PKTQUEUE *ppq, AVPacket **pppkt)
{

	if (WaitForSingleObject(ppq->fsemr, 50) == WAIT_TIMEOUT)
	{
		return false;
	}

	/*WaitForSingleObject(ppq->fsemr, -1);*/
    if (pppkt) *pppkt = ppq->fpkts[ppq->fhead];

	if ((ppq->fpkts[ppq->fhead])->buf)
	{
		ppq->ftail = ppq->fhead + 1;
		//InterlockedIncrement(&(ppq->ftail));
		InterlockedCompareExchange(&(ppq->ftail), 0, ppq->fsize);
	}

	//if ((*pppkt)->buf  == NULL)
	//{
	//	int n = 0;
	//}
	//else
	//{
	//	int n = 0;
	//}
	//////TRACE("pktqueue_write_request-------------%d\n", ppq->fhead);
	return true;
}

void pktqueue_write_release(PKTQUEUE *ppq, bool bIncrease)
{
    ReleaseSemaphore(ppq->fsemr, 1, NULL);

	if (bIncrease)
	{
		InterlockedIncrement(&(ppq->fhead));
		InterlockedCompareExchange(&(ppq->fhead), 0, ppq->fsize);
	}
}

void pktqueue_write_done_a(PKTQUEUE *ppq, bool bDecode)
{
//	//////TRACE("WAIT HANDLE 17 : %x\n", ppq->asemw);
    
	if (bDecode)
	{
		WaitForSingleObject(ppq->asemw, -1);

		ppq->apkts[ppq->atail] = ppq->fpkts[ppq->fhead];

		////TRACE("pktqueue_write_done_a ---- atail -------- %d\n", ppq->atail);
		////TRACE("pktqueue_write_done_a ---- fhead -------- %d\n", ppq->fhead);
		//TRACE("pktqueue_write_done_v ---- ftail -------- %d\n", ppq->ftail);
		//TRACE("pktqueue_write_done_v ---- fhead -------- %d\n", ppq->fhead);

		InterlockedIncrement(&(ppq->atail));
		InterlockedCompareExchange(&(ppq->atail), 0, ppq->asize);
		InterlockedIncrement(&(ppq->apktnum));
	}

	InterlockedIncrement(&(ppq->fhead));
	InterlockedCompareExchange(&(ppq->fhead), 0, ppq->fsize);

    ReleaseSemaphore(ppq->asemr, 1, NULL);
}

void pktqueue_write_done_v(PKTQUEUE *ppq, bool bDecode)
{
//	//////TRACE("WAIT HANDLE 8 : %x\n", ppq->vsemw);
    

	if (bDecode)
	{
		WaitForSingleObject(ppq->vsemw, -1);

		ppq->vpkts[ppq->vtail] = ppq->fpkts[ppq->fhead];

		//TRACE("pktqueue_write_done_v ---- ftail -------- %d\n", ppq->ftail);
		//TRACE("pktqueue_write_done_v ---- fhead -------- %d\n", ppq->fhead);

		InterlockedIncrement(&(ppq->vtail));
		InterlockedCompareExchange(&(ppq->vtail), 0, ppq->vsize);
		InterlockedIncrement(&(ppq->vpktnum));
	}

	InterlockedIncrement(&(ppq->fhead));
	InterlockedCompareExchange(&(ppq->fhead), 0, ppq->fsize);
	//    InterlockedDecrement(&(ppq->fpktnum));

    ReleaseSemaphore(ppq->vsemr, 1, NULL);
}

BOOL pktqueue_isempty_a(PKTQUEUE *ppq)
{
    return (ppq->apktnum <= 0);
}

BOOL pktqueue_isempty_v(PKTQUEUE *ppq)
{
    return (ppq->vpktnum <= 0);
}

int64_t pktqueue_get_cur_pts(PKTQUEUE *ppq)
{
	WaitForSingleObject(ppq->fsemr, -1);
	//int64_t curPts = ppq->vpkts[ppq->vhead]->pts;
	int nPos = ppq->fhead - 1;
	if (nPos < 0)
		nPos = ppq->fsize - 1;

	int64_t curPts = ppq->fpkts[ppq->fhead]->pts;
	//TRACE("recording start pts-----------%d\n", curPts);
	ReleaseSemaphore(ppq->fsemr, 1, NULL);
	
	return curPts;
}

void pktqueue_read_request(PKTQUEUE *ppq, AVPacket **pppkt, long pos)
{
//	//////TRACE("WAIT HANDLE 9 : %x\n", ppq->fsemr);
	WaitForSingleObject(ppq->fsemr, -1);

	if (pppkt) *pppkt = ppq->fpkts[pos];	
	//////TRACE("pktqueue_read_request-------------%d\n", pos);
}

void pktqueue_read_done(PKTQUEUE *ppq)
{
	ReleaseSemaphore(ppq->fsemr, 1, NULL);
}

bool pktqueue_read_request_a(PKTQUEUE *ppq, AVPacket **pppkt)
{
	
//	//////TRACE("WAIT HANDLE 10 : %x\n", ppq->asemr);
	if (WaitForSingleObject(ppq->asemr, 50) == WAIT_TIMEOUT)
	{
		return false;
	}
	/*WaitForSingleObject(ppq->asemr, -1);*/
    if (pppkt) *pppkt = ppq->apkts[ppq->ahead];
	
	////TRACE("pktqueue_read_request_a--- ahead ----------%d\n", ppq->ahead);
	////TRACE("pktqueue_read_request_a--- atail ----------%d\n", ppq->atail);
	if (*pppkt == NULL)
		return false;
	return true;
}

void pktqueue_read_done_a(PKTQUEUE *ppq)
{
//    ppq->fpkts[ppq->ftail] = ppq->apkts[ppq->ahead];

    InterlockedIncrement(&(ppq->ahead));
    InterlockedCompareExchange(&(ppq->ahead), 0, ppq->asize);
    InterlockedDecrement(&(ppq->apktnum));

//    InterlockedIncrement(&(ppq->ftail));
    InterlockedCompareExchange(&(ppq->ftail), 0, ppq->fsize);
    InterlockedIncrement(&(ppq->fpktnum));

    ReleaseSemaphore(ppq->asemw, 1, NULL);
    ReleaseSemaphore(ppq->fsemr, 1, NULL);
}

bool pktqueue_read_request_v(PKTQUEUE *ppq, AVPacket **pppkt)
{
//	//////TRACE("WAIT HANDLE 11 : %x\n", ppq->vsemr);
	if (WaitForSingleObject(ppq->vsemr, 50) == WAIT_TIMEOUT)
	{
		return false;
	}
	/*WaitForSingleObject(ppq->vsemr, -1);*/
	if (pppkt) *pppkt = ppq->vpkts[ppq->vhead];
	
	////TRACE("pktqueue_read_request_v--- vhead ----------%d\n", ppq->vhead);
	////TRACE("pktqueue_read_request_v--- vtail ----------%d\n", ppq->vtail);

	if (*pppkt == NULL)
		return false;
	return true;
}

void pktqueue_read_done_v(PKTQUEUE *ppq)
{
//    ppq->fpkts[ppq->ftail] = ppq->vpkts[ppq->vhead];

    InterlockedIncrement(&(ppq->vhead));
    InterlockedCompareExchange(&(ppq->vhead), 0, ppq->vsize);
    InterlockedDecrement(&(ppq->vpktnum));

//    InterlockedIncrement(&(ppq->ftail));
    InterlockedCompareExchange(&(ppq->ftail), 0, ppq->fsize);
    InterlockedIncrement(&(ppq->fpktnum));

    ReleaseSemaphore(ppq->vsemw, 1, NULL);
    ReleaseSemaphore(ppq->fsemr, 1, NULL);
}



