using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenPuzzleManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> speakers;
    [SerializeField] GameObject ice;
    bool allActive = false;

    private void Update()
    {
        foreach(AudioSource source in speakers)
        {
            if (!source.isPlaying || source.volume == 0)
            {
                allActive = false;
                break;
            } else
            {
                allActive = true;
            }
        }

        if (allActive)
        {
            ice.SetActive(false);
        }
    }
}
