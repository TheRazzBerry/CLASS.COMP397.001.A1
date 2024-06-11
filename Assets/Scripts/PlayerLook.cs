using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 100f;
    public float ySensitivity = 100f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Camera Vertical Rotaion Calculation
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;

        // Camera Vertical Rotation Limits
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply Camera Transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate Player Horizontally
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
