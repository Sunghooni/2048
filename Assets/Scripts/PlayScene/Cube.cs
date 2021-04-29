using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;
    public float moveSpeed = 3;
    public bool collapable = false;
    public bool isCollaped = false;
    public GameObject collapCube = null;

    private InputManager InputManager;
    private CubeManager CubeManager;
    private TextMeshPro TextMeshPro;
    private ScoreManager ScoreManager;

    private readonly Color[] ColorArray = new Color[11] 
    {
        new Color(234/255f, 234/255f, 234/255f),
        new Color(255/255f, 211/255f, 176/255f),
        new Color(242/255f, 150/255f, 97/255f),
        new Color(170/255f, 78/255f, 25/255f),
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
        TextMeshPro = transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshPro>();
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Start()
    {
        SetStartValue();
    }

    private void SetStartValue()
    {
        int normalStartValue = 2;
        int bigStartValue = 4;
        int random = Random.Range(0, 10);
        bool chanceOfFourValue = random < 1; // 4 can appear by 10 percentage

        value = chanceOfFourValue ? bigStartValue : normalStartValue;

        ChangeColor();
    }

    public void Move(Vector3 toPos)
    {
        StartCoroutine(MoveMotion(toPos));
    }

    IEnumerator MoveMotion(Vector3 toPos)
    {
        float timer = 0;
        float maxLerpValue = 1;
        Vector3 originPos = gameObject.transform.position;

        while (timer <= maxLerpValue)
        {
            timer += Time.deltaTime * moveSpeed;
            gameObject.transform.position = Vector3.Lerp(originPos, toPos, timer);

            yield return new WaitForFixedUpdate();
        }

        if (collapable)
        {
            value += value; //double cube value
            isCollaped = false;
            collapable = false;

            Destroy(collapCube);
            ChangeColor();
            AddValueToScore();
        }

        if (!InputManager.canInput) //check player can input
        {
            InputManager.canInput = true;
            CubeManager.SetNewCube();
        }

        yield break;
    }

    private void ChangeColor()
    {
        int colorNum = -1;

        for(int i = value; i != 1; i /= 2) //get proper cnt of ColorArray
        {
            colorNum++;
        }

        gameObject.GetComponent<Renderer>().material.color = ColorArray[colorNum];
        TextMeshPro.text = value.ToString();
    }

    private void AddValueToScore()
    {
        ScoreManager.totalScore += value;
    }
}
