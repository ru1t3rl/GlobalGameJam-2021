using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] PlayerInfo plInfo;
    public Action endGame;
    public bool timerUp;
    float timeLeft;
    bool loaded;

    public float TimeLeft {
        get { return timeLeft; }
    }
    #region Instance

    private static Timer _instance;
    public static Timer Instance
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Timer>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (!plInfo.LoadedTimer && !loaded)
        {
            DontDestroyOnLoad(transform.parent.gameObject);
            loaded = true;
            plInfo.LoadedTimer = true;
        }
        else
            Destroy(transform.parent.gameObject);
    }

    #endregion

    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
        TimeOver();
    }

    private void Reset()
    {
        timerUp = false;
        timeLeft = 300;
    }

    void TimeOver() {
        
        if (timeLeft < 0)
        {
            timeLeft = 0;
            EndGame();
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    private void EndGame()
    {
        timerUp = true;
        endGame?.Invoke();
    }
}
