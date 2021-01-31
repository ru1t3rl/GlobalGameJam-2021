using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenPuzzleManager : MonoBehaviour
{
    [SerializeField] PlayerInfo plInfo;
    [SerializeField] List<AudioSource> speakers;
    [SerializeField] GameObject ice;
    bool allActive = false, wasActive = false;

    [SerializeField] GameObject portal;

    [SerializeField] float meltDuration;
    GameObject reward;

    private void Awake()
    {
        if(plInfo.availableRewards.Count > 0)
        {
            reward = Instantiate(plInfo.availableRewards[Random.Range(0, plInfo.availableRewards.Count)]);
            reward.transform.GetChild(0).GetComponent<Reward>().SetPosition(portal);
            reward.SetActive(false);
        }
    }

    private void Update()
    {
        foreach(AudioSource source in speakers)
        {
            if (!source.isPlaying || source.volume == 0)
            {
                allActive = false;
                break;
            } else
            {
                allActive = true;
            }
        }

        if (allActive && !wasActive && reward != null)
        {
            StartCoroutine(MeltIce());

            reward.gameObject.SetActive(true);

            wasActive = true;
        }
    }

    IEnumerator MeltIce()
    {
        ice.transform.DOScale(0, meltDuration);
        yield return new WaitForSeconds(meltDuration);
        ice.SetActive(false);
    }
}
