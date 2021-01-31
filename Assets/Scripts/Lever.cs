using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [SerializeField] UnityEvent onSwitch;
    [SerializeField] GameObject moveAbleObject;
    [SerializeField] Vector3 activeRotation, inactiveRotation;
    [SerializeField] float switchDuration;
    [SerializeField] bool active = false;

    [SerializeField] float maxDistance = 10;
    RaycastHit hit;

    private void Awake()
    {
        moveAbleObject.transform.rotation = (active) ? Quaternion.Euler(activeRotation) : Quaternion.Euler(inactiveRotation);
    }

    public void TrySwitch()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            if (hit.transform.gameObject == gameObject)
            {
                active = !active;
                moveAbleObject.transform.DORotate((activeRotation - inactiveRotation)/2 * (active?1:-1), switchDuration);
                onSwitch?.Invoke();
            }
        }
    }
}
