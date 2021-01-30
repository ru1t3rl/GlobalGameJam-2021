using DG.Tweening;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] LayerMask moveAbleLayer;
    [SerializeField] float maxDistance = 10;
    [SerializeField] float tweenTime = 0.5f;
    RaycastHit hit;

    public void TryMoveObject()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, moveAbleLayer))
        {
            if (hit.transform != null)
            {
                hit.transform.DOMove(new Vector3(transform.position.x,
                                                 transform.position.y,
                                                 transform.position.z),
                                     tweenTime);

                this.transform.DOMoveY(hit.transform.localScale.y * 2, tweenTime / 2);
            }
        }
    }

    public void RemoveFromPlayer(Object Player)
    {
        Destroy(this);
    }

    public void AddToPlayer(Object player)
    {
        GameObject gobj = (GameObject)player;
        gobj.AddComponent<MoveObject>();
    }
}
