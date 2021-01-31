using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float defaultVolume = 1f;
    [SerializeField] bool setVolumeToZeroOnStart = true;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            return;

        if (setVolumeToZeroOnStart)
            audioSource.volume = 0;
    }

    public void Play()
    {
        if (audioSource == null)
            return;

        if (!audioSource.isPlaying)
            audioSource.Play();
        audioSource.volume = defaultVolume;
    }

    public void PlayWithoutAudio()
    {
        if (audioSource == null || audioSource.isPlaying)
            return;

        audioSource.Play();
        audioSource.volume = 0;
    }

    public void Stop()
    {
        if (audioSource == null)
            return;

        audioSource.Stop();
    }

    public void Mute()
    {
        if (audioSource == null)
            return;

        audioSource.volume = 0;
    }
}
