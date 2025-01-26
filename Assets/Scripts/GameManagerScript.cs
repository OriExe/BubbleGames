using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timeToPlay;
    [SerializeField] TMP_Text timer;
    private bool GameEnded;

    #region EndGame Components
   [SerializeField] private GameObject endPage;
   [SerializeField]private TMP_Text ResultText;
   [SerializeField] private GameObject[] bubbleStars;
    private float timeLeft;
    private bool PlayerWon = false;
    #endregion

    public static GameManagerScript instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToPlay > 0.9f || GameEnded)
        {
            timeToPlay -= Time.deltaTime;
            timer.text = Mathf.FloorToInt(timeToPlay).ToString();
        }
        else
        {
            if (!GameEnded)
            {
                GameEnded = true;
                endGame();
            }
        }
        #region EndGame
        
            
            
        
        #endregion 

    }

    public void endGame()
    {
        endPage.SetActive(true);

        Time.timeScale = 0f;
        if (timeToPlay > 1)
        {
            ResultText.text = "Oops you hit the red Bubble!";
        }
        else
        {
            PlayerWon = true;
            ResultText.text = ScoreSciptPopgame.GetScore().ToString();
            if (ScoreSciptPopgame.GetScore() >= 6000)
            {
                StartCoroutine(showBubbleStar(bubbleStars[0], 1));
            }

            if (ScoreSciptPopgame.GetScore() >= 12000)
            {
                StartCoroutine(showBubbleStar(bubbleStars[1], 2));
            }
            if ((ScoreSciptPopgame.GetScore() >= 18000))
            {
                StartCoroutine(showBubbleStar(bubbleStars[2], 3));
            }
        }

    }
    
    

    IEnumerator showBubbleStar(GameObject toShow, int TimeLeft)
    {
        yield return new WaitForSecondsRealtime(timeLeft);
        toShow.SetActive(true);
    }
    
    

    
}
