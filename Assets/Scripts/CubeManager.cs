using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Map Map;
    public GameObject CubePrefab;
    public GameObject[,] CubeArray;

    private int mapSize;
    private float cubeWidth;

    private void Awake()
    {
        cubeWidth = CubePrefab.transform.localScale.x;
        mapSize = Map.MapSize;
        CubeArray = new GameObject[mapSize, mapSize];

        SetNewCube();
        SetNewCube();
        RightMove();
    }

    //새로운 큐브 생성 관련 함수들
    public void SetNewCube()
    {
        Vector3 pos = GetRandomPos();

        int height = int.Parse((pos.y / -cubeWidth).ToString());
        int width = int.Parse((pos.x / cubeWidth).ToString());
        CubeArray[height, width] = Instantiate(CubePrefab, pos, Quaternion.identity);
    }

    private Vector3 GetRandomPos()
    {
        int emptyNum = 0;

        for(int i = 0; i < mapSize; i++)
        {
            for(int j = 0; j < mapSize; j++)
            {
                if(CubeArray[i, j] == null)
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
                if(CubeArray[i, j] == null)
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

    //입력에 따른 이동명령
    public void RightMove()
    {
        for(int i = 0; i < mapSize; i++)
        {
            for(int j = mapSize - 2; j >= 0; j--)
            {
                if (CubeArray[i, j] == null)
                {
                    continue;
                }

                Vector3 toPos = new Vector3((j + 1) * cubeWidth, i * -cubeWidth, 9.5f);

                if (CubeArray[i, j + 1] == null)
                {
                    CubeArray[i, j].GetComponent<Cube>().Move(toPos);
                }
                else
                {
                    var thisCube = CubeArray[i, j].GetComponent<Cube>();
                    var toCube = CubeArray[i, j + 1].GetComponent<Cube>();

                    if(thisCube.value == toCube.value)
                    {
                        thisCube.Move(toPos);
                        thisCube.collapable = true;
                        thisCube.value = thisCube.value * 2;
                    }
                    else continue;
                }
                CubeArray[i, j + 1] = CubeArray[i, j];
                CubeArray[i, j] = null;
            }
        }
    }
}