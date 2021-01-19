using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header ("MapSetting")]
    public int maxSize = 5;
    public int minSize = 3;
    [SerializeField]
    private int mapSize = 3;

    [Header("Sources")]
    public GameObject BrightCube;
    public GameObject DarkCube;

    public int MapSize
    {
        get { return mapSize; }

        set
        {
            value = value > maxSize ? maxSize : value;
            value = value < minSize ? minSize : value;
            mapSize = value;
        }
    }

    private void Awake()
    {
        StartCoroutine(SetBoard());
    }

    IEnumerator SetBoard()
    {
        Vector3 cubePos = new Vector3(0, 0, 10);

        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                cubePos.x = j * 3;
                cubePos.y = i * 3;

                var cubeType = (i + j) % 2 == 0 ? BrightCube : DarkCube;
                Instantiate(cubeType, cubePos, Quaternion.Euler(Vector3.zero));

                yield return new WaitForSeconds(0.3f);
            }
        }

        yield break;
    }
}
