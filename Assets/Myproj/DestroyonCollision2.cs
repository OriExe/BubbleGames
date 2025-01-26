using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision2 : MonoBehaviour
{
    public int pointsToAward = 10;  // Points to award when the object is destroyed
    private PointsManager pointsManager;  // Reference to the PointsManager script

    void Start()
    {
        // Find the PointsManager in the scene (make sure the PointsManager is in your scene)
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
    }

    void OnDestroy()
    {
        // Award points when this object is destroyed
        pointsManager.AddPoints(pointsToAward);
    }

    // This method is called when a collision with another collider happens
    void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.CompareTag("square"))
        {
            // Destroy the object that this script is attached to
            Destroy(gameObject);
        }
    }

}