using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public int NormalizedInputX { get; private set; }
    public int NormalizedInputY { get; private set; }
    private float jumpHoldTime = 0.2f;
    private float jumpStartTime;
    public bool jumpInputStop;
    private void Update()
    {
        CheckJumpHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormalizedInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormalizedInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpStartTime = Time.time;
            JumpInput = true;
            jumpInputStop = false;
        }
        if(context.canceled)
        {
            jumpInputStop = true;
        }
        
    }
    public void UsedJump() => JumpInput = false;
    private void CheckJumpHoldTime()
    {
        if(Time.time >= jumpStartTime + jumpHoldTime)
        {
            JumpInput = false;
        }
    }
}
