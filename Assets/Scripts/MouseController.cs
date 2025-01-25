using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D mouseCollision;
    [SerializeField] private Camera cam;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseCollision.enabled = true;
            transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            mouseCollision.enabled = false;
        }
    }
}
