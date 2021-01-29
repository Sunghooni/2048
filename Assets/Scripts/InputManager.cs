using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CubeManager CubeManager;
    public bool canInput = true;

    private float horz;
    private float vert;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        horz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if(canInput)
        {
            if (horz == 1)
                CubeManager.RightMoveCtrl();
            else if (horz == -1)
                CubeManager.LeftMoveCtrl();
            else if (vert == 1)
                CubeManager.UpMoveCtrl();
            else if (vert == -1)
                CubeManager.DownMoveCtrl();
        }
    }
}
