using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float timeAttack;
    [SerializeField] protected float timer;
    [SerializeField] protected enum EnemyState
    {
        Movement,
        Attack
    }

    [SerializeField] protected EnemyState enemyState;
    protected void OnEnable()
    {
        LoadData();
        LoadPlayer();
        timer = 0f;
        enemyState = EnemyState.Movement;
    }

    protected abstract void LoadData();
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.Find("Player").transform;
        if(player != null)
            Debug.Log(transform.name + " Load Player successful");
    }

    protected virtual void ChangeState()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(dis);
        if (dis <= attackRange) enemyState = EnemyState.Attack;
        else enemyState = EnemyState.Movement;
    }
    protected virtual void Movement()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * speed);
    }

    protected virtual void Attack()
    {
        
    }

    protected virtual void UpdateLogicAttack()
    {
        timer += Time.deltaTime;
        if (timer > timeAttack)
        {
            Attack();
            timer = 0;
        }
    }
    protected virtual void Update()
    {
        ChangeState();
        if(enemyState == EnemyState.Movement) Movement();
        else UpdateLogicAttack();
    }
    
}
