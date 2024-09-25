using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    
    protected internal override void LoadData(EnemyData data)
    {
        speed = data.speed;
        attackRange = data.attackRange;
        timeAttack = data.timeAttack;
    }

   
}
