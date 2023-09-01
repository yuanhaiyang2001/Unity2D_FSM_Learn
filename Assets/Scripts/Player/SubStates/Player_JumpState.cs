using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpState : AbilityStates
{
    public Player_JumpState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animName) : base(player, playerData, stateMachine, animName)
    {
    }

    
}
