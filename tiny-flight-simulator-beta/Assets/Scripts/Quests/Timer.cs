using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining;
    private float countdownTime = 6.0f;
    public bool isTimerRunning;
    public bool isCountdown = true;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI countdownText;
    
    
    void Start()
    {
        countdownText.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (isCountdown)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                updateTimer(countdownTime, countdownText);
            }
            else
            {
                isCountdown = false;
                countdownText.gameObject.SetActive(false);
                isTimerRunning = true;
            }
        } else
        {
            if (timeRemaining > 0)
            {
                timerText.gameObject.SetActive(true);
                timeRemaining -= Time.deltaTime;
                isTimerRunning = true;
                updateTimer(timeRemaining, timerText);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                isTimerRunning = false;
            }
        }
    }

    private void updateTimer(float timeLeft, TextMeshProUGUI timerTextArea)
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60); 
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        if(isCountdown)
        {
            timerTextArea.text = string.Format("{0:0}", seconds);
        }
        else
        {
            timerTextArea.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }
}
