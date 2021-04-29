using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberTMP : MonoBehaviour
{
    private FinishManager _FinishManager;
    private TextMeshPro tmp;

    private void Awake()
    {
        _FinishManager = GameObject.Find("FinishManager").GetComponent<FinishManager>();
        tmp = gameObject.GetComponent<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        FadeNumberUI();
    }

    public void FadeNumberUI()
    {
        int textSideDownSpeed = 3;

        if(_FinishManager.isFinished && tmp.fontSizeMax > 0)
        {
            tmp.fontSizeMax -= textSideDownSpeed * Time.deltaTime;
        }
    }
}
