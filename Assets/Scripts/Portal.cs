using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.QuickSearch.Providers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] UnityEvent onEnterPortal;

    [SerializeField] string sceneName;
    Scene scene;
    [SerializeField] float loadSceneDistance;
    [SerializeField] LayerMask playerLayer;
    bool loaded;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        scene = SceneManager.GetSceneByName(sceneName);
        UnloadScene();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= loadSceneDistance)
        {
            LoadScene();
        } else
        {
            UnloadScene();
        }
    }

    public void LoadScene()
    {
        if (!scene.isLoaded)
            SceneManager.LoadSceneAsync(scene.buildIndex, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        if (scene.isLoaded)
            SceneManager.UnloadSceneAsync(scene.buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == playerLayer.ToInteger())
        {
            other.gameObject.transform.position = scene.GetRootGameObjects()[1].transform.position;
            onEnterPortal?.Invoke();
        }
    }
}
