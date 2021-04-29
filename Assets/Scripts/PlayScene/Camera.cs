using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Map _Map;
    private const float fixedDistancePerIncreasedMapSize = -3.25f;
    private const float basicMapSize = 3;

    private void Start()
    {
        GetCameraPos();
    }

    private void GetCameraPos()
    {
        float cubeWidth = _Map.BrightCube.transform.localScale.x;
        float width = _Map.mapSize * cubeWidth / 2 - cubeWidth / 2;
        float zPos = (_Map.mapSize - basicMapSize) * fixedDistancePerIncreasedMapSize;

        gameObject.transform.position = new Vector3(width, -width, zPos);
    }
}
