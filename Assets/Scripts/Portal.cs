using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.QuickSearch.Providers;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] UnityEvent onEnterPortal, onGetCloseToPortal;

    [SerializeField] string sceneName;
    Scene scene;
    [SerializeField] float loadSceneDistance;
    [SerializeField] LayerMask playerLayer;
    bool loaded, entered = false;

    public void LoadScene()
    {
        if (!scene.isLoaded && entered)
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        if (scene.isLoaded)
            SceneManager.UnloadSceneAsync(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == playerLayer.ToInteger())
        {
            onEnterPortal?.Invoke();
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}
