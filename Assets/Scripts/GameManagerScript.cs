using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timeToPlay;
    [SerializeField] TMP_Text timer;
    private bool GameEnded;

    #region EndGame Components
   [SerializeField] private GameObject endPage;
   [SerializeField]private TMP_Text ResultText;
   [SerializeField] private GameObject[] bubbleStars;
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
        if (timeToPlay > 0 || GameEnded)
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
        
    }

    public void endGame()
    {
        endPage.SetActive(true);

        Time.timeScale = 0f;
        if (timeToPlay > 0)
        {
            ResultText.text = "Oops you hit the red Bubble!";
        }
        else
        {
            StartCoroutine(showResults());
        }
    }

    IEnumerator showResults()
    {
        while (ScoreSciptPopgame.GetScore() != Int32.Parse(ResultText.text))
        {
            int temp = Int32.Parse(ResultText.text);
            ResultText.text = Mathf.FloorToInt(UnityEngine.Mathf.Lerp(temp, ScoreSciptPopgame.GetScore(),3f)).ToString();

            switch (Int32.Parse(ResultText.text))
            {
                case 6000:
                    bubbleStars[0].SetActive(true);
                    break;
                case 18000:
                    bubbleStars[1].SetActive(true);
                    break;
                case 60000:
                    bubbleStars[2].SetActive(true);
                    break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    
}
