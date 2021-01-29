using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;

    private void Awake()
    {
        SetValue();
    }

    private void SetValue()
    {
        int random = Random.Range(0, 10);
        value = random < 1 ? 4 : 2;
    }
}
