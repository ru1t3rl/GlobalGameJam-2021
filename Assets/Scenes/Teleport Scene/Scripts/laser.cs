using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class laser : MonoBehaviour
{
    [SerializeField] private FirstPersonController fps;
    [SerializeField] private int hitCount = 0;
    [SerializeField] private int lives = 1;

    void Start()
    {
        fps = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<FirstPersonController>();
    }
    void OnTriggerEnter(Collider player)
    {
        string playerCol = player.gameObject.tag;
        if (playerCol == "Player")
        {
            Debug.Log("PLAYER WAS HIT!!!");
            hitCount++;
            if (hitCount == lives)
            {
                TeleportStart();
            }
        }
    }
    void TeleportStart()
    {
        fps.Teleport(new Vector3(0f, 2, 0f));
    }
}
