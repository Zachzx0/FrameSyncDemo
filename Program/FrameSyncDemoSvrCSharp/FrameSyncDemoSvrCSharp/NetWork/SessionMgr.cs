using FrameSyncDemoSvrCSharp.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FrameSyncDemoSvrCSharp.NetWork
{
    class SessionMgr : Singleton<SessionMgr>
    {
        Dictionary<uint, Socket> _ipToSession;
        uint _sessionId = 0;
        Thread _liveCheckThread = null;
        public event Action<uint> SessionCloseHandler;

        public override void Initialize()
        {
            _ipToSession = new Dictionary<uint, Socket>();
            _liveCheckThread = new Thread(CheckSocketLive);
        }

        public override void UnInitialize()
        {
            foreach(var kvp in _ipToSession)
            {
                kvp.Value.Close();
            }
            _ipToSession.Clear();
            _liveCheckThread.Abort();
            _liveCheckThread = null;
        }

        public uint AddSession(Socket socket)
        {
            uint curSocketSession = _sessionId++;
            _ipToSession[curSocketSession] = socket;
            return curSocketSession;
        }

        public bool GetSocket(uint sessionId,out Socket socket)
        {
            socket = null;
            bool result = false;
            if (_ipToSession.ContainsKey(sessionId))
            {
                socket = _ipToSession[sessionId];
                result = true;
            }
            return result;
        }

        

        void CheckSocketLive()
        {
            List<uint> _closeList = new List<uint>();
            while (true)
            {
                _closeList.Clear();
                foreach (var kvp in _ipToSession)
                {
                    bool connected = GetSocketConnectStatus( kvp.Value);
                    if (!connected)
                    {
                        _closeList.Add(kvp.Key);
                        NotifySessionClose(kvp.Key);
                    }
                }
                for(int i = 0; i < _closeList.Count; i++)
                {
                    _ipToSession.Remove(_closeList[i]);
                }
            }
        }

        bool GetSocketConnectStatus(Socket socket)
        {
            return socket.Connected;
        }

        void NotifySessionClose(uint session)
        {
            if (SessionCloseHandler != null)
            {
                SessionCloseHandler.Invoke(session);
            }
        }

        public void Foreach(Action<Socket> callback)
        {
            foreach(var kvp in _ipToSession)
            {
                if (callback != null)
                {
                    callback.Invoke(kvp.Value);
                }
            }
        }
    }
}
