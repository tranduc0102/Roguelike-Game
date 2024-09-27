using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    [SerializeField] protected MeleeEnemySendDamage meleeEnemySendDamage;
    public int enemyIndex;
   

   
    protected internal override void LoadData(EnemyData data)
    {
        speed = data.speed;
        attackRange = data.attackRange;
        timeAttack = data.timeAttack;
       
    }

    protected virtual void LoadSendDamage()
    {
        if (meleeEnemySendDamage != null) return;
        meleeEnemySendDamage = transform.GetComponent<MeleeEnemySendDamage>();
        Debug.Log(transform.name + " Load DamageSender successful");
    }
    protected override void Attack()
    {
        base.Attack();
        
        meleeEnemySendDamage.SendDamage(player);
    }
}
