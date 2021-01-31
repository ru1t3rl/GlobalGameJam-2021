using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    [SerializeField] AudioSource fx;
    [SerializeField] PlayerInfo defaultInfo, backupInfo;

    public void Exit()
    {
        fx.Play();
        Application.Quit();
    }

    public void Play()
    {
        fx.Play();
        SceneManager.LoadSceneAsync("Maze Scene");
    }

    public void Restart()
    {
        fx.Play();

        defaultInfo.availableRewards = backupInfo.availableRewards;
        defaultInfo.rewards = backupInfo.rewards;
        defaultInfo.enterPortalPosition = backupInfo.enterPortalPosition;

        SceneManager.LoadSceneAsync("Maze Scene");
    }
}
