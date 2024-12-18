using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] protected Bullet prefabBullet;
    
    protected override void Load()
    {
        enemyDamaged = new List<EnemyCtrl>();
        layerEnemy = LayerMask.GetMask("Enemy");
        hitdetection = GetComponent<Transform>().GetChild(0).GetChild(1);
       
    }

    protected override void StartAttack()
    {
        state = State.Attack;
        enemyDamaged.Clear();
    }

    protected override void AutoAim()
    {
        EnemyCtrl closeEnemy = GetClosestEnemy();
        Vector2 targetPoint = Vector2.up;
        if (closeEnemy != null)
        {
            targetPoint = (closeEnemy.transform.position - transform.position).normalized;
            Shoot(closeEnemy);
        }
        else
        {
            StopAttack();
        }
        transform.up = Vector3.Lerp(transform.up, targetPoint, Time.deltaTime*aimLeft);
        UpdateTime();
    }

    protected virtual void Shoot(EnemyCtrl closeEnemy)
    {
        if (timeDelay > attackDelay)
        {
            Bullet bullet = PoolingManager.Spawn(prefabBullet, hitdetection.position, quaternion.identity);
            AudioManager.Instance.PlayShootSound();
            bullet.Init(closeEnemy.transform.position,speedAttack,"Enemy");
            bullet.transform.GetComponent<PlayerBulletDamageSender>().Damage = transform.parent.GetComponent<PlayerCtrl>().Damage;
            timeDelay = 0f;
        }
    }
}