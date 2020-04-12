using FrameSyncDemoSvrCSharp.NetWork;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FrameSyncDemoSvrCSharp
{
    class Program
    {

        static int Main(string[] args)
        {
            NetWorkMgr.GetInstance().Initialize();
            if(args == null)
            {
                Console.WriteLine("参数为空，启动svr失败");
                return -1;
            }

            if(args.Length < 1)
            {
                Console.WriteLine("参数数量不正确，启动svr失败");
                return -1;
            }
            int port = 0;
            if (!int.TryParse(args[0],out port))
            {
                Console.WriteLine("解析参数失败，启动svr失败");
                return -1;
            }
            NetWorkMgr.GetInstance().StartListen(port);
            return 0;
        }
    }
}