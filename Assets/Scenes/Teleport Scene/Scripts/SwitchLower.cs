using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class SwitchLower : MonoBehaviour
{
    [SerializeField] private float activateSwitch;
    [SerializeField] private bool isChild;
    [SerializeField] private FirstPersonController fps;
    private bool BallTriggered = false;

    private Vector3 thisPosition;


    // Start is called before the first frame update
    void Start()
    {
        fps = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<FirstPersonController>();

        if (isChild)
        {
            thisPosition = this.gameObject.transform.GetChild(0).transform.position;

        }
        else if (!isChild)
        {
            thisPosition = this.gameObject.transform.position;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        
        string playerCol = col.gameObject.tag;

        if (this.gameObject.tag == "BallSpawner" && BallTriggered == false)
        {
            Debug.Log("Spawning Ball");
            fps.SpawnBall();
            BallTriggered = true;
        }
        else
        {
            Debug.Log("Didn't Spawn Ball");
        }

        if (isChild)
        {
            //string playerCol = col.gameObject.tag;
            if (playerCol == "Player")
            {
                this.gameObject.transform.transform.GetChild(0).transform.position = new Vector3(thisPosition.x, thisPosition.y - activateSwitch, thisPosition.z);
            }
        }
        else if (!isChild)
        {
            //string playerCol = col.gameObject.tag;
            if (playerCol == "Player")
            {
                this.gameObject.transform.position = new Vector3(thisPosition.x, thisPosition.y - activateSwitch, thisPosition.z);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (isChild)
        {
            this.gameObject.transform.transform.GetChild(0).transform.position = thisPosition;
        }
        else if (!isChild)
        {
            string playerCol = col.gameObject.tag;
            if (playerCol == "Player")
            {
                this.gameObject.transform.position = thisPosition;
            }
        }

    }
}
