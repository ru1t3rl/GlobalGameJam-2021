using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
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

    private void RayCastPlayerHit()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.forward * rayDistance);
        if (Physics.Raycast(transform.position, -transform.forward, out hit, rayDistance))
        {
            if (hit.transform.gameObject != null && hit.transform.gameObject.GetComponent<Player>())
            {
                isActivated = true;
                Debug.Log(isActivated);
            }
        }
    }

    private void Awake()
    {
        if (pi.availableRewards.Count > 0)
        {
            reward = Instantiate(pi.availableRewards[Random.Range(0, pi.availableRewards.Count)]);
            reward.transform.GetChild(0).GetComponent<Reward>().SetPosition(portal);
            reward.SetActive(false);
        }
    }
}
