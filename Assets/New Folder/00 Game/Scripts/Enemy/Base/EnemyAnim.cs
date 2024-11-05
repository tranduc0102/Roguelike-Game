using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EnemyAnim : ComponentBehavior
{
    [SerializeField] protected Vector3 prePosition;
    [SerializeField] protected Vector3 curPosition;
    [SerializeField] protected float timer;
    protected override void Start()
    {
        base.Start();
        prePosition = transform.parent.parent.position;
        timer = 0;
    }

    protected void RotateAnim()
    {
        curPosition = transform.parent.parent.position;
        if (curPosition.x == prePosition.x) return;
        float angle = 0;
        if (curPosition.x < prePosition.x) angle = 180;
        transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));
        prePosition = curPosition;
    }

    protected void UpdateTime()
    {
        timer += Time.deltaTime;
        if (timer > 2) timer -= 2;
    }
    protected void ChangePos()
    {
        float factor = 0.2f * timer * (timer - 2f);
        var position = transform.position;
        position = new Vector3(position.x, factor, position.z);
        transform.position = position;
    }

    protected void ChangeScale()
    {
        float factor = 0.2f * timer * timer - 0.4f * timer + 1;
        transform.localScale = new Vector3(transform.localScale.x, factor, transform.localScale.z);
    }
    protected void MoveState()
    {
        ChangePos();
        ChangeScale();
    }
    private void Update()
    {
         RotateAnim();
        UpdateTime();
        //MoveState();
    }
}
