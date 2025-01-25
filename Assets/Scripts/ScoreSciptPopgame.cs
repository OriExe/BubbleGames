using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSciptPopgame : MonoBehaviour
{
    private static int playerScore; //Total Player Score

    [Tooltip("Amount of time taken to change score divided by 100")]
    [SerializeField] private float timeToChangeScore;
    private float timeToChange { get { return timeToChangeScore / 100; } } //Returns how long the game will take to increase the score by 1

    [SerializeField] private TMP_Text scoreText;
    private static AudioSource pop;
    // Start is called before the first frame update
    void Start()
    {
        
        pop = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int temp = Int32.Parse(scoreText.text);
        scoreText.text = UnityEngine.Mathf.FloorToInt(UnityEngine.Mathf.Lerp(playerScore, temp, timeToChange)).ToString();
        
    }
    public static void SetScore(float score)
    {
        pop.Play();
        int temp = UnityEngine.Mathf.FloorToInt(score);
        playerScore += temp;
    }
}
