using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class MapSO : ScriptableObject
{
    private int mapSize = 3;
    private readonly int maxSize = 5;
    private readonly int minSize = 3;

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
}
