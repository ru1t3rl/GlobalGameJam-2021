using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform startPos;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Reset()
    {
        player.transform.position = startPos.position;
    }


    private void Update()
    {
        //Debug.Log(player.transform.position.y + "Player Y POS");
        //if (player.transform.position.y < -5)
        //{
        //    //Reset();
        //}
    }
}
