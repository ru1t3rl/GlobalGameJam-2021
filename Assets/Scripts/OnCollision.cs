using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public System.Action<Collision> onCollisionEnter, onCollisionExit, onCollisionStay;
    public System.Action<Collider> onTriggerEnter, onTriggerExit, onTriggerStay;
    public System.Action<ControllerColliderHit> onControllerColliderHit;

    #region OnCollision
    public void OnCollisionEnter(Collision collision)
    {
        onCollisionEnter?.Invoke(collision);
    }

    public void OnCollisionExit(Collision collision)
    {
        onCollisionExit?.Invoke(collision);
    }

    public void nCollisionStay(Collision collision)
    {
        onCollisionStay?.Invoke(collision);
    }
    #endregion

    #region OnTrigger
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay?.Invoke(other);
    }
    #endregion

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        onControllerColliderHit?.Invoke(hit);
    }
}
