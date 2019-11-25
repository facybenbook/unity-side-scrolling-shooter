﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;

    public bool isMoving = true;

    float shipBoundaryRadius = 0.5f;

    void Update()
    {
        if (!isMoving) return;

        Vector3 pos = transform.position;
        Vector3 velocity;

        var horMovement = Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        var verMovement = -Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        // SHIFT button to slow down
        if (Input.GetButton("Slow"))
        {
            velocity = new Vector3(verMovement / 4 , horMovement / 4, 0);
        }
        else
        {
            velocity = new Vector3(verMovement, horMovement, 0);
        }

        pos += transform.rotation * velocity;

        // RESTRICT the player to the camera's boundaries!

        // First to vertical, because it's simpler
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        // Now calculate the orthographic width based on the screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        // Now do horizontal bounds
        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        // FINALLY
        transform.position = pos;
    }
}
