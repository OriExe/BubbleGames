using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timeToPlay;
    [SerializeField] TMP_Text timer;
    private bool GameEnded;
    private GameObject endPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToPlay > 0)
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

    void endGame()
    {
        endPage.SetActive(true);
    }
}
