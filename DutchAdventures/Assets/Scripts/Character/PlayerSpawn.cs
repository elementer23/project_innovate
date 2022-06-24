using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creating of scriptable object PlayerPosistion
/// </summary>

[CreateAssetMenu(fileName = "PlayerPosition", menuName = "ScriptableObjects/PlayerPosition", order = 1)]
public class PlayerSpawn : ScriptableObject
{
    public Vector2 spawnPosition;
    
}
