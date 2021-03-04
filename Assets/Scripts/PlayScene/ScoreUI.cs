using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public FinishManager _FinishManager;
    public GameObject finishPanelPos;
    public GameObject biggestCubeUI;
    public GameObject playTimeUI;

    private float timer = 0;
    private float showDetailsTime = 1.3f;
    private Vector3 originPos;
    private Vector3 toPos;
    private bool finishMove = false;

    private void Awake()
    {
        originPos = gameObject.transform.localPosition;
        toPos = finishPanelPos.transform.localPosition;
    }

    private void FixedUpdate()
    {
        if(!finishMove)
        {
            ShowFinishAct();
        }
    }

    private void ShowFinishAct()
    {
        if (timer > showDetailsTime)
        {
            StartCoroutine(biggestCubeUI.GetComponent<BiggestCubeUI>().ShowTexts());
            StartCoroutine(playTimeUI.GetComponent<PlayTimeUI>().ShowTexts());
            finishMove = true;
        }
        else if(_FinishManager.isFinished)
        {
            timer += Time.deltaTime;
            
            float posY = Mathf.Lerp(originPos.y, toPos.y, timer);
            gameObject.transform.localPosition = new Vector3(originPos.x, posY, originPos.z);
        }
    }
}
