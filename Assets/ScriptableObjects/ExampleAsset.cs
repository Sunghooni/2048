using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleAsset : ScriptableObject
{
    public string str;


    [MenuItem("Example/Create ExampleAsset Instance")]
    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();
    }

    [MenuItem("Example/Create ExampleAsset")]
    static void CreateExampleAsset()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/ScriptableObjects/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }
}