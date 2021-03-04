using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeUI : MonoBehaviour
{
    private float playTimer = 0;
    private string texts = "TIME : ";

    private void Update()
    {
        playTimer += Time.deltaTime;
    }

    private void AddTimeToTexts()
    {
        float hour = 0, minute = 0;
        playTimer = Mathf.Round(playTimer * 10) * 0.1f;
        
        if(playTimer >= 3600)
        {
            float leftTime = playTimer % 3600;
            hour = (playTimer - leftTime) / 3600;
            playTimer = leftTime;
        }
        if(playTimer >= 60)
        {
            float leftTime = playTimer % 60;
            minute = (playTimer - leftTime) / 60;
            playTimer = leftTime;
        }

        texts += hour + "h " + minute + "m " + Mathf.Round(playTimer * 10) / 10 + "s";
    }

    public IEnumerator ShowTexts()
    {
        float typingTerm = 0.15f;
        AddTimeToTexts();

        SoundManager.instance.PlayTyping();

        for (int i = 0; i < texts.Length; i++)
        {
            yield return new WaitForSeconds(typingTerm);
            gameObject.GetComponent<Text>().text = texts.Substring(0, i + 1);
        }

        SoundManager.instance.StopPlaying();
        yield break;
    }
}
