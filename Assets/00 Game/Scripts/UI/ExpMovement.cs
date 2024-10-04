using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMovement : ComponentBehavior
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Transform expBar;
    [SerializeField] protected float disLimit;
    [SerializeField] protected float speed;
    protected enum ExpState
    {
        Idle,
        Move,
        GainedByPlayer,
        GainedByExpBar
    }

    [SerializeField] protected ExpState expState;

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnFinishWay, param =>
        {
            expState = ExpState.GainedByExpBar;
        });
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();
        LoadExpBar();
        SetData();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.Find("Player").transform;
    }

    protected virtual void LoadExpBar()
    {
        if (expBar != null) return;
        expBar = GameObject.Find("Canvas").transform.Find("Top").Find("PanelEXP");
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
        else expState = ExpState.GainedByPlayer;
    }

    protected virtual void MoveToObject(Vector3 endPoint, float moveSpeed)
    {
        Vector3 direction = (endPoint - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    

    protected virtual void PlayerGainExp()
    {
        EventDispatcher.Instance.PostEvent(EventID.OnGainExp,1f);
        PoolingManager.Despawn(transform.gameObject);
    }

    protected virtual void Update()
    {
        SetState();
        if(expState == ExpState.Move) MoveToObject(player.position,speed);
        else if(expState == ExpState.GainedByPlayer) PlayerGainExp();
        else if(expState == ExpState.GainedByExpBar) MoveToObject(expBar.position,10 * speed);
    }
}
