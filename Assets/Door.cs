using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject[] door = new GameObject[2];
    [SerializeField] float moveDistance;
    [SerializeField] float moveDuration;

    bool open = false;

    /// <summary>
    ///     Opens the door using the X-axis
    /// </summary>
    public void Open()
    {
        door[0].transform.DOMoveX(door[0].transform.position.x + moveDistance, moveDuration);

        if (door.Length >= 2)
            door[1].transform.DOMoveX(door[1].transform.position.x - moveDistance, moveDuration);

        open = true;
    }

    /// <summary>
    ///     Closes the door using the X-axis
    /// </summary>
    public void Close()
    {
        door[0].transform.DOMoveX(door[0].transform.position.x - moveDistance, moveDuration);

        if (door.Length >= 2)
            door[1].transform.DOMoveX(door[1].transform.position.x + moveDistance, moveDuration);

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
