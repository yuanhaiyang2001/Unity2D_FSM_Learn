using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D rB { get; private set; }
    #endregion
    #region States״̬
    public PlayerState idleState { get;private set; }
    public PlayerState runState { get; private set; }
    #endregion
    public PlayerInputHandler inputHandler { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    [SerializeField]
    private PlayerData playerData;
    public int facingDirection { get; private set; }

    private Vector2 workSpace;
    public Vector2 currentVelocity{ get; private set; }

    
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
        rB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(idleState);
        facingDirection = 1;
    }

    
    void Update()
    {
        currentVelocity = rB.velocity;
        StateMachine.currentState.LogicUpdate();
        
    }
    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, currentVelocity.y);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }
    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    public void CheckFlipCondition(int xIput)
    {
        if (xIput != 0 && facingDirection != xIput)
        {
            Flip();
        }
    }
}
