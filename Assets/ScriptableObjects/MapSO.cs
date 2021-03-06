using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapSO : ScriptableObject
{
    [SerializeField] private int mapSize = 3;
    [SerializeField] private int maxSize = 5;
    [SerializeField] private int minSize = 3;

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
