#include<winsock.h>
#include <iostream>
using namespace std;

void Initialization();
SOCKET s_server;

int main() {
	s_server = socket(AF_INET, SOCK_STREAM, 0);
	sockaddr_in addr;
	addr.sin_family = AF_INET;
	addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	addr.sin_port = htons(36688);
	if (bind(s_server, (sockaddr*)&addr, sizeof(struct sockaddr))==-1) {
		cout << "socket initial failure" << endl;
		return -1;
	}
	if(listen(s_server, 10) == -1)
	{
		cout << "socket listen failure" << endl;
	}
}

void Initialization() {
//初始化套接字库
	WORD w_req = MAKEWORD(2, 2);//版本号
	WSADATA wsadata;
	int err;
	err = WSAStartup(w_req, &wsadata);
	if (err != 0) {
		cout << "初始化套接字库失败！" << endl;
	}
	else {
		cout << "初始化套接字库成功！" << endl;
	}
	//检测版本号
	if (LOBYTE(wsadata.wVersion) != 2 || HIBYTE(wsadata.wHighVersion) != 2) {
		cout << "套接字库版本号不符！" << endl;
		WSACleanup();
	}
	else {
		cout << "套接字库版本正确！" << endl;
	}
	//填充服务端地址信息
}