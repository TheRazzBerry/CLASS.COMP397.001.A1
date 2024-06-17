using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float verticalRotation = 0f;

    public float xSensitivity = 100f;
    public float ySensitivity = 100f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Camera Vertical Rotaion Calculation
        verticalRotation -= mouseY * Time.deltaTime * ySensitivity;

        // Camera Vertical Rotation Limits
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        // Apply Camera Transform
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Rotate Player Horizontally
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
