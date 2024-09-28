using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    
   
    

    protected override void LoadCtrl()
    {
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected override void LoadData()
    {
        maxHp = enemyCtrl.MaxHp;
    }

    protected override void OnDead()
    {
        enemyCtrl.EnemyDespawner.Despawning();
    }
}
