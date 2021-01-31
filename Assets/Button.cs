using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField]UnityEvent unlockDoor;
    bool isActivated;
    [SerializeField] PlayerInfo pi;
    [SerializeField] GameObject reward;
    [SerializeField] GameObject portal;
    [SerializeField] float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            reward.SetActive(true);
        }

        RayCastPlayerHit();
    }

    public void RayCastPlayerHit()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, (Camera.main.transform.position- transform.position ) * rayDistance);
        if (Physics.Raycast(transform.position, (Camera.main.transform.position -transform.position ), out hit, rayDistance))
        {
            if (hit.transform.gameObject != null && hit.transform.gameObject.GetComponent<Player>())
            {
                isActivated = true;
                unlockDoor?.Invoke();
                Debug.Log(isActivated);
            }
        }
    }

    private void Awake()
    {
        if (pi.availableRewards.Count > 0)
        {
            reward = Instantiate(pi.availableRewards[Random.Range(0, pi.availableRewards.Count)]);
            SetPosition(portal);
            reward.SetActive(false);
        }
    }

    public void SetPosition(GameObject portal)
    {
        reward.transform.position = portal.transform.position + portal.transform.forward * 3;
        reward.transform.position = new Vector3(reward.transform.position.x, reward.transform.position.y, reward.transform.position.z);
        
    }

}
