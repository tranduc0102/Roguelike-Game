using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    private Transform enemy;

    public float Speed
    {
        get => speed;
        set => speed=value;
    }
    public Transform Enemy
    {
        get => enemy;
        set => enemy = value;
    }

    private void Update()
    {
        AttackEnemy();
    }

    public void AttackEnemy()
    {
        if (enemy != null)
        {
            Vector3 toward = (enemy.position - transform.position).normalized;
            transform.position += toward * Time.deltaTime * speed;   
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PoolingManager.Despawn(this.gameObject);
        Debug.Log("OK");
    }
}