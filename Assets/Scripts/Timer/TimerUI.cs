using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    Text timerTxt;
    [SerializeField]
    Timer timerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Awake()
    {
        timerScript.endGame = EndGame;
    }

    private void EndGame()
    {
        timerTxt.text = "Game Over!";
    }

    private void SetTimerUI(float timeLeft)
    {
        if (!timerScript.timerUp)
        {
            int stringTimeLeft = (int)timeLeft;
            timerTxt.text = stringTimeLeft.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerUI(timerScript.TimeLeft);
    }
}
