using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newPlayerData",menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    [Header("RunState")]
    public float runVelocity = 5.0f;
}
