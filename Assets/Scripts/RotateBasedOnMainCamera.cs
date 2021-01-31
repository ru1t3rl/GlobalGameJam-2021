using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBasedOnMainCamera : MonoBehaviour
{
    [SerializeField] float yOffset = 0;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y + yOffset, 0);
    }
}
