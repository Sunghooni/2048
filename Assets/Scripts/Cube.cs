using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;
    public bool collapable = false;
    public bool checkTurn = false;

    private void Awake()
    {
        SetValue();
    }

    private void SetValue()
    {
        int random = Random.Range(0, 10);
        value = random < 1 ? 4 : 2;
    }

    public void Move(Vector3 toPos)
    {
        StartCoroutine(MoveMotion(toPos));
    }

    IEnumerator MoveMotion(Vector3 toPos)
    {
        float timer = 0;
        Vector3 originPos = gameObject.transform.position;

        while(timer <= 1)
        {
            timer += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(originPos, toPos, timer);

            yield return new WaitForFixedUpdate();
        }
        if(collapable)
        {
            Debug.Log("Collab");
        }
        if(checkTurn)
        {

        }
        yield return null;
    }
}
