using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStates : PlayerState
{
    protected bool isAbilityDone;
    private bool isGrounded;
    public AbilityStates(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        
        isGrounded = player.GroundCheck();
        
    }

    public override void Enter()
    {
        isAbilityDone = false;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
            if (isGrounded && player.currentVelocity.y<0.1)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                stateMachine.ChangeState(player.inAirState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
