using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.GeneralActions general;

    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        general = playerInput.General;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        general.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(general.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        look.ProcessLook(general.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        general.Enable();
    }

    private void OnDisable()
    {
        general.Disable();
    }
}
