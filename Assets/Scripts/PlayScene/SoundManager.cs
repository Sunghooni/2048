using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("AudioSource")]
    public AudioSource audioSource;
    [Header("AudioClips")]
    public AudioClip mapCube;
    public AudioClip mapBorder;
    public AudioClip cubeInstant;
    public AudioClip finishGame;
    public AudioClip typing;

    private void Awake()
    {
        instance = gameObject.GetComponent<SoundManager>();
    }
    
    public void StopPlaying()
    {
        audioSource.Stop();
    }

    public void PlayMapCube()
    {
        audioSource.PlayOneShot(mapCube);
    }

    public void PlayMapBorder()
    {
        audioSource.PlayOneShot(mapBorder);
    }

    public void PlayCubeInstant()
    {
        audioSource.PlayOneShot(cubeInstant);
    }

    public void PlayFinishGame()
    {
        audioSource.PlayOneShot(finishGame);
    }

    public void PlayTyping()
    {
        audioSource.PlayOneShot(typing);
    }
}
