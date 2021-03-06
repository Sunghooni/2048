using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapSizeButton : MonoBehaviour
{
    public int setMapSize;

    public void SetMapSize()
    {
        //Maincode
        string mapSoRoot = "Assets/ScriptableObjects/Map SO.asset";
        var mapSO = AssetDatabase.LoadAssetAtPath<MapSO>(mapSoRoot);

        mapSO.MapSize = setMapSize;

        GameObject main = GameObject.Find("MainButtons");
        GameObject map = GameObject.Find("MapSetButtons");

        for (int i = 0; i < 3; i++)
        {
            map.transform.GetChild(i).gameObject.SetActive(false);
            main.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
