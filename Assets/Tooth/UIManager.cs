using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timeText;
    public Text pointsText;

    private Minigame1Controller minigameController;

    

    // Start is called before the first frame update
    void Start()
    {
        minigameController = FindObjectOfType<Minigame1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        int timeLeft = minigameController.maxTime - minigameController.elapsedTime;
        timeText.text = "Time " + timeLeft;
        pointsText.text = "Points: " + minigameController.pointCounter;
    }
}
