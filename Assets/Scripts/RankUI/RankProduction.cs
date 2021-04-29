using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankProduction : MonoBehaviour
{
    public GameObject Camera;
    public GameObject MainUI;
    public GameObject RankUI;
    public Text PlayerRank;

    private RankInfo rankInfo;
    private string texts;
    private const float cameraUpDistance = 15f;

    public void RankProduct()
    {
        for (int i = 0; i < MainUI.transform.childCount; i++)
        {
            MainUI.transform.GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(CameraProduct());
    }

    IEnumerator CameraProduct()
    {
        Vector3 startPos = Camera.transform.position;
        Vector3 toPos = startPos + Vector3.back * cameraUpDistance;
        float timer = 0;

        while(timer <= 1)
        {
            timer += Time.deltaTime;
            Camera.transform.position = Vector3.Lerp(startPos, toPos, timer);

            yield return new WaitForFixedUpdate();
        }

        RankUI.SetActive(true);
        StartCoroutine(ShowPlayerRanks());
        yield break;
    }

    IEnumerator ShowPlayerRanks()
    {
        float showRankDelay = 0.2f;

        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(showRankDelay);
            InstantiatePlayerRank(i);
        }
        yield break;
    }

    private void InstantiatePlayerRank(int cnt)
    {
        float textXpos = 120;
        float textYpos = 40;
        float textMargin = -25;

        SetRankText(cnt);
        PlayerRank.text = texts;

        var playerRank = Instantiate(PlayerRank, Vector3.zero, Quaternion.identity);
        playerRank.transform.SetParent(RankUI.transform);

        playerRank.rectTransform.anchoredPosition = new Vector3(textXpos, textYpos + textMargin * cnt, 0);
        playerRank.rectTransform.localScale = PlayerRank.rectTransform.localScale;
    }

    private void SetRankText(int cnt)
    {
        if(cnt == 0)
        {
            GetRankInfo getRankInfo = GameObject.Find("GetRankInfo").GetComponent<GetRankInfo>();
            rankInfo = getRankInfo.GetRankData();
        }
        texts = "ID : " + rankInfo.userId[cnt] + " / Score : " + rankInfo.userScore[cnt] + " / Time : " + rankInfo.playTime[cnt];
    }
}