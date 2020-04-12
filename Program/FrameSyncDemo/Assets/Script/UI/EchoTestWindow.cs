using FSD.Net;
using FSD.Protocol;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace FSD.UI
{
	public class EchoTestWindow : MonoBehaviour
	{
		public InputField inputField;

		public Button btnSubmit;


		// Use this for initialization
		void Start()
		{
			btnSubmit.onClick.AddListener(OnBtnSubmitClick);
		}

		// Update is called once per frame
		void Update()
		{
		}

		void OnBtnSubmitClick()
        {
            if (inputField != null)
            {
				GameLoginReq req = new GameLoginReq();
				req.uin = 1;
				req.password = "2";
				global::ProtoBuf.Serializer.Serialize<GameLoginReq>(new MemoryStream(), req);
				NetWorkMgr.GetInstance().SendReq(req.ToString());
			}
        }
	}
}
