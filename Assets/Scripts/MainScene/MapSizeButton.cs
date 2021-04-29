using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSizeButton : MonoBehaviour
{
    public MapSO _MapSO;
    public int setMapSize;

    public void SetMapSize()
    {
        float childCount = 3f;
        _MapSO.MapSize = setMapSize;

        GameObject main = GameObject.Find("MainButtons");
        GameObject map = GameObject.Find("MapSetButtons");

        for (int i = 0; i < childCount; i++)
        {
            map.transform.GetChild(i).gameObject.SetActive(false);
            main.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
