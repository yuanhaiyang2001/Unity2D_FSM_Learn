using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedStates : PlayerState
{
    protected int xInput;
    private bool JumpInput;
    private bool isGrounded;
    public GroundedStates(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
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
        player.jumpState.ResetJumpTimes();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.inputHandler.NormalizedInputX;
        JumpInput = player.inputHandler.JumpInput;
        if (JumpInput && player.jumpState.CanJump())
        {
            player.inputHandler.UsedJump();
            stateMachine.ChangeState(player.jumpState);
            
        }else if (!isGrounded)
        {
            player.inAirState.ResetCoyoteTimeOver();
            stateMachine.ChangeState(player.inAirState);
        }
    }
        

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
