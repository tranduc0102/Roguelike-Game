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
                if (enemy.GetComponentInChildren<EnemyDamageReceiver>() != null)
                {
                    DoMeleeAttack(enemy.GetComponentInChildren<EnemyDamageReceiver>().transform);
                }
            }
        }
    }

    protected virtual void DoMeleeAttack(Transform enemy)
    {
        playerSendDamage.Damage = damage;
        playerSendDamage.SendDamage(enemy);
    }
}
