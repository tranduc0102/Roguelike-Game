using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    public Bullet bulletPrefab;
    [SerializeField] protected float bulletSpeed;
    protected override void LoadData()
    {
        speed = 3f;
        attackRange = 6f;
        bulletSpeed = 7f;
        timeAttack = 1f;
    }

    protected override void Attack()
    {
        base.Attack();
     
        Bullet bullet = PoolingManager.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(player,bulletSpeed,"Player");

    }
    
}
