using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpState : AbilityStates
{
    private int jumpTimesLeft;
    public Player_JumpState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {
        jumpTimesLeft = playerData.amountOfJump;
    }

    public bool CanJump()
    {
        if (jumpTimesLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetJumpTimes() => jumpTimesLeft = playerData.amountOfJump;
    public void DecreaseJumpTimes() => jumpTimesLeft--;

    public override void Enter()
    {
       
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        player.inAirState.SetIsJumping();
        isAbilityDone = true;
        jumpTimesLeft--;
    }
    

    
}
