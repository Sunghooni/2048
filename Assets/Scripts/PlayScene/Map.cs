using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Scripts")]
    public CubeManager CubeManager;

    [Header ("MapSetting")]
    public int maxSize = 5;
    public int minSize = 3;

    [Header("Sources")]
    public GameObject BrightCube;
    public GameObject DarkCube;
    public GameObject BorderPrefab;

    [Header ("NowInfo")]
    public bool finishSetting = false;
    public MapSO _MapSO;
    public int mapSize;

    private float cubeWidth;
    private const float StartCubeTerm = 0.5f;

    private void Awake()
    {
        mapSize = _MapSO.MapSize;
    }

    private void Start()
    {
        cubeWidth = BrightCube.transform.localScale.x;
        StartCoroutine(SetBoard());
    }

    IEnumerator SetBoard()
    {
        Vector3 cubePos = new Vector3(0, 0, 10);

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                cubePos.x = j * cubeWidth;
                cubePos.y = i * cubeWidth * -1;

                GameObject cubeType = (i + j) % 2 == 0 ? BrightCube : DarkCube;
                Instantiate(cubeType, cubePos, Quaternion.identity);
                SoundManager.instance.PlayMapCube();

                yield return new WaitForSeconds(0.3f / mapSize);
            }
        }
        StartCoroutine(SetBorder());
        yield break;
    }

    IEnumerator SetBorder()
    {
        float halfWidth = cubeWidth / 2;
        float centerWidth = mapSize * halfWidth - halfWidth;

        Vector3 startPos = new Vector3(centerWidth, -centerWidth, -2);
        Vector3 toPos = new Vector3(centerWidth, -centerWidth, 9.75f);

        GameObject Border = Instantiate(BorderPrefab, startPos, Quaternion.identity);
        Border.transform.localScale = new Vector3(mapSize, mapSize, 1);

        float timer = 0;

        while (true)
        {
            timer += Time.deltaTime;
            Border.transform.position = Vector3.Lerp(startPos, toPos, timer);

            if (timer >= 1)
            {
                SoundManager.instance.PlayMapBorder();

                yield return new WaitForSeconds(StartCubeTerm);
                CubeManager.SetNewCube(); //시작시 기본 제공 2개
                CubeManager.SetNewCube();
                finishSetting = true;
                break;
            }

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}
