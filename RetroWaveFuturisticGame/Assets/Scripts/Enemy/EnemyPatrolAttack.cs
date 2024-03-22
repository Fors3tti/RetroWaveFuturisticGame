using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAttack : EnemyAttack
{
    PlayerMoveControls playerMove;
    public float forceX;
    public float forceY;
    public float duration;

    public override void SpecialAttack()
    {
        playerMove = playerStats.GetComponentInParent<PlayerMoveControls>();
        StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform.parent));
    }
}
