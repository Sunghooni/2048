using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public Map Map;
    public InputManager InputManager;
    public CubeManager CubeManager;

    private void Awake()
    {
        Invoke("SetBasicCube", 2f);
    }

    private void SetBasicCube()
    {
        CubeManager.SetNewCube();
        CubeManager.SetNewCube();
    }
}
