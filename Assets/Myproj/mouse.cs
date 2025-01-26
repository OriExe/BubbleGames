using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position
        float mouseX = Input.mousePosition.x;

        // Convert the mouse position from screen space to world space
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, Camera.main.nearClipPlane));

        // Update the object position on the X-axis, keep the original Y and Z
        transform.position = new Vector3(worldMousePos.x, transform.position.y, transform.position.z);
    }
}