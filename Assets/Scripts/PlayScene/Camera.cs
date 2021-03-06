using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Map Map;
    private float fixZ = -3.25f;

    private void Start()
    {
        GetCameraPos();
    }

    private void GetCameraPos()
    {
        float cubeWidth = Map.BrightCube.transform.localScale.x;
        float width = Map.mapSize * cubeWidth / 2 - cubeWidth / 2;
        float zPos = (Map.mapSize - 3) * fixZ;

        gameObject.transform.position = new Vector3(width, -width, zPos);
    }
}
