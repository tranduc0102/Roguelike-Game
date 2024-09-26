using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    public DataBase data;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;

    protected virtual void OnEnable()
    {
        LoadData();
        curHp = maxHp;
    }

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
        PoolingManager.Despawn(transform.parent.gameObject);
    }
}
