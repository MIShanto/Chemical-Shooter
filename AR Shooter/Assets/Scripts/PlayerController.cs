using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // The speed at which the camera moves
    public Joystick joystick;
    GameObject camera;
    private void Start()
    {
        camera = Camera.main.gameObject;
    }
    void Update()
    {
        // Get the mouse input for rotating the camera
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // Normalize movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Move player using the Translate method
        camera.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
