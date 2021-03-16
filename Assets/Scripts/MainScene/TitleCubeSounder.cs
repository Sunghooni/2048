using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCubeSounder : MonoBehaviour
{
    private bool isSettled = false;
    private float airborneTime = 0f;

    private void Update()
    {
        if(!isSettled)
        {
            airborneTime += Time.deltaTime;
        }
        else
        {
            airborneTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name.Equals("BackBoard") && !isSettled)
        {
            if(gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                gameObject.GetComponent<AudioSource>().volume = airborneTime;
                gameObject.GetComponent<AudioSource>().Play();
            }
            isSettled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isSettled)
        {
            isSettled = false;
        }
    }
}
