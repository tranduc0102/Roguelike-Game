using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : EnemyAttack
{
    protected override void Attacking()
    {
        if (enemyCtrl is not RangedEnemyCtrl rangedEnemyCtrl)
        {
            Debug.LogWarning("Type of Ranged Enemy is not right");
            return;
        }

        Bullet bullet = PoolingManager.Spawn(rangedEnemyCtrl.bulletPrefab, transform.parent.position, Quaternion.identity);
        bullet.Init(rangedEnemyCtrl.Player.transform.position,rangedEnemyCtrl.BulletSpeed,"Player");
        bullet.transform.GetComponent<EnemyBulletDamgeSender>().Damage = rangedEnemyCtrl.Damage;
    }
}
