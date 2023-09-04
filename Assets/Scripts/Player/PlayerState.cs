using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerState
{
    protected Player player;
    protected PlayerData playerData;
    protected PlayerStateMachine stateMachine;

    public string animName { get; private set; }

    protected float startTime;
    protected bool isAnimationFinished;

    public PlayerState(Player player,PlayerData playerData,PlayerStateMachine stateMachine,string animName)
    {
        this.player = player;
        this.playerData = playerData;
        this.stateMachine = stateMachine;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        player.Anim.SetBool(animName, true);
        DoChecks();
        startTime = Time.time;
        isAnimationFinished = false;
        Debug.Log(animName);
    }
    public virtual void Exit() 
    {
        player.Anim.SetBool(animName, false);
        
    }
    public virtual void LogicUpdate()
    {
       
    }
    public virtual void PhysicsUpdate() 
    {
        DoChecks();
    }
    public virtual void DoChecks(){}
    public virtual void AnimationTrigger() { }
    public virtual void AnimationFinishTrigger()=>isAnimationFinished = true;

}
