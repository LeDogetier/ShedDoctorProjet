using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private DifficultyManager difficultyManager;

    public bool IsRunning;

    [SerializeField]
    private Text timerText;

    private void Awake()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<DifficultyManager>();

        IsRunning = false;
    }

    private void OnEnable()
    {
        IsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (IsRunning)
        {
            if (difficultyManager.TimeRemaining > 0)
            {
                difficultyManager.TimeRemaining -= Time.deltaTime;
                difficultyManager.TimeRemaining = Mathf.Max(difficultyManager.TimeRemaining, 0);
                UpdateTimerDisplay();
            }
            else
            {
                Debug.Log("Time is up");
                
                IsRunning = false;
            }
        }
       
       
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = FormatTime(difficultyManager.TimeRemaining);
        }
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
