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
        new Color(234/255f, 234/255f, 234/255f),
        new Color(250/255f, 224/255f, 212/255f),
        new Color(242/255f, 150/255f, 97/255f),
        new Color(224/255f, 132/255f, 79/255f),
        new Color(204/255f, 61/255f, 61/255f), //Original ^
        new Color(209/255f, 178/255f, 255/255f), //Temp v
        new Color(165/255f, 102/255f, 255/255f),
        new Color(128/255f, 65/255f, 217/255f),
        new Color(250/255f, 237/255f, 125/255f),
        new Color(242/255f, 203/255f, 97/255f),
        new Color(116/255f, 77/255f, 0/255f)
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

        ChangeColor();
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
        int arrayNum = -1;

        for(int i = value; i != 1; i /= 2)
        {
            arrayNum++;
        }

        gameObject.GetComponent<Renderer>().material.color = ColorArray[arrayNum];
        print("C.C" + " " + arrayNum);
    }
}
