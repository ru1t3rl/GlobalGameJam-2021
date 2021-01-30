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

    private void SetTimerUI(float timeLeft)
    {
        timerTxt.text = "Time Left: " + timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerUI(timerScript.timeLeft);
    }
}
