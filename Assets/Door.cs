using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject[] door = new GameObject[2];
    [SerializeField] float moveDistance;
    [SerializeField] AudioSource source;

    Vector3[] startPos;
    bool open = false;

    private void Awake()
    {
        startPos = new Vector3[door.Length];

        for(int i = 0; i < door.Length; i++)
        {
            startPos[i] = door[i].transform.localPosition;
        }
    }

    /// <summary>
    ///     Opens the door using the X-axis
    /// </summary>
    public void Open()
    {
        if (source.isPlaying)
            source.Stop();
        source.Play();

        door[0].transform.DOLocalMoveX(startPos[0].x + moveDistance, source.clip.length);

        if (door.Length >= 2)
            door[1].transform.DOLocalMoveX(startPos[1].x - moveDistance, source.clip.length);

        open = true;
    }

    /// <summary>
    ///     Closes the door using the X-axis
    /// </summary>
    public void Close()
    {
        if (source.isPlaying)
            source.Stop();
        source.Play();

        door[0].transform.DOLocalMoveX(startPos[0].x, source.clip.length);

        if (door.Length >= 2)
            door[1].transform.DOLocalMoveX(startPos[1].x, source.clip.length);

        open = false;
    }

    public void Toggle()
    {
        if (open)
            Close();
        else
            Open();
    }
}
