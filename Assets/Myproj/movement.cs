using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // Speed of the movement

    void Update()
    {
        // Move the object upwards by modifying its position every frame
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
