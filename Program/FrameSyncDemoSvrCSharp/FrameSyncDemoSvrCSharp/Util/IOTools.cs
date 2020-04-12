using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrameSyncDemoSvrCSharp.Util
{
    class IOTools : Singleton<IOTools>
    {
        public bool GetFiles(string path,out string context)
        {
            context = "";
            bool result = true;
            if (File.Exists(path))
            {
                context = File.ReadAllText(path);
            }
            else
            {
                result = false;
            }
            return result;
        }

        public override void Initialize()
        {

        }

        public override void UnInitialize()
        {

        }
    }
}
