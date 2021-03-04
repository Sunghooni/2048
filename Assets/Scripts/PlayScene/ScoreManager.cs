using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int totalScore = 0;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = "SCORE : " + totalScore;
    }
}
