using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.QuickSearch.Providers;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] UnityEvent onEnterPortal;
    [SerializeField] UnityEvent<Vector3> onEnterPortalWithPos;
    [SerializeField] LoadSceneMode loadSceneMode = LoadSceneMode.Single;
    [SerializeField] string sceneName;
    Scene scene;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool unloadAfterLoadAdditive = false;
    bool loaded = false, entered = false;


    bool loadingScene = false;
    [SerializeField] float loadDelay = 0f;
    float timeToLoad;

    private void Update()
    {
        if(loadingScene && Time.time >= timeToLoad && loaded)
        {
            loaded = false;
            LoadScene();
        }
    }

    public void LoadScene()
    {
        try
        {
            if (!scene.isLoaded && entered)
            {
                SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
                scene = SceneManager.GetSceneByName(sceneName);
            }
        } 
        catch(Exception ex)
        {
            SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            scene = SceneManager.GetSceneByName(sceneName);
        }
    }

    public void UnloadScene()
    {
        if (scene.isLoaded && scene != null)
            SceneManager.UnloadSceneAsync(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer.ToInteger())
        {
            entered = true;

            onEnterPortalWithPos?.Invoke(transform.position);
            onEnterPortal?.Invoke();
            
            if(loadSceneMode == LoadSceneMode.Additive && unloadAfterLoadAdditive)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
            }

            if (!loadingScene)
            {
                loaded = true;
                timeToLoad = Time.time + loadDelay;
                loadingScene = true;              
            }
        }
    }
}
