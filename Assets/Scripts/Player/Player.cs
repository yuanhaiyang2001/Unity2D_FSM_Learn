using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 组件
    public Animator Anim { get; private set; }
    public Rigidbody2D rB { get; private set; }
    
    #endregion
    #region 状态机和状态
    public PlayerStateMachine StateMachine { get; private set; }
    public Player_IdleState idleState { get;private set; }
    public Player_RunState runState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_LandState landState { get; private set; }
    public Player_InAirState inAirState { get; private set; }
    #endregion
    #region 地面检测
    public Transform groundCheck;
    #endregion
    #region 其他脚本组件
    public PlayerInputHandler inputHandler { get; private set; }
    [SerializeField]
    private PlayerData playerData;
    #endregion
    public int facingDirection { get; private set; }
    private Vector2 workSpace;
    public Vector2 currentVelocity{ get; private set; }
    #region unity生命周期函数
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        idleState = new Player_IdleState(this, playerData, StateMachine, "idle");
        runState = new Player_RunState(this, playerData, StateMachine, "run");
        jumpState = new Player_JumpState(this, playerData, StateMachine, "air");
        inAirState = new Player_InAirState(this, playerData, StateMachine, "air");
        landState = new Player_LandState(this, playerData, StateMachine, "land");
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
    #endregion

    #region set函数
    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, currentVelocity.y);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }
    public void SetVelocityY(float velocity)
    {
        workSpace.Set(currentVelocity.x,velocity);
        rB.velocity = workSpace;
        currentVelocity = workSpace;
    }
    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
    #region 检测函数
    public void CheckFlipCondition(int xIput)
    {
        if (xIput != 0 && facingDirection != xIput)
        {
            Flip();
        }
    }
    public bool GroundCheck()
    {
        
         return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRidius, playerData.whatIsGround);
        
    }
    #endregion
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, 0.3f);
    }
    private void AnimationTrigger()=>StateMachine.currentState.AnimationTrigger();
    
    private void AnimationFinishTrigger()=>StateMachine.currentState.AnimationFinishTrigger();
}
