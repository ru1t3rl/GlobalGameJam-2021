using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stuff")]
    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] GameObject player;
    [SerializeField] float portalPositionOffset = 1.1f;
    [SerializeField] float defaultPosXValue = 999999;

    [SerializeField] TextMeshProUGUI artificats;

    [SerializeField]

    void Awake()
    {
        if(playerInfo.enterPortalPosition != null && playerInfo.enterPortalPosition.x != defaultPosXValue)
        {
            player.transform.position = playerInfo.enterPortalPosition;
            playerInfo.enterPortalPosition = new Vector3(defaultPosXValue, 0, 0);
        }

        artificats.text = $"{playerInfo.rewards.Count}/{playerInfo.availableRewards.Count}";

        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == player.layer)
        {
            if(playerInfo.availableRewards.Count <= 0)
            {
                // Do something since the players has gathered all the rewards
            }
        }
    }

    public void SetPlayerEnterPortalPosition(Vector3 portalPos)
    {
        playerInfo.enterPortalPosition = player.transform.position + (player.transform.position - portalPos).normalized * (Vector3.Dot(player.transform.position, portalPos) > 0 ? 1 : -1) * portalPositionOffset;
    }
}
