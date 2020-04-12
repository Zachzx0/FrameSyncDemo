using System;
using System.Collections.Generic;
using System.Text;

namespace FrameSyncDemoSvrCSharp.Util
{
	public abstract class Singleton<T> 
		where T: Singleton<T>,new() 
	{

		static T _instance = default(T);
		public static T GetInstance()
		{
			if (_instance == null)
			{
				_instance = new T();
				_instance.Initialize();
			}
			return _instance;
		}

        public static void DestroyInstance<T1>()
        where T1 : Singleton<T1>, new()
        {
			if (_instance != null)
			{
				_instance.UnInitialize();
				_instance = null;
			}
        }

        public abstract void Initialize();
		public abstract void UnInitialize();
	}

}
