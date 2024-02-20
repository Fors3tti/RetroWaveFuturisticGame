using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float moveInput;
    public bool jumpInput;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.Player.Move.performed += StartMove;
        myControls.Player.Move.canceled += StopMove;

        myControls.Player.Jump.performed += StartJump;
        myControls.Player.Jump.canceled += StopJump;

        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= StartJump;
        myControls.Player.Jump.canceled -= StopJump;

        myControls.Player.Disable();
        //myControls.Disable();
    }

    private void StartMove(InputAction.CallbackContext callback)
    {
        moveInput = Mathf.RoundToInt(callback.ReadValue<float>());
        Debug.Log("moveInput:" + moveInput);
    }

    private void StopMove(InputAction.CallbackContext callback)
    {
        moveInput = 0;
    }

    private void StartJump(InputAction.CallbackContext callback)
    {
        jumpInput = true;
    }

    private void StopJump(InputAction.CallbackContext callback)
    {
        jumpInput = false;
    }
}
