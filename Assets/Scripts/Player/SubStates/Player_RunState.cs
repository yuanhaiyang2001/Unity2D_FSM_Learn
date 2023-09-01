using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RunState : GroundedStates
{
    public Player_RunState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        player.CheckFlipCondition(xInput);
        player.SetVelocityX(playerData.runVelocity * xInput);
        if(xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
