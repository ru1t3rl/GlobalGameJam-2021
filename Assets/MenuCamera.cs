using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] float yRotationSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up, yRotationSpeed);
    }
}
