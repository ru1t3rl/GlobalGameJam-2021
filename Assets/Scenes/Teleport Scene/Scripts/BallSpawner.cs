using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private FirstPersonController fps;

    void Start()
    {
        fps = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<FirstPersonController>();
    }

    void OnTriggerEnter(Collider col)
    {
        string playerCol = col.gameObject.tag;
        if (playerCol == "Player")
        {
            fps.ReturnBallGrav();
        }
    }
}
