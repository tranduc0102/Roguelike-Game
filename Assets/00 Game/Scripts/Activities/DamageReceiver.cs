using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : ComponentBehavior
{
   
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;


    private void OnEnable()
    {
        LoadCtrl();
        LoadData();
        curHp = maxHp;
    }

    protected override void LoadComponent()
    {
        LoadCtrl();
        LoadData();
        curHp = maxHp;
    }

    protected abstract void LoadCtrl();
    protected abstract void LoadData();

    public virtual void Deduct(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            OnDead();
        }
    }

    protected virtual void OnDead()
    {
        PoolingManager.Despawn(transform.gameObject);
       
    }
}
