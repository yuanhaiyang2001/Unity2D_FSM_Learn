using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }

    public PlayerState idleState { get;private set; }
    public PlayerState runState { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        idleState = new Player_IdleState(this, playerData, StateMachine, "idle");
        runState = new Player_RunState(this, playerData, StateMachine, "run");
        
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        inputHandler = GetComponent<PlayerInputHandler>();
        StateMachine.Initialize(idleState);
    }

    
    void Update()
    {
        StateMachine.currentState.LogicUpdate();
        
    }
    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
}
