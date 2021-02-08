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

    private Color[] ColorArray = new Color[11] 
    {
        new Color(213, 213, 213),
        new Color(250, 224, 212),
        new Color(255, 193, 158),
        new Color(255, 168, 115),
        new Color(246, 246, 246),
        new Color(246, 246, 246),
        new Color(246, 246, 246),
        new Color(246, 246, 246),
        new Color(246, 246, 246),
        new Color(246, 246, 246),
        new Color(246, 246, 246)
    };

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

        if (value == 2)
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", ColorArray[0]);
        else
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", ColorArray[1]);
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

            ChangeColor();
        }

        if (!InputManager.canInput)
        {
            InputManager.canInput = true;
            CubeManager.SetNewCube();
        }

        yield break;
    }

    private void ChangeColor()
    {
        //int arrayNum = ;
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", ColorArray[arrayNum]);
    }
}
