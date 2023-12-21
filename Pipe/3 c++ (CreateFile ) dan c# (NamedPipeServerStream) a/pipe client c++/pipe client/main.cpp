#include <windows.h>
#include <stdio.h>
#include <string>

//mesaji bu program gonderiyor

void main() {

	LPTSTR pipeAdresi = TEXT("\\\\.\\pipe\\mypipe");
	HANDLE hFile = CreateFile(pipeAdresi, GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE) {
		DWORD dw = GetLastError();
		printf("Ilk once Server'i aciniz.\n");
	}
	else {
		std::string s("Merhaba :)");
		printf("Mesaj Gonderildi.\n");
		BOOL flg = WriteFile(hFile, s.c_str(), s.length(), NULL, NULL);
		if (FALSE == flg)
			printf("WriteFile failed for Named Pipe client\n");

		CloseHandle(hFile);
	}
	system("pause");
}
