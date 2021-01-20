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
    public GameObject BorderPrefab;

    private float cubeWidth;

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
        cubeWidth = BrightCube.transform.localScale.x;
        StartCoroutine(SetBoard());
    }

    IEnumerator SetBoard()
    {
        Vector3 cubePos = new Vector3(0, 0, 10);

        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                cubePos.x = j * cubeWidth;
                cubePos.y = i * cubeWidth;

                GameObject cubeType = (i + j) % 2 == 0 ? BrightCube : DarkCube;
                Instantiate(cubeType, cubePos, Quaternion.identity);

                yield return new WaitForSeconds(0.3f / MapSize);
            }
        }
        StartCoroutine(SetBorder());
        yield break;
    }

    IEnumerator SetBorder()
    {
        float halfWidth = cubeWidth / 2;
        float centerWidth = mapSize * halfWidth - halfWidth;

        Vector3 startPos = new Vector3(centerWidth, centerWidth, -2);
        Vector3 toPos = new Vector3(centerWidth, centerWidth, 10);

        GameObject Border = Instantiate(BorderPrefab, startPos, Quaternion.identity);
        Border.transform.localScale = new Vector3(MapSize, MapSize, 1);

        while (true)
        {
            if (Border.transform.position.z >= toPos.z)
            {
                Debug.Log("MapSetting Finished");
                break;
            }

            Border.transform.position = Vector3.Lerp(Border.transform.position, toPos, Time.deltaTime * 3);
            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}
