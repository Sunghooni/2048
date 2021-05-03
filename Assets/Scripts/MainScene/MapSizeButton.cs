using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSizeButton : MonoBehaviour
{
    public MapSO _MapSO;
    public int setMapSize;

    public void SetMapSize()
    {
        GameObject mainButtons = GameObject.Find("MainButtons");
        GameObject mapButtons = GameObject.Find("MapSetButtons");
        float childCount = mapButtons.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            mapButtons.transform.GetChild(i).gameObject.SetActive(false);
            mainButtons.transform.GetChild(i).gameObject.SetActive(true);
        }

        _MapSO.MapSize = setMapSize;
    }
}
