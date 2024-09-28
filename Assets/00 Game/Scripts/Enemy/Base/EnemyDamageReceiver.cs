using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    
   
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void LoadCtrl()
    {
        enemyCtrl = transform.GetComponent<EnemyCtrl>();
    }

    protected override void LoadData()
    {
        maxHp = enemyCtrl.enemyData.listEnemyData[enemyCtrl.enemyIndex].maxHp;
    }
}
