#ifndef __HBMMANAGER__INCLUDE__MARK__
#define __HBMMANAGER__INCLUDE__MARK__
#include <list>
#ifdef _DEBUG

class CHBPManager
{
public:
	CHBPManager() { 
		m_index = -1; 
		

	}
	~CHBPManager() { Clear(); }
	

	enum Condition { exec = 0, Write = 1, Read = 3 };
	void Set(HANDLE hThread, void* address, int len /* 1, 2, or 4 */, Condition when);
	void Clear();

private:
	typedef std::list<HANDLE> HandleList;
	HandleList m_listThreads;
protected:

	inline void SetBits(unsigned long& dw, int lowBit, int bits, int newValue)
	{
		int mask = (1 << bits) - 1; 

		dw = (dw & ~(mask << lowBit)) | (newValue << lowBit);
	}

	int m_index; 
};

extern CHBPManager g_hbp;

#endif // _DEBUG
