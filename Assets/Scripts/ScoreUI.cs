using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public FinishManager _FinishManager;
    public GameObject finishPanelPos;

    private float timer = 0;
    private Vector3 originPos;
    private Vector3 toPos;

    private void Awake()
    {
        originPos = gameObject.transform.localPosition;
        toPos = finishPanelPos.transform.localPosition;
    }

    private void FixedUpdate()
    {
        GoFinishPanel();
    }

    public void GoFinishPanel()
    {
        if(_FinishManager.isFinished)
        {
            timer += Time.deltaTime;

            float posY = Mathf.Lerp(originPos.y, toPos.y, timer);
            gameObject.transform.localPosition = new Vector3(originPos.x, posY, originPos.z);
        }
    }
}
