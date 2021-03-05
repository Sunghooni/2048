using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestSO : MonoBehaviour
{
    private void Start()
    {
        var exampleSO = AssetDatabase.LoadAssetAtPath<ExampleAsset>("Assets/ScriptableObjects/ExampleAsset.asset");
        Debug.Log(exampleSO.str);
    }
}
