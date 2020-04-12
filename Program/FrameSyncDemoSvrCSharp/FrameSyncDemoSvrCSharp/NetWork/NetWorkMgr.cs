using FrameSyncDemoSvrCSharp.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FrameSyncDemoSvrCSharp.NetWork
{
    public class NetWorkMgr : Singleton<NetWorkMgr>
    {
        Socket _listenSocket;
        const string _curIp = "127.0.0.1";
        const int allowAcceptClient = 10;
        const int bufferSize = 1024;
        IPAddress _curIpAddr;

        MemoryStream ms;

        DataBuffer _dataBuffer;

        #region Thread
        Thread _listenThread;
        Thread _RecvThread;
        #endregion

        public override void Initialize()
        {
            _listenSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            _curIpAddr = IPAddress.Parse(_curIp);
            ms = new MemoryStream();
            _listenThread = new Thread(ListenClientConnect);
            _RecvThread = new Thread(ReceiveMessage);

            _dataBuffer = new DataBuffer();
        }

        public void StartListen(int port)
        {
            _listenSocket.Bind(new IPEndPoint(_curIpAddr, port));
            _listenSocket.Listen(allowAcceptClient);
            Thread myThread = new Thread(ListenClientConnect);
            if (_listenThread != null)
            {
                _listenThread.Start();
            }
            if (_RecvThread != null)
            {
                _RecvThread.Start();
            }
        }

        void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = _listenSocket.Accept();
                SessionMgr.GetInstance().AddSession(clientSocket);
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    SessionMgr.GetInstance().Foreach((socket) =>
                    {
                        if (socket == null)
                        {
                            throw new NullReferenceException("Recv Msg ,Socket is null");
                        }
                        //通过clientSocket接收数据  
                        byte[] buffer = new byte[bufferSize];
                        int receiveNumber = socket.Receive(buffer);
                        _dataBuffer.AddData(buffer);
                    });
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                     break;
                }
            }
        }

        private void SendTCPData<T>(T instance)where T:ProtoBuf.IExtensible
        {
            ms.Position = 0;
            ms.SetLength(0);
            Exception e = ProtocolSerialize.ProtoSerializeHelper.Serialize(instance, ms);
            if(e == null)
            {
                ms.ToArray();
            }

        }

        public override void UnInitialize()
        {
            //throw new NotImplementedException();
            ms.Dispose();
            ms = null;
        }
    }
}
