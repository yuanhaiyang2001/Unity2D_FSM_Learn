using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newPlayerData",menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    [Header("RunState")]
    public float runVelocity = 5.0f;
    [Header("JumpState")]
    public float jumpVelocity = 50.0f;
    [Header("LayerMask")]
    public float groundCheckRidius = 0.3f;
    public LayerMask whatIsGround;
    public int amountOfJump = 2;
    public float coyoteTime = 0.2f;
    public float heightMultiplier = 0.5f;
}
