using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IdleState : GroundedStates
{
    public Player_IdleState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(xInput!= 0.0f)
        {
            stateMachine.ChangeState(player.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
