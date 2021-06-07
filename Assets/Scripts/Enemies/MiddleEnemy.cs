using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemy : EnemyStats
{
    private void OnEnable()
    {
        Shoot.playerShoot.ThrowMegaBombReleased += GranadeImpact;
    }

    private void OnDisable()
    {
        Shoot.playerShoot.ThrowMegaBombReleased -= GranadeImpact;
    }

    void GranadeImpact()
    {
        life -= 6;
        if (life <= 0)
        {
            Die();
        }
    }
}
