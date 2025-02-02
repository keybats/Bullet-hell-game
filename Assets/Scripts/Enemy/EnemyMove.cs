using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Attack
{
    
    public bool isLaser;
    [ConditionalHide("isLaser", true)] public float laserStartRotation;
    [ConditionalHide("isLaser", true)] public float laserRotation;
    [ConditionalHide("isLaser", true)] public float laserDuration;
    public bool originatesFromEnemy;
    public Vector2 peojectileSpawnPoint;
    public float attackCooldown;
    public Projectile projectile;
    public int projectileAmount;
    public float projectileSpeed;
    public float projectileSpread;
    public float projectileRotation;
    public float damage;
}

[System.Serializable]
public class Movement
{
    public Vector2 movementPosition;
    public float movementSpeed;
}

[System.Serializable]
public class EnemyMove
{
    public List<Attack> attacks;
    public List<Movement> movements;
    public Vector2 startPosition;
    public float startPosSpeed;
    public string name;
}
