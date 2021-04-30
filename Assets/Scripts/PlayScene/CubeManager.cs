using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Map Map;
    public InputManager InputManager;
    public GameObject CubePrefab;
    public GameObject[,] CubeArray;

    private int mapSize;
    private float cubeWidth;

    private void Start()
    {
        cubeWidth = Map.BrightCube.transform.localScale.x;
        mapSize = Map.mapSize;
        CubeArray = new GameObject[mapSize, mapSize];
    }

    //NEW CUBE INSTANTIATE FUNCS
    public void SetNewCube()
    {
        Vector3 pos = GetRandomPos();

        int height = int.Parse((pos.y / -cubeWidth).ToString());
        int width = int.Parse((pos.x / cubeWidth).ToString());
        CubeArray[height, width] = Instantiate(CubePrefab, pos, Quaternion.identity);
        SoundManager.instance.PlayCubeInstant();
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

    public void RightMoveCtrl()
    {
        bool isActed = false;
        InputManager.canInput = false;

        for (int i = 0; i < mapSize; i++)
        {
            int comparedPlace = mapSize - 1;

            for (int j = mapSize - 2 ; j >= 0; j--)
            {
                if (CubeArray[i, j] == null)
                {
                    continue;
                }
                else if (CubeArray[i, comparedPlace] == null)
                {
                    Vector3 moveTarget = new Vector3(comparedPlace * cubeWidth, i * -cubeWidth, 9.5f);

                    CubeArray[i, j].GetComponent<Cube>().Move(moveTarget);
                    CubeArray[i, comparedPlace] = CubeArray[i, j];
                    CubeArray[i, j] = null;
                    isActed = true;
                }
                else
                {
                    Cube holdCube = CubeArray[i, comparedPlace].GetComponent<Cube>();
                    Cube moveCube = CubeArray[i, j].GetComponent<Cube>();

                    if (holdCube.value == moveCube.value && !holdCube.isCollaped)
                    {
                        moveCube.Move(new Vector3(comparedPlace * cubeWidth, i * -cubeWidth, 9.5f));
                        moveCube.collapCube = CubeArray[i, comparedPlace];
                        moveCube.collapable = true;
                        moveCube.isCollaped = true;

                        CubeArray[i, comparedPlace] = CubeArray[i, j];
                        CubeArray[i, j] = null;
                        comparedPlace--;
                        isActed = true;
                    }
                    else if (CubeArray[i, comparedPlace - 1] == null)
                    {
                        Vector3 moveTarget = new Vector3((comparedPlace - 1) * cubeWidth, i * -cubeWidth, 9.5f);

                        CubeArray[i, j].GetComponent<Cube>().Move(moveTarget);
                        CubeArray[i, comparedPlace - 1] = CubeArray[i, j];
                        CubeArray[i, j] = null;
                        comparedPlace--;
                        isActed = true;
                    }
                    else
                    {
                        comparedPlace--;
                    }
                }
            }
        }

        if (!isActed)
            InputManager.canInput = true;
    }

    public void LeftMoveCtrl()
    {
        bool isActed = false;
        InputManager.canInput = false;

        for (int i = 0; i < mapSize; i++)
        {
            int comparedPlace = 0;

            for (int j = 1; j < mapSize; j++)
            {
                if (CubeArray[i, j] == null)
                {
                    continue;
                }
                else if (CubeArray[i, comparedPlace] == null)
                {
                    Vector3 moveTarget = new Vector3(comparedPlace * cubeWidth, i * -cubeWidth, 9.5f);

                    CubeArray[i, j].GetComponent<Cube>().Move(moveTarget);
                    CubeArray[i, comparedPlace] = CubeArray[i, j];
                    CubeArray[i, j] = null;
                    isActed = true;
                }
                else
                {
                    Cube holdCube = CubeArray[i, comparedPlace].GetComponent<Cube>();
                    Cube moveCube = CubeArray[i, j].GetComponent<Cube>();

                    if (holdCube.value == moveCube.value && !holdCube.isCollaped)
                    {
                        moveCube.Move(new Vector3(comparedPlace * cubeWidth, i * -cubeWidth, 9.5f));
                        moveCube.collapCube = CubeArray[i, comparedPlace];
                        moveCube.collapable = true;
                        moveCube.isCollaped = true;

                        CubeArray[i, comparedPlace] = CubeArray[i, j];
                        CubeArray[i, j] = null;
                        comparedPlace++;
                        isActed = true;
                    }
                    else if (CubeArray[i, comparedPlace + 1] == null)
                    {
                        Vector3 moveTarget = new Vector3((comparedPlace + 1) * cubeWidth, i * -cubeWidth, 9.5f);

                        CubeArray[i, j].GetComponent<Cube>().Move(moveTarget);
                        CubeArray[i, comparedPlace + 1] = CubeArray[i, j];
                        CubeArray[i, j] = null;
                        comparedPlace++;
                        isActed = true;
                    }
                    else
                    {
                        comparedPlace++;
                    }
                }
            }
        }

        if (!isActed)
            InputManager.canInput = true;
    }

    public void UpMoveCtrl()
    {
        bool isActed = false;
        InputManager.canInput = false;

        for (int i = 0; i < mapSize; i++)
        {
            int comparedPlace = 0;

            for (int j = 1; j < mapSize; j++)
            {
                if (CubeArray[j, i] == null)
                {
                    continue;
                }
                else if (CubeArray[comparedPlace, i] == null)
                {
                    Vector3 moveTarget = new Vector3(i * cubeWidth, comparedPlace * -cubeWidth, 9.5f);

                    CubeArray[j, i].GetComponent<Cube>().Move(moveTarget);
                    CubeArray[comparedPlace, i] = CubeArray[j, i];
                    CubeArray[j, i] = null;
                    isActed = true;
                }
                else
                {
                    Cube holdCube = CubeArray[comparedPlace, i].GetComponent<Cube>();
                    Cube moveCube = CubeArray[j, i].GetComponent<Cube>();

                    if (holdCube.value == moveCube.value && !holdCube.isCollaped)
                    {
                        moveCube.Move(new Vector3(i * cubeWidth, comparedPlace * -cubeWidth, 9.5f));
                        moveCube.collapCube = CubeArray[comparedPlace, i];
                        moveCube.collapable = true;
                        moveCube.isCollaped = true;

                        CubeArray[comparedPlace, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;
                        comparedPlace++;
                        isActed = true;
                    }
                    else if (CubeArray[comparedPlace + 1, i] == null)
                    {
                        Vector3 moveTarget = new Vector3(i * cubeWidth, (comparedPlace + 1) * -cubeWidth, 9.5f);

                        CubeArray[j, i].GetComponent<Cube>().Move(moveTarget);
                        CubeArray[comparedPlace + 1, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;
                        comparedPlace++;
                        isActed = true;
                    }
                    else
                    {
                        comparedPlace++;
                    }
                }
            }
        }

        if (!isActed)
            InputManager.canInput = true;
    }

    public void DownMoveCtrl()
    {
        bool isActed = false;
        InputManager.canInput = false;

        for (int i = 0; i < mapSize; i++)
        {
            int comparedPlace = mapSize - 1;

            for (int j = mapSize - 2; j >= 0; j--)
            {
                if (CubeArray[j, i] == null)
                {
                    continue;
                }
                else if (CubeArray[comparedPlace, i] == null)
                {
                    Vector3 moveTarget = new Vector3(i * cubeWidth, comparedPlace * -cubeWidth, 9.5f);

                    CubeArray[j, i].GetComponent<Cube>().Move(moveTarget);
                    CubeArray[comparedPlace, i] = CubeArray[j, i];
                    CubeArray[j, i] = null;
                    isActed = true;
                }
                else
                {
                    Cube holdCube = CubeArray[comparedPlace, i].GetComponent<Cube>();
                    Cube moveCube = CubeArray[j, i].GetComponent<Cube>();

                    if (holdCube.value == moveCube.value && !holdCube.isCollaped)
                    {
                        moveCube.Move(new Vector3(i * cubeWidth, comparedPlace * -cubeWidth, 9.5f));
                        moveCube.collapCube = CubeArray[comparedPlace, i];
                        moveCube.collapable = true;
                        moveCube.isCollaped = true;

                        CubeArray[comparedPlace, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;
                        comparedPlace--;
                        isActed = true;
                    }
                    else if (CubeArray[comparedPlace - 1, i] == null)
                    {
                        Vector3 moveTarget = new Vector3(i * cubeWidth, (comparedPlace - 1) * -cubeWidth, 9.5f);

                        CubeArray[j, i].GetComponent<Cube>().Move(moveTarget);
                        CubeArray[comparedPlace - 1, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;
                        comparedPlace--;
                        isActed = true;
                    }
                    else
                    {
                        comparedPlace--;
                    }
                }
            }
        }

        if (!isActed)
            InputManager.canInput = true;
    }
}