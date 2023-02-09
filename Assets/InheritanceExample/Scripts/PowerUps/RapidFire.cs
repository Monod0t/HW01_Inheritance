using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{

    TurretController turret;
    
    private void Start()
    {
        turret = FindObjectOfType<TurretController>();
    }

    protected override void PowerUp()
    {
        turret.FireCooldown /= 2;
    }

    protected override void PowerDown()
    {
        turret.FireCooldown *= 2;
    }

}
