using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlatformObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezePosition | 
                            RigidbodyConstraints.FreezeRotationX |
                                RigidbodyConstraints.FreezeRotationZ;
    }
}
