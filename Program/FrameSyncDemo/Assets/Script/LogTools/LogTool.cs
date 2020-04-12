using FSD.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSD.LogTools
{
	public class LogTool : Singleton<LogTool>
	{
		public override void Initialize()
		{
			//throw new System.NotImplementedException();
		}

		public override void UnInitialize()
		{
			//throw new System.NotImplementedException();
		}

		public void Log(string format,params object[] parameters)
		{
			Debug.Log(string.Format(format, parameters));
		}

		public void Log(string log)
		{
			Debug.Log(log);
		}

		public void LogError(string error)
		{
			Debug.LogError(error);
		}

		public void LogErrorFormat(string format, params object[] parameters)
		{
			Debug.LogErrorFormat(format, parameters);

		}
	}

}