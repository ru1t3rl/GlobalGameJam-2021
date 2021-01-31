using System.Collections;
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

    [SerializeField] string explanaition;
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] float timeVisible;

    void Awake()
    {
        if(playerInfo.enterPortalPosition != null && playerInfo.enterPortalPosition.x != defaultPosXValue)
        {
            player.transform.position = playerInfo.enterPortalPosition;
            playerInfo.enterPortalPosition = new Vector3(defaultPosXValue, 0, 0);
            StartCoroutine(ShowInstructions());
        }

        artificats.text = $"{playerInfo.rewards.Count}/{playerInfo.availableRewards.Count}";

        DontDestroyOnLoad(gameObject);

        instructionText.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == player.layer)
        {
            if(playerInfo.availableRewards.Count <= 0 || playerInfo.availableRewards.Count <= playerInfo.rewards.Count)
            {
                StartCoroutine(ShowVictory());
            }
        }
    }

    IEnumerator ShowVictory()
    {
        instructionText.text = "Congratulations a found all the artificats and was able to escape!";
        instructionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeVisible);

        try
        {
            instructionText.gameObject.SetActive(false);
            SceneManager.LoadSceneAsync("Victory");
        }
        catch (MissingReferenceException)
        {

        }
    }

    IEnumerator ShowInstructions()
    {
        instructionText.text = explanaition;
        instructionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeVisible);

        try
        {
            instructionText.gameObject.SetActive(false);
        } catch( MissingReferenceException)
        {

        }
    }

    public void SetPlayerEnterPortalPosition(Vector3 portalPos)
    {
        playerInfo.enterPortalPosition = player.transform.position + (player.transform.position - portalPos).normalized * (Vector3.Dot(player.transform.position, portalPos) > 0 ? 1 : -1) * portalPositionOffset;
    }
}
