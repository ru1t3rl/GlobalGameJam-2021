using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] string baseSceneName;

    Vector3 positionBeforeTeleport;
   
    List<Reward> rewards;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(baseSceneName, LoadSceneMode.Additive);
    }
}
