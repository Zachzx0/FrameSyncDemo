using FSD.Common;
using FSD.LogTools;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FSD.Net
{
    public class NetWorkMgr : Singleton<NetWorkMgr>
    {
        public const string IP = "127.0.0.1";
        public const int port = 60082;
        Socket gameSocket;
        byte[] buffers = new byte[1024];
        public override void Initialize()
        {
            gameSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            gameSocket.Connect(new IPEndPoint(IPAddress.Parse(IP), port));
            LogTool.GetInstance().Log("连接成功，发送消息");
            SendReq("First Msg from Client");
            Thread t = new Thread(StartRecive);
            t.Start();
        }

        public void StartRecive()
        {
            while (true)
            {
                int size = gameSocket.Receive(buffers);
                LogTool.GetInstance().Log("接收服务器的消息{0}", Encoding.UTF8.GetString(buffers, 0, size));
            }
        }

        public void SendReq(string msg)
        {
            gameSocket.Send(Encoding.UTF8.GetBytes(msg));
        }


        public override void UnInitialize()
        {
            if (gameSocket != null)
            {
                gameSocket.Close();
            }
        }
    }

}