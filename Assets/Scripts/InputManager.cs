using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CubeManager CubeManager;
    public Vector3 inputDir;

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

        inputDir = new Vector3(vert, horz, 0);
    }
}
