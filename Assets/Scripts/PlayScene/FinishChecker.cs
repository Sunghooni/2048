﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    public CubeManager _CubeManager;

    public bool Check2048() //Check is Completed 2048
    {
        GameObject[,] cubeArray = _CubeManager.CubeArray;
        int arrayLength = _CubeManager.Map.mapSize;

        for(int i = 0; i < arrayLength; i++)
        {
            for(int j = 0; j < arrayLength; j++)
            {
                if(cubeArray[i, j] != null && cubeArray[i,j].GetComponent<Cube>().value == 2048)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool CheckMovable() //Check is there existing a movable cube
    {
        GameObject[,] cubeArray = _CubeManager.CubeArray;
        int arrayLength = _CubeManager.Map.mapSize;

        for (int i = 0; i < arrayLength; i++)
        {
            for (int j = 0; j < arrayLength; j++)
            {
                bool isMovable = false;

                if (cubeArray[i, j] != null)
                {
                    int thisValue = cubeArray[i, j].GetComponent<Cube>().value;

                    if (i + 1 < arrayLength && cubeArray[i + 1, j] != null)
                    {
                        isMovable = cubeArray[i + 1, j].GetComponent<Cube>().value == thisValue || isMovable;
                    }
                    if (i - 1 >= 0 && cubeArray[i - 1, j] != null)
                    {
                        isMovable = cubeArray[i - 1, j].GetComponent<Cube>().value == thisValue || isMovable;
                    }
                    if (j + 1 < arrayLength && cubeArray[i, j + 1] != null)
                    {
                        isMovable = cubeArray[i, j + 1].GetComponent<Cube>().value == thisValue || isMovable;
                    }
                    if (j - 1 >= 0 && cubeArray[i, j - 1] != null)
                    {
                        isMovable = cubeArray[i, j - 1].GetComponent<Cube>().value == thisValue || isMovable;
                    }
                }
                else
                {
                    return true;
                }

                if (isMovable == false)
                    continue;
                else
                    return true;
            }
        }

        return false;
    }
}