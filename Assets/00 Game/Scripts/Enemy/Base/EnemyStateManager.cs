using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : ComponentBehavior
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected EnemyHide enemyHide;
    protected enum EnemyState
    {
        Hide,
        Movement,
        Attack
    }

    [SerializeField] protected EnemyState enemyState;

    protected override void LoadComponent()
    {
        LoadCtrl();
        enemyState = EnemyState.Hide;
    }

    protected virtual void LoadCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadEnemyHide()
    {
        if(enemyHide != null) return;
        enemyHide = transform.GetComponent<EnemyHide>();
    }
    protected virtual void ChangeState()
    {
        float dis = Vector3.Distance(transform.position, enemyCtrl.Player.transform.position);
        if (dis <= enemyCtrl.AttackRange) enemyState = EnemyState.Attack;
        else enemyState = EnemyState.Movement;
    }

    private void Update()
    {
        if(enemyHide.IsActive) ChangeState();
        if(enemyState == EnemyState.Movement) enemyCtrl.EnemyMovement.Movement();
        else if(enemyState == EnemyState.Hide) enemyHide.HideEnemy();
        else enemyCtrl.EnemyAttack.OnAttack();
    }
}
