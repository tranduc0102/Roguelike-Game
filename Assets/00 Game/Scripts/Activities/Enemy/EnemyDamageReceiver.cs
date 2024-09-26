using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    public int enemyIndex;
    protected override void LoadData()
    {
        maxHp = data.listEnemyData[enemyIndex].maxHp;
    }
}
