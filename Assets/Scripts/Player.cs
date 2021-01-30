using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //
        if (collision.gameObject.GetComponent<SpeedPad>()) { }
            collision.gameObject.GetComponent<SpeedPad>().SetPlayerSpeed =
            (speed) => gameObject.GetComponent<Rigidbody>().velocity += speed;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }   
    }
}
