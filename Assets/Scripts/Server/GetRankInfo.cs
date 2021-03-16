using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;

public class GetRankInfo : MonoBehaviour
{
	public string baseURL = "https://localhost:44310/api/RankInfo";

	private void Start()
	{
		GetRankData();
	}

	private void GetRankData()
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURL);

		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		StreamReader reader = new StreamReader(response.GetResponseStream());
		string json = reader.ReadToEnd();
		Debug.Log(json);

		RankInfo rankInfo = JsonUtility.FromJson<RankInfo>(json);

		for(int i = 0; i < 10; i++)
        {
			Debug.Log("ID: " + rankInfo.userId[i] + " Score : " + rankInfo.userScore[i] + " Time : " + rankInfo.playTime[i]);
        }
	}
}
