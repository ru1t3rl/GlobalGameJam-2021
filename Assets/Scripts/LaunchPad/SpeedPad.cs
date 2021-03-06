using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : Powerup
{
    protected Vector3 directionToLaunch;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            
            SetPlayerSpeed?.Invoke(DirectionToLaunch());
        }
    }


    protected virtual Vector3 DirectionToLaunch()
    {
        return directionToLaunch;
    }

    
}
