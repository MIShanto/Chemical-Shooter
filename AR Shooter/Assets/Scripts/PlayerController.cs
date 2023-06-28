using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // The speed at which the camera moves
    Joystick joystick;

    private void Start()
    {
        foreach (string name in Enum.GetNames(typeof(GameManager.CollectableType)))
        {
            PlayerPrefs.DeleteKey(name);
        }

        joystick = GameManager.instance.hudManager.joystick;
        GameManager.instance.UpdateJoystickStatus(false);
    }
    void Update()
    {
        // Get the mouse input for rotating the camera
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Calculate movement vector
         Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        //Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        // Normalize movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Move player using the Translate method
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
