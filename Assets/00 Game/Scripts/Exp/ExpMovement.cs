using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMovement : ComponentBehavior
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float disLimit;
    [SerializeField] protected float speed;
    protected enum ExpState
    {
        Idle,
        Move,
        Gained
    }

    [SerializeField] protected ExpState expState;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();
        
        SetData();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.Find("Player").transform;
    }

    protected virtual void SetData()
    {
        disLimit = 2f;
        speed = 10f;
        expState = ExpState.Idle;
    }

   

    protected virtual void SetState()
    {
        float dis = Vector3.Distance(transform.position, player.position);
        if (dis > disLimit) expState = ExpState.Idle;
        else if (dis <= disLimit && dis > 0.1f) expState = ExpState.Move;
        else expState = ExpState.Gained;
    }

    protected virtual void MoveToPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    protected virtual void PlayerGainExp()
    {
        EventDispatcher.Instance.PostEvent(EventID.OnExp,1f);
        PoolingManager.Despawn(transform.gameObject);
    }

    protected virtual void Update()
    {
        SetState();
        if(expState == ExpState.Move) MoveToPlayer();
        else if(expState == ExpState.Gained) PlayerGainExp();
    }
}
