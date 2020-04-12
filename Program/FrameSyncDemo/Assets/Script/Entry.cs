using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSD.Net;
namespace FSD
{
	public class Entry : MonoBehaviour
	{
		void Start()
		{
			NetWorkMgr.GetInstance().Initialize();
		}
	}

}