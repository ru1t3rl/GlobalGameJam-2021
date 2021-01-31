using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class MoveObject : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float mass = 1f;
    [SerializeField] private float drag = 0.6f;
    [SerializeField ]private float dragAng = 0.6f;

    private void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.drag = drag;
        rb.angularDrag = dragAng;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
}
