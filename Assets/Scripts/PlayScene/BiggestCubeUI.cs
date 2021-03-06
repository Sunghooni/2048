using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiggestCubeUI : MonoBehaviour
{
    public Map _Map;
    public CubeManager _CubeManager;
    private string texts = "BIGGEST CUBE : ";

    public int GetBiggestValue()
    {
        int mapSize = _Map.mapSize;
        int biggestNum = 0;

        for(int i = 0; i < mapSize; i++)
        {
            for(int j = 0; j < mapSize; j++)
            {
                if(_CubeManager.CubeArray[i, j] == null)
                {
                    continue;
                }
                else if(_CubeManager.CubeArray[i, j].GetComponent<Cube>().value > biggestNum)
                {
                    biggestNum = _CubeManager.CubeArray[i, j].GetComponent<Cube>().value;
                }
            }
        }
        return biggestNum;
    }

    public IEnumerator ShowTexts()
    {
        float typingTerm = 0.15f;
        texts += GetBiggestValue().ToString();

        for (int i = 0; i < texts.Length; i++)
        {
            yield return new WaitForSeconds(typingTerm);
            gameObject.GetComponent<Text>().text = texts.Substring(0, i + 1);
        }

        yield break;
    }
}
