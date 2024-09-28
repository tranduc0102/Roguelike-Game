using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected PlayerSendDamage playerSendDamage;
    protected override void Load()
    {
        base.Load();
        playerSendDamage = transform.GetComponent<PlayerSendDamage>();
    }

    protected override void AttackEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitdetection.position, radiusHit, layerEnemy);
        foreach (var enemy in enemies)
        {
            if (!enemyDamaged.Contains(enemy.GetComponent<EnemyCtrl>()))
            {
                enemyDamaged.Add(enemy.GetComponent<EnemyCtrl>());
                DoMeleeAttack(enemy.transform);
            }
        }
    }

    protected virtual void DoMeleeAttack(Transform enemy)
    {
        playerSendDamage.SendDamage(enemy);
    }
}
