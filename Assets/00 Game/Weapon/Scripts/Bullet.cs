using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    public Transform enemy;
    public Rigidbody2D rb;
    public Vector3 toward;
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
    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        toward = (enemy.position - transform.position).normalized;
       
    }

    private void Update()
    {
        AttackEnemy();
    }

    public void AttackEnemy()
    {
        if (enemy != null)
        {
           
           transform.Translate(toward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PoolingManager.Despawn(this.gameObject);
            Debug.Log("OK");   
        }
    }
}