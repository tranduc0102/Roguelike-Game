using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamgeSender : DamageSender
{
    public int enemyId;
    
    protected override void LoadData()
    {
        damage = data.listEnemyData[enemyId].damage;
    }
}
