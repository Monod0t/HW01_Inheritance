using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] GameObject droppedPowerUp;

    protected override void OnHit()
    {
        // Increase speed on hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        Instantiate(droppedPowerUp, this.transform.position, Quaternion.identity);

        base.Kill();
    }

}
