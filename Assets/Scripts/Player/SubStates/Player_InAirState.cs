using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_InAirState : PlayerState

{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool coyoteTimeOver;
    private bool isJumping;
    private bool jumpInputStop;


    
    public Player_InAirState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.GroundCheck();

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        
        base.LogicUpdate();
        CheckCoyoteTime();
        xInput = player.inputHandler.NormalizedInputX;
        jumpInput = player.inputHandler.JumpInput;
        jumpInputStop = player.inputHandler.jumpInputStop;
        CheckHeightMultiplier();


        if (isGrounded && player.currentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
        }else if (jumpInput&&player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else
        {
            
            player.CheckFlipCondition(xInput);
            player.SetVelocityX(playerData.runVelocity * xInput);
            player.Anim.SetFloat("yVelocity",player.currentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(player.currentVelocity.x));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private void CheckCoyoteTime()
    {
        if(coyoteTimeOver&&Time.time > startTime+playerData.coyoteTime)
        {
            coyoteTimeOver = false;
            player.jumpState.DecreaseJumpTimes();
        }
    }
    public void ResetCoyoteTimeOver()=>coyoteTimeOver=true;
    private void CheckHeightMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.currentVelocity.y * playerData.heightMultiplier);
                isJumping = false;
            }
            else if (player.currentVelocity.y <= 0)
            {
                isJumping = false;
            }
        }
    }
    public void SetIsJumping()=>isJumping=true;
}   
   
    





