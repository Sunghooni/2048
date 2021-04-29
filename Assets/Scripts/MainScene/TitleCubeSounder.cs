using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCubeSounder : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isSettled = false;
    private float airborneTime = 0f;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

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
            if(audioSource.isPlaying == false)
            {
                audioSource.volume = airborneTime;
                audioSource.Play();
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
