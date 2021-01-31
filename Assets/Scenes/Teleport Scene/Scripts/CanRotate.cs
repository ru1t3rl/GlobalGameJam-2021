using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRotate : MonoBehaviour
{
    [SerializeField] private bool canRotate;
    [SerializeField] private bool switchRotate;
    [SerializeField] private float rotationSpeed =0.1f;

    void Update()
    {
        if (canRotate && switchRotate)
        {
            this.transform.Rotate(Vector3.up, rotationSpeed);
        }
        else if (canRotate && !switchRotate)
        {
            this.transform.Rotate(Vector3.up, -rotationSpeed);
        }
    }
}
