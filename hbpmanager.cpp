#define _WINSOCKAPI_ 
#include <windows.h>
#include <assert.h>
#include <tlhelp32.h>
#include "hbpmanager.h"
#include <vector>

#ifdef _DEBUG

CHBPManager g_hbp;

void CHBPManager::Set(HANDLE hThreadID, void* address, int bytes, Condition when)
{
	assert(m_index == -1);

	CONTEXT cxt;

	if (hThreadID == NULL)
	{
		DWORD dwProcId = GetCurrentProcessId();
		HANDLE h = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
		if (h != INVALID_HANDLE_VALUE) {
			THREADENTRY32 te;
			te.dwSize = sizeof(te);
			if (Thread32First(h, &te)) {
			}
			CloseHandle(h);
		}
	}
	else
	{
		
		m_listThreads.push_back(hThreadID);
	}

	for (HandleList::iterator iter = m_listThreads.begin(); iter != m_listThreads.end(); iter++)
	{
		//HANDLE handle = *iter;
		HANDLE thisThread = *iter;// m_pThreads[i];
		int len;
		switch (bytes)
		{
		case 1: len = 0; break;
		case 2: len = 1; break;
		case 4: len = 3; break;
		default: assert(false); // invalid length
		}

		cxt.ContextFlags = CONTEXT_DEBUG_REGISTERS;

		if (!GetThreadContext(thisThread, &cxt))
			assert(false);

	}
}


void CHBPManager::Clear()
{
	if (m_index != -1)
	{
		CONTEXT cxt;
		HANDLE thisThread = GetCurrentThread();

		cxt.ContextFlags = CONTEXT_DEBUG_REGISTERS;

		if (!GetThreadContext(thisThread, &cxt))
			assert(false);

		assert(m_index >= 0 && m_index < 4);

		// SetBits(cxt.Dr7, m_index*2, 1, 0);
		// if (!SetThreadContext(thisThread, &cxt))
		// 	assert(false);

		// m_index = -1;
	}
	m_listThreads.clear();
}

#endif