using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Player : MonoBehaviour
{
    bool isLaunched = false;
    UnityEngine.CharacterController cc;
    FirstPersonController fpc;
    [SerializeField] float jumpForce = 2;
    float ySpeed = 0;
    Vector3 direction;
    [SerializeField] float rayDistance;
    [SerializeField] float jumpDrag = 2;
    [SerializeField] LayerMask layersToCheck;

    private void Awake()
    {
        cc = GetComponent<UnityEngine.CharacterController>();
        fpc = GetComponent<FirstPersonController>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.up * rayDistance);
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayDistance, layersToCheck))
        {

            if (hit.transform.gameObject != null)
            {
                //Debug.Log(hit.transform.gameObject);
                isLaunched = false;
                fpc.m_GravityMultiplier = 2f;
                fpc.m_MoveDir.y = 0;
            }
        }

        if (isLaunched && cc.velocity.y < 0)
        {
            fpc.m_GravityMultiplier = 2f;
        }
    }

    private void LaunchPlayer(Vector3 direction, float speed, float time)
    {
        if (!isLaunched)
        {
            cc.transform.DOMove(direction * speed, time);        
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<LaunchPad>())
        {            
            LaunchPlayer(hit.collider.transform.GetComponent<LaunchPad>().childTransform.up, jumpForce, 1f);
            isLaunched = true;
        }
    }
}
