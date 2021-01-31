using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stuff")]
    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] GameObject player;
    [SerializeField] float portalPositionOffset = 1.1f;

    void Awake()
    {
        Debug.Log("Checking Player pos");
        if(playerInfo.enterPortalPosition != null && playerInfo.enterPortalPosition.x != 999999)
        {
            player.transform.position = playerInfo.enterPortalPosition;
            playerInfo.enterPortalPosition = new Vector3(999999, 0, 0);
        }
    }

    public void SetPlayerEnterPortalPosition(Vector3 portalPos)
    {
        playerInfo.enterPortalPosition = player.transform.position + (player.transform.position - portalPos).normalized * (Vector3.Dot(player.transform.position, portalPos) > 0 ? 1 : -1) * portalPositionOffset;
    }
}
