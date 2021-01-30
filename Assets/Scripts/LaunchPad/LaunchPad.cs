using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : SpeedPad
{
    public Transform childTransform;

    protected override Vector3 DirectionToLaunch()
    {
        Debug.Log("Hitting Player");
        return transform.up * 1;
    }
}
