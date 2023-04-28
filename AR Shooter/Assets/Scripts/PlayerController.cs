using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float lookSpeed = 3f; // The speed at which the camera moves

    void Update()
    {
        // Get the mouse input for rotating the camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player object horizontally based on the mouse input
        transform.Rotate(0f, mouseX * lookSpeed, 0f);
    }
}
