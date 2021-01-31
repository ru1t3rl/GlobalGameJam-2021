using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player Info", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public Vector3 enterPortalPosition;
    public List<Reward> rewards;
    public List<GameObject> availableRewards;
}
