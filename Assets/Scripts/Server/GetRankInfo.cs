using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;

public class GetRankInfo : MonoBehaviour
{
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
