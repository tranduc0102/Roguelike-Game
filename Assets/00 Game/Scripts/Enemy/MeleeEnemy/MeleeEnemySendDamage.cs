using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemySendDamage : DamageSender
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    
    protected override void LoadCtrl()
    {
        enemyCtrl = transform.parent.parent.GetComponent<EnemyCtrl>();
    }

    protected override void LoadData()
    {
        damage = enemyCtrl.Damage;
    }
}
