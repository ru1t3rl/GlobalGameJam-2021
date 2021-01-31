using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRotate : MonoBehaviour
{
    public bool canRotate { get; set; }
    [SerializeField] private bool switchRotate;
    [SerializeField] private float rotationSpeed =0.1f;

    void Update()
    {
        if (switchRotate)
        {
            this.transform.Rotate(Vector3.up, rotationSpeed);
        }
        else if (!switchRotate)
        {
            this.transform.Rotate(Vector3.up, -rotationSpeed);
        }
    }
}
