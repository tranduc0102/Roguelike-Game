using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected PlayerSendDamage playerSendDamage;
    protected override void OnEnable()
    {
        base.OnEnable();
        attackDelay = 2f;
        playerSendDamage = transform.GetComponent<PlayerSendDamage>();
    }

    protected override void AutoAim()
    {
        BaseEnemy closeEnemy = GetClosestEnemy();
        Vector2 targetPoint = Vector2.up;
        if (closeEnemy != null)
        {
            targetPoint = (closeEnemy.transform.position - transform.position).normalized;
            if(CanDoAttack()) DoMeleeAttack(closeEnemy.transform);
        }
        else
        {
            StopAttack();
        }
        transform.up = Vector3.Lerp(transform.up, targetPoint, Time.deltaTime*aimLeft);
        UpdateTime();
    }

    protected virtual bool CanDoAttack()
    {
        return timeDelay > attackDelay;
    }
    protected virtual void DoMeleeAttack(Transform enemy)
    {
        playerSendDamage.SendDamage(enemy);
    }
}
