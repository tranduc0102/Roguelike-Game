using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : MonoBehaviour
{
    [SerializeField] protected float damage;
    public DataBase data;

    protected virtual void OnEnable()
    {
        LoadData();
    }

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
