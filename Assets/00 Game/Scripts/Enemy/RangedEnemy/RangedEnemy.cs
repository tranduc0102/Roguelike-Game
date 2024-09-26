using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    public Bullet bulletPrefab;
    [SerializeField] protected float bulletSpeed;
    protected internal override void LoadData(EnemyData data)
    {
        speed = data.speed;
        attackRange = data.attackRange;
        bulletSpeed = 7f;
        timeAttack = data.timeAttack;
    }

    protected override void Attack()
    {
        base.Attack();
     
        Bullet bullet = PoolingManager.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(player.transform.position,bulletSpeed,"Player");

    }
    
}
