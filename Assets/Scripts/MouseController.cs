using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Reference to the camera we project from
    public Camera projectionCamera;

    // Update is called once per frame
    void Update(){
        // Get mouse psoition in pixels
        Vector3 mousePos = Input.mousePosition;

        // Calculate world position of mouse
        Vector3 worldPos = projectionCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));

        // Fix the height of our calculated position to match the current y position of the object
        // that way it moves only in 2D (XZ plane)
        worldPos.y = transform.position.y;

        // Update position of cursor to our newly calculated position
        transform.position = worldPos;
    }
}
