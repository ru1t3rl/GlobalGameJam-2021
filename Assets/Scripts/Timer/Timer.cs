using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft;
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
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    void Start()
    {
        Reset();    
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
    }

    private void Reset()
    {
        
    }
}
