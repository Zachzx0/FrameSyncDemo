using System;
using System.IO;

namespace ProtocolSerialize
{
    public static class ProtoSerializeHelper
    {
        public static Exception Serialize<T>(T obj,Stream stream) where T : ProtoBuf.IExtensible
        {
            Exception exception = null;
            try
            {
                ProtoBuf.Serializer.Serialize(stream, obj);
            }catch(Exception e)
            {
                exception = e;
            }
            return exception;
        }

        public static Exception DeSerialize<T>(byte[] data,out T instance) where T : ProtoBuf.IExtensible
        {
            instance = default(T);
            Exception exception = null;
            try
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    ms.Write(data,0,data.Length);
                    instance = ProtoBuf.Serializer.Deserialize<T>(ms);
                }
            }
            catch(Exception e)
            {
                exception = e;
            }
            return exception;
        }
    }
}
