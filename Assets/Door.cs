using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject[] door = new GameObject[2];
    [SerializeField] float moveDistance;
    [SerializeField] float moveDuration;
    Vector3[] startPos;
    bool open = false;

    private void Awake()
    {
        startPos = new Vector3[door.Length];

        for(int i = 0; i < door.Length; i++)
        {
            startPos[i] = door[i].transform.position;
        }
    }

    /// <summary>
    ///     Opens the door using the X-axis
    /// </summary>
    public void Open()
    {
        door[0].transform.DOMoveX(startPos[0].x + moveDistance, moveDuration);

        if (door.Length >= 2)
            door[1].transform.DOMoveX(startPos[1].x - moveDistance, moveDuration);

        open = true;
    }

    /// <summary>
    ///     Closes the door using the X-axis
    /// </summary>
    public void Close()
    {
        door[0].transform.DOMoveX(startPos[0].x, moveDuration);

        if (door.Length >= 2)
            door[1].transform.DOMoveX(startPos[1].x, moveDuration);

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
