using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    public InputManager _InputManager;
    public FinishChecker _FinishChecker;
    public GameObject ScoreUI;
    public GameObject FinishPanel;

    public bool isFinished = false;

    private void Start()
    {
        InvokeRepeating("ShowFinishPanel", 1f, 1f);
    }

    private void ShowFinishPanel()
    {
        if(_FinishChecker.Check2048() || !_FinishChecker.CheckMovable())
        {
            _InputManager.canInput = false; //Cannot Input More
            FinishPanel.SetActive(true);
            isFinished = true;
        }
    }
}
