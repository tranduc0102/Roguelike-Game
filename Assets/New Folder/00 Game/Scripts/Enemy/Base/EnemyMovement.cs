using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ComponentBehavior
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform player;

   
    protected override void LoadComponent()
    {
        LoadCtrl();
        LoadPlayer();
        LoadSpeed();
    }

    protected virtual void LoadCtrl()
    {
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadPlayer()
    {
        player = enemyCtrl.Player;
    }
    protected virtual void LoadSpeed()
    {
        speed = enemyCtrl.Speed;
    }

    public void Movement()
    {
        
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.parent.Translate(direction * Time.deltaTime * speed);
    }
}
