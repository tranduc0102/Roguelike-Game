using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    public Transform enemy;
    public Rigidbody2D rb;
    public Vector3 toward;
    protected string nameTag;

    public string NameTag
    {
        get => nameTag;
        set => nameTag = value;
    }
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

    public void Init(Transform _enemy, float _speed, string _nameTag)
    {
        enemy = _enemy;
        speed = _speed;
        nameTag = _nameTag;
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
        if (other.CompareTag(nameTag))
        {
            PoolingManager.Despawn(this.gameObject);
            Debug.Log("OK");   
        }
    }
}