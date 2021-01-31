using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    bool CanDebug = false;

    float m_shootRateTimeStamp;
    float shootRate = 0.5f;
    float range = 1000.0f;

    [SerializeField]
    GameObject m_shotPrefab;

    [SerializeField]
    AudioSource shootSound;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanDebug) Debug.Log("mouse pressed");
            if (Time.time > m_shootRateTimeStamp)
            {
                shootSound.Play();
                shootRay();       
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    void shootRay()
    {
        if (CanDebug) Debug.Log("SHOOT");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (CanDebug) Debug.Log("HIT");
        GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;

        if (Physics.Raycast(ray, out hit, range))
        {
            laser.GetComponent<LaserBehaviour>().setTarget(hit.point);
            
        }
    }




}
