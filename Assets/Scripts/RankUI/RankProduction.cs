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
        Vector3 toPos = startPos + Vector3.back * 15;
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
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            InstantiatePlayerRank(i);
        }
        yield break;
    }

    private void InstantiatePlayerRank(int cnt)
    {
        PlayerRank.text = "player1 score : 100 time : 10s biggest : 120";

        var playerRank = Instantiate(PlayerRank, Vector3.zero, Quaternion.identity);
        playerRank.transform.SetParent(RankUI.transform);
        playerRank.rectTransform.anchoredPosition = new Vector3(0, 40 + -25 * cnt, 0);
        playerRank.rectTransform.localScale = PlayerRank.rectTransform.localScale;
    }
}