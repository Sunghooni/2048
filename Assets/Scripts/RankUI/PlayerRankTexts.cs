using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRankTexts : MonoBehaviour
{
    public void DeleteSelf()
    {
        if(gameObject.transform.parent.gameObject.activeSelf == true)
        {
            Destroy(gameObject);
        }
    }
}
