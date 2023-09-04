using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LandState : GroundedStates
{
    public Player_LandState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (xInput != 0)
        {
            stateMachine.ChangeState(player.runState);
        }
        else if(isAnimationFinished)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
