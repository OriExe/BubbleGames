using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use this if you're using TextMeshPro. If you're using Unity's default Text, use UnityEngine.UI instead.

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f; // Time in seconds (e.g., 30 seconds countdown)
    public TMP_Text timerText;  // Reference to the TextMeshPro text component
    private bool timerIsRunning = false;


    void Start()
    {
        // Start the timer
        timerIsRunning = true;
    }

    void Update()
    {
        // Only update the timer if it's running
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Decrease the time by the time passed since last frame
                timeRemaining -= Time.deltaTime;

                // Display the time as minutes:seconds (formatted as a string)
                timerText.text = Mathf.Floor(timeRemaining / 60).ToString("00") + ":" + (timeRemaining % 60).ToString("00");
            }
            else
            {
                // If the timer runs out, stop it and show "Time's Up!" or something else
                timerText.text = "Time's Up!";
                timerIsRunning = false;


            }
        }
    }
}