using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter, onPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        onPlayerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onPlayerExit?.Invoke();
    }
}
