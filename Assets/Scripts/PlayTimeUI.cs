using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTimeUI : MonoBehaviour
{
    private float playTimer = 0;
    private string texts = "PLAY TIME : ";

    private void Update()
    {
        playTimer += Time.deltaTime;
    }

    public IEnumerator ShowTexts()
    {
        texts += Mathf.Round(playTimer * 10) * 0.1f;

        for (int i = 0; i < texts.Length; i++)
        {
            gameObject.GetComponent<Text>().text = texts.Substring(0, i + 1);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
