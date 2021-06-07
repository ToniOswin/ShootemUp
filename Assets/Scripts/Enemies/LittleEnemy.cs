using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleEnemy : EnemyStats
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
        Die();
    }
}
