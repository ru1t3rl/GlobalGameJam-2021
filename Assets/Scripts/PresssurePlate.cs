using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PresssurePlate : MonoBehaviour
{
    [SerializeField] UnityEvent onEnterPlate, onPlateExit;
    [SerializeField] LayerMask layerToIgnore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != layerToIgnore)
            onEnterPlate?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerToIgnore)
            onPlateExit?.Invoke();
    }
}
