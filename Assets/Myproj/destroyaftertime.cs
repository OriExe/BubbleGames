using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // Set how many seconds before the object is destroyed
    public float timeBeforeDestroy = 5f;

    void Start()
    {
        // Call the DestroyObject function after "timeBeforeDestroy" seconds
        Invoke("DestroyObject", timeBeforeDestroy);
    }

    void DestroyObject()
    {
        // Destroy the object
        Destroy(gameObject);
    }
}