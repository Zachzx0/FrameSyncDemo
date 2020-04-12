using System;
using System.Collections.Generic;
using System.Text;

namespace FrameSyncDemoSvrCSharp.NetWork
{
    class DataBuffer
    {
        Queue<byte[]> dataQueue1 = new Queue<byte[]>();
        Queue<byte[]> dataQueue2 = new Queue<byte[]>();

        Queue<byte[]> curDataQueue;

        public DataBuffer()
        {
            dataQueue1 = new Queue<byte[]>();
            dataQueue2 = new Queue<byte[]>();
            Reverse();
        }

        public void Reverse()
        {
            if(curDataQueue == null)
            {
                curDataQueue = dataQueue1;
            }
            else if(curDataQueue == dataQueue1)
            {
                curDataQueue = dataQueue2;
            }
            else if (curDataQueue == dataQueue2)
            {
                curDataQueue = dataQueue1;
            }
        }

        public void AddData(byte[] data)
        {
            curDataQueue.Enqueue(data);
        }

        public Queue<byte[]> GetCurDataQueue()
        {
            Queue<byte[]> result = curDataQueue;
            Reverse();
            return result;
        }

    }
}
