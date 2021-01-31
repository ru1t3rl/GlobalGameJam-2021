using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private Material shaderOff;
    [SerializeField] private Material shaderOn;
    [SerializeField] private GameObject platform;

    [SerializeField] private FirstPersonController fps;

    MeshRenderer rend;

    void Start()
    {
        rend = this.gameObject.GetComponent<MeshRenderer>();
        fps = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<FirstPersonController>();
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "TeleBall")
        {
            rend.material = shaderOn;
            var teleportPos = platform.transform.position + Vector3.up * 2f;
            fps.Teleport(teleportPos);

            Debug.Log(col.gameObject.name);
        }
    }
    //public void OnTriggerExit(Collider col)
    //{
    //    if (col.gameObject.name == "TeleBall")
    //    {
    //        rend.material = shaderOff;
    //        Debug.Log(col.gameObject.name);
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.gameObject.GetComponent<MeshRenderer>().material = shaderOn;
            Debug.Log("H");
        }
        //else if (Input.GetKeyDown(KeyCode.J))
        //{
        //    this.gameObject.GetComponent<MeshRenderer>().material = shaderOff;
        //    Debug.Log("J");
        //}
    }
}
