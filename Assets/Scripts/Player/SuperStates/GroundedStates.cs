using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedStates : PlayerState
{
    protected int xInput;
    public GroundedStates(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
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
        xInput = player.inputHandler.NormalizedInputX;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
