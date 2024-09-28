using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemyCtrl : EnemyCtrl
{
    [SerializeField] protected MeleeEnemySendDamage meleeEnemySendDamage;

    public MeleeEnemySendDamage MeleeEnemySendDamage => meleeEnemySendDamage;
    protected override void LoadScripts()
    {
        base.LoadScripts();
        LoadMeleeSendDamage();
    }

    protected virtual void LoadMeleeSendDamage()
    {
        if (meleeEnemySendDamage != null) return;
        meleeEnemySendDamage = transform.GetComponentInChildren<MeleeEnemySendDamage>();
    }

    protected virtual void Attack()
    {
        
        if (player != null && meleeEnemySendDamage!=null)
        {
            meleeEnemySendDamage.SendDamage(player);   
        }
    }
}
