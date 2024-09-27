using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemySendDamage : DamageSender
{
    public int enemyIndex;
    protected override void LoadData()
    {
        damage = data.listEnemyData[enemyIndex].damage;
    }
}
