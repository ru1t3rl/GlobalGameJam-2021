using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo;


    [SerializeField] RewardTypes type;
    Reward availableReference;

    [SerializeField] bool useSineMovement = true;

    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequentie = 0.1f;


    public bool fixX = false;
    public bool fixY = false;
    public bool fixZ = false;

    private float angle = 0.0f;
    private Vector3 localPosition = Vector3.zero;
    [SerializeField] private Vector3 center = Vector3.zero;

    private void Awake()
    {
        for (int iReward = 0; iReward < playerInfo.availableRewards.Count; iReward++)
        {
            if (playerInfo.availableRewards[iReward].GetComponent<Reward>().type == type)
            {
                availableReference = playerInfo.availableRewards[iReward].GetComponent<Reward>();
            }
        }

        if (availableReference == null)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInfo.rewards.Add(availableReference);
        playerInfo.availableRewards.Remove(availableReference.gameObject);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        angle += frequentie;

        if (!fixX)
        {
            localPosition.x = (amplitude * Mathf.Sin(angle) + center.x);
        }
        if (!fixY)
        {
            localPosition.y = (amplitude * Mathf.Sin(angle) + center.y);
        }
        if (!fixZ)
        {
            localPosition.z = (amplitude * Mathf.Sin(angle) + center.z);
        }

        transform.localPosition = localPosition;
    }
}

public enum RewardTypes
{
    Antenna,
    Diot,
    LED,
    FloppyDisk
}