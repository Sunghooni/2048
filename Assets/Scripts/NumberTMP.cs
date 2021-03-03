using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberTMP : MonoBehaviour
{
    private FinishManager _FinishManager;

    private void Awake()
    {
        _FinishManager = GameObject.Find("FinishManager").GetComponent<FinishManager>();
    }

    private void FixedUpdate()
    {
        FadeNumberUI();
    }

    public void FadeNumberUI()
    {
        if(_FinishManager.isFinished && gameObject.GetComponent<TextMeshPro>().fontSizeMax > 0)
        {
            gameObject.GetComponent<TextMeshPro>().fontSizeMax -= 3 * Time.deltaTime;
        }
    }
}
