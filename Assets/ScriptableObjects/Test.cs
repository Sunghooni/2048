using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    private void Start()
    {
        var exampleSO = AssetDatabase.LoadAssetAtPath<MapSO>("Assets/ScriptableObjects/Map SO.asset");
        //exampleSO.MapSize = 4;
        Debug.Log(exampleSO.MapSize);
    }
}
