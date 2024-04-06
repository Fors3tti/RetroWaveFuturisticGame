using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float moveInput;
    public bool jumpInput;

    public float climbInput;
    public bool tryToClimb;

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

        myControls.Player.Climb.performed += ClimbStart;
        myControls.Player.Climb.canceled += ClimbStop;

        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= StartJump;
        myControls.Player.Jump.canceled -= StopJump;

        myControls.Player.Climb.performed -= ClimbStart;
        myControls.Player.Climb.canceled -= ClimbStop;

        myControls.Player.Disable();
        //myControls.Disable();
    }

    public void DisableControls()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= StartJump;
        myControls.Player.Jump.canceled -= StopJump;

        myControls.Player.Climb.performed -= ClimbStart;
        myControls.Player.Climb.canceled -= ClimbStop;

        myControls.Player.Disable();
        moveInput = 0;
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

    private void ClimbStart(InputAction.CallbackContext ctx)
    {
        climbInput = Mathf.RoundToInt(ctx.ReadValue<float>());

        if (Mathf.Abs(climbInput) > 0)
        {
            tryToClimb = true;
        }
    }

    private void ClimbStop(InputAction.CallbackContext ctx)
    {
        tryToClimb = false;
        climbInput = 0;
    }
}
