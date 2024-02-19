using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.Player.Move.performed += StartMove;
        myControls.Player.Move.canceled += StopMove;

        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Disable();
        //myControls.Disable();
    }

    private void StartMove(InputAction.CallbackContext callback)
    {
        valueX = callback.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext callback)
    {
        valueX = 0;
    }
}
