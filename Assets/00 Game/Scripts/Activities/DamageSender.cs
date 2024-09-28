using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : ComponentBehavior
{
    [SerializeField] protected float damage;


    protected override void LoadComponent()
    {
        LoadCtrl();
        LoadData();
    }

   

    protected abstract void LoadCtrl();
    protected abstract void LoadData();

    public virtual void SendDamage(Transform enemy)
    {
        DamageReceiver damageReceiver = enemy.GetComponent<DamageReceiver>();
        SendDamage(damageReceiver);
    }

    public virtual void SendDamage(DamageReceiver damageReceiver)
    {
        if (damageReceiver == null) return;
        damageReceiver.Deduct(damage);
    }
}
