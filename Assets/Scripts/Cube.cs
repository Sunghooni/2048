using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;
    public bool collapable = false;
    public bool isCollaped = false;
    public GameObject collapCube = null;

    private InputManager InputManager;
    private CubeManager CubeManager;

    private void Awake()
    {
        InputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        CubeManager = GameObject.Find("CubeManager").GetComponent<CubeManager>();
        SetStartValue();
    }

    private void SetStartValue()
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

        while (timer <= 1)
        {
            timer += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(originPos, toPos, timer);

            yield return new WaitForFixedUpdate();
        }

        if (collapable)
        {
            Destroy(collapCube);
            value = value * 2;

            isCollaped = false;
            collapable = false;
        }

        if (!InputManager.canInput)
        {
            Debug.Log("NewCube");
            InputManager.canInput = true;
            CubeManager.SetNewCube();
        }

        yield break;
    }
}
