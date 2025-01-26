using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use this if you're using TextMeshPro for text. Otherwise, use UnityEngine.UI.

public class PointsManager : MonoBehaviour
{
    public int points = 0;  // Variable to store points
    public TMP_Text pointsText;  // Reference to the TextMeshPro Text component to display points

    void Start()
    {
        UpdatePointsDisplay();  // Update the points display when the game starts
    }

    // Method to add points
    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsDisplay();  // Update the points display after adding points
    }

    // Method to update the points UI
    void UpdatePointsDisplay()
    {
        pointsText.text = "Points: " + points.ToString();
    }
}