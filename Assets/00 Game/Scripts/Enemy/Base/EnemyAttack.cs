using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ComponentBehavior
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float timeAttack;
    [SerializeField] protected float coolDown;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCtrl();
        LoadData();
    }

    protected virtual void LoadCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadData()
    {
        timeAttack = enemyCtrl.TimeAttack;
        coolDown = 0;
    }
    protected virtual void Attacking()
    {
        
    }

    public virtual void OnAttack()
    {
        coolDown += Time.deltaTime;
        if (coolDown > timeAttack)
        {
            Attacking();
            coolDown = 0;

        }
    }
}
