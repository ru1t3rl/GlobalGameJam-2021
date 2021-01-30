using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : SpeedPad
{
    protected override Vector3 DirectionToLaunch()
    {
        Debug.Log("Test");
        return transform.up * 10;
    }
}
