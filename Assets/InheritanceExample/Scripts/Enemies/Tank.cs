using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] float cooldownTime = 1f;
    float cooldownTimer = 0f;
    
    protected override void OnHit()
    {
        cooldownTimer = cooldownTime;
    }


    protected override void Move()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (cooldownTimer <= 0)
        {
            Vector3 moveDelta = transform.forward * MoveSpeed;
            RB.MovePosition(RB.position + moveDelta);
        }

    }

}
