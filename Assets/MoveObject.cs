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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
            {
                if (hit.transform != null && hit.transform.gameObject.layer == moveAbleLayer.ToInteger())
                {
                    hit.transform.DOMove(new Vector3(transform.position.x,
                                                     transform.position.y,
                                                     transform.position.z),
                                         tweenTime);

                    this.transform.DOMoveY(hit.transform.localScale.y*2, tweenTime/2);
                }
            }
        }
    }

    public void RemoveFromPlayer(GameObject Player)
    {
        Destroy(this);
    }

    public void AddToPlayer(GameObject player)
    {
        player.AddComponent<MoveObject>();

    }
}
