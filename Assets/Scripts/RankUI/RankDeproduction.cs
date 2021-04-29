using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankDeproduction : MonoBehaviour
{
    public GameObject Camera;
    public GameObject MainUI;
    public GameObject RankUI;

    private const float cameraDownDistance = -15f;

    public void Deproduct()
    {
        StartCoroutine(CameraProduct());
    }

    IEnumerator CameraProduct()
    {
        for(int i = 0; i < RankUI.transform.childCount; i++)
        {
            if(RankUI.transform.GetChild(i).TryGetComponent(out PlayerRankTexts playerRankText))
            {
                playerRankText.DeleteSelf();
            }
        }
        RankUI.SetActive(false);

        Vector3 startPos = Camera.transform.position;
        Vector3 toPos = startPos + Vector3.back * cameraDownDistance;
        float timer = 0;

        while (timer <= 1)
        {
            timer += Time.deltaTime;
            Camera.transform.position = Vector3.Lerp(startPos, toPos, timer);

            yield return new WaitForFixedUpdate();
        }

        for (int i = 0; i < MainUI.transform.childCount; i++)
        {
            MainUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        yield break;
    }
}
