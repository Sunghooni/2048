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
    public GameObject Cube;

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
        print(MapSize);
        MakingMap();
    }

    private void MakingMap()
    {
        Vector3 cubePos = new Vector3(0, 0, 10);

        for(int i = 0; i < MapSize; i++)
        {
            for(int j = 0; j < MapSize; j++)
            {
                cubePos.x = j * 3;
                cubePos.y = i * 3;
                Instantiate(Cube, cubePos, Quaternion.Euler(Vector3.zero));
            }
        }
    }
}
