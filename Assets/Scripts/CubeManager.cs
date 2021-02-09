using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Map Map;
    public InputManager InputManager;
    public GameObject CubePrefab;
    public GameObject[,] CubeArray;

    private int mapSize;
    private float cubeWidth;

    private void Awake()
    {
        cubeWidth = Map.BrightCube.transform.localScale.x;
        mapSize = Map.MapSize;
        CubeArray = new GameObject[mapSize, mapSize];
    }

    //NEW CUBE INSTANTIATE FUNCS
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

    //WASD ORDER FUNCS *NEED REFACTORING*
    public void RightMoveCtrl()
    {
        bool isActed = false;

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = mapSize - 2; j >= 0; j--)
            {
                if (CubeArray[i, j] == null)
                {
                    continue;
                }
                for (int h = j + 1; h < mapSize; h++)
                {
                    if (InputManager.canInput)
                    {
                        InputManager.canInput = false;
                    }

                    var moveCube = CubeArray[i, j].GetComponent<Cube>();

                    if (CubeArray[i, h] == null)
                    {
                        if (h + 1 == mapSize && h != j)
                        {
                            moveCube.Move(new Vector3(h * cubeWidth, i * -cubeWidth, 9.5f));

                            CubeArray[i, h] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                            break;
                        }
                        continue;
                    }

                    var collabCube = CubeArray[i, h].GetComponent<Cube>();

                    if (moveCube.value == collabCube.value)
                    {
                        if (!collabCube.isCollaped && h != j)
                        {
                            moveCube.Move(new Vector3(h * cubeWidth, i * -cubeWidth, 9.5f));
                            moveCube.collapable = true;
                            moveCube.collapCube = CubeArray[i, h];

                            moveCube.isCollaped = true;

                            CubeArray[i, h] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                        }
                        else if (h - 1 != j)
                        {
                            moveCube.Move(new Vector3((h - 1) * cubeWidth, i * -cubeWidth, 9.5f));

                            CubeArray[i, h - 1] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                        }
                    }
                    else if (moveCube.value != collabCube.value && h - 1 != j)
                    {
                        moveCube.Move(new Vector3((h - 1) * cubeWidth, i * -cubeWidth, 9.5f));

                        CubeArray[i, h - 1] = CubeArray[i, j];
                        CubeArray[i, j] = null;

                        isActed = true;
                    }
                    break;
                }
            }
        }

        if (!isActed)
            InputManager.canInput = true;
    }
    public void LeftMoveCtrl()
    {
        bool isActed = false;

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 1; j < mapSize; j++)
            {
                if (CubeArray[i, j] == null)
                {
                    continue;
                }
                for (int h = j - 1; h >= 0; h--)
                {
                    if (InputManager.canInput)
                    {
                        InputManager.canInput = false;
                    }

                    var moveCube = CubeArray[i, j].GetComponent<Cube>();

                    if (CubeArray[i, h] == null)
                    {
                        if (h == 0 && h != j)
                        {
                            moveCube.Move(new Vector3(h * cubeWidth, i * -cubeWidth, 9.5f));

                            CubeArray[i, h] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                            break;
                        }
                        continue;
                    }

                    var collabCube = CubeArray[i, h].GetComponent<Cube>();

                    if (moveCube.value == collabCube.value)
                    {
                        if (!collabCube.isCollaped && h != j)
                        {
                            moveCube.Move(new Vector3(h * cubeWidth, i * -cubeWidth, 9.5f));
                            moveCube.collapable = true;
                            moveCube.collapCube = CubeArray[i, h];

                            moveCube.isCollaped = true;

                            CubeArray[i, h] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                        }
                        else if (h + 1 != j)
                        {
                            moveCube.Move(new Vector3((h + 1) * cubeWidth, i * -cubeWidth, 9.5f));

                            CubeArray[i, h + 1] = CubeArray[i, j];
                            CubeArray[i, j] = null;

                            isActed = true;
                        }
                    }
                    else if (moveCube.value != collabCube.value && h + 1 != j)
                    {
                        moveCube.Move(new Vector3((h + 1) * cubeWidth, i * -cubeWidth, 9.5f));

                        CubeArray[i, h + 1] = CubeArray[i, j];
                        CubeArray[i, j] = null;

                        isActed = true;
                    }
                    break;
                }
            }
        }
        if (!isActed)
            InputManager.canInput = true;
    }
    public void UpMoveCtrl()
    {
        bool isActed = false;

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 1; j < mapSize; j++)
            {
                if (CubeArray[j, i] == null)
                {
                    continue;
                }
                for (int h = j - 1; h >= 0; h--)
                {
                    if (InputManager.canInput)
                    {
                        InputManager.canInput = false;
                    }

                    var moveCube = CubeArray[j, i].GetComponent<Cube>();

                    if (CubeArray[h, i] == null)
                    {
                        if (h == 0 && h != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, h * -cubeWidth, 9.5f));

                            CubeArray[h, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                            break;
                        }
                        continue;
                    }

                    var collabCube = CubeArray[h, i].GetComponent<Cube>();

                    if (moveCube.value == collabCube.value)
                    {
                        if (!collabCube.isCollaped && h != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, h * -cubeWidth, 9.5f));
                            moveCube.collapable = true;
                            moveCube.collapCube = CubeArray[h, i];

                            moveCube.isCollaped = true;

                            CubeArray[h, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                        }
                        else if (h + 1 != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, (h + 1) * -cubeWidth, 9.5f));

                            CubeArray[h + 1, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                        }
                    }
                    else if (moveCube.value != collabCube.value && h + 1 != j)
                    {
                        moveCube.Move(new Vector3(i * cubeWidth, (h + 1) * -cubeWidth, 9.5f));

                        CubeArray[h + 1, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;

                        isActed = true;
                    }
                    break;
                }
            }
        }
        if (!isActed)
            InputManager.canInput = true;
    }
    public void DownMoveCtrl()
    {
        bool isActed = false;

        for (int i = 0; i < mapSize; i++)
        {
            for (int j = mapSize - 2; j >= 0; j--)
            {
                if (CubeArray[j, i] == null)
                {
                    continue;
                }
                for (int h = j + 1; h < mapSize; h++)
                {
                    if (InputManager.canInput)
                    {
                        InputManager.canInput = false;
                    }

                    var moveCube = CubeArray[j, i].GetComponent<Cube>();

                    if (CubeArray[h, i] == null)
                    {
                        if (h + 1 == mapSize && h != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, h * -cubeWidth, 9.5f));
                            
                            CubeArray[h, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                            break;
                        }
                        continue;
                    }

                    var collabCube = CubeArray[h, i].GetComponent<Cube>();
                    
                    if (moveCube.value == collabCube.value)
                    {
                        if (!collabCube.isCollaped && h != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, h * -cubeWidth, 9.5f));
                            moveCube.collapable = true;
                            moveCube.collapCube = CubeArray[h, i];

                            moveCube.isCollaped = true;

                            CubeArray[h, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                        }
                        else if (h - 1 != j)
                        {
                            moveCube.Move(new Vector3(i * cubeWidth, (h - 1) * -cubeWidth, 9.5f));

                            CubeArray[h - 1, i] = CubeArray[j, i];
                            CubeArray[j, i] = null;

                            isActed = true;
                        }
                    }
                    else if (moveCube.value != collabCube.value && h - 1 != j)
                    {
                        moveCube.Move(new Vector3(i * cubeWidth, (h - 1) * -cubeWidth, 9.5f));

                        CubeArray[h - 1, i] = CubeArray[j, i];
                        CubeArray[j, i] = null;

                        isActed = true;
                    }
                    break;
                }
            }
        }
        if (!isActed)
            InputManager.canInput = true;
    }
}