using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;

public class GetRankInfo : MonoBehaviour
{
	//원래 localhost대신에 서버ip주소를 적어야 함
	//하지만 그럴 경우에는 인증서 허가가 추가로 필요해 localhost를 사용했음
	public string baseURL = "https://localhost:44310/api/RankInfo";

	public RankInfo GetRankData()
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL);

		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		StreamReader reader = new StreamReader(response.GetResponseStream());
		string json = reader.ReadToEnd();

		RankInfo rankInfo = JsonUtility.FromJson<RankInfo>(json);
		return rankInfo;
	}
}
