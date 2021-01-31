using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : SpeedPad
{
    public Transform childTransform;
    public float bounceHeight;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio() {
        if (audioSource.isPlaying == false)
        {
            audioSource.Play(0);
            Debug.Log("Play");

        }
        else
        {
            audioSource.Stop();
            audioSource.Play(0);
            Debug.Log("Play");

        }
    }

}
