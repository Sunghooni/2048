using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Map Map;
    public GameObject CubePrefab;
    public GameObject[,] CubeManager;

    private int mapSize;
    private float cubeWidth;
    private bool startSetting = false;

    private void Awake()
    {
        cubeWidth = CubePrefab.transform.localScale.x;
        mapSize = Map.MapSize;
        CubeManager = new GameObject[mapSize, mapSize];
    }

    private void Update()
    {
        SetBasicCubes();
    }

    private void SetBasicCubes()
    {
        if (Map.FinishSetting && !startSetting)
        {
            SetCube();
            SetCube();
            startSetting = true;
        }
    }

    private void SetCube()
    {
        Vector3 pos = GetRandomPos();

        int height = int.Parse((pos.y / -cubeWidth).ToString());
        int width = int.Parse((pos.x / cubeWidth).ToString());
        CubeManager[height, width] = Instantiate(CubePrefab, pos, Quaternion.identity);
    }

    private Vector3 GetRandomPos()
    {
        int emptyNum = 0;

        for(int i = 0; i < mapSize; i++)
        {
            for(int j = 0; j < mapSize; j++)
            {
                if(CubeManager[i, j] == null)
                {
                    emptyNum++;
                }
            }
        }

        int randomNum = Random.Range(0, emptyNum);
        int cnt = 0;

        for(int i = 0; i < mapSize; i++)
        {
            for(int j = 0; j < mapSize; j++)
            {
                if(CubeManager[i, j] == null)
                {
                    if (cnt == randomNum)
                    {
                        Vector3 pos = new Vector3(j * cubeWidth, i * -cubeWidth, 9.5f);
                        return pos;
                    }
                    else cnt++;
                }
            }
        }

        return Vector3.zero;
    }
}