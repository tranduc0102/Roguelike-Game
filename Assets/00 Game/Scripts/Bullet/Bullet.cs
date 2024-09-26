using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    public Vector3 enemy;
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
    public Vector3 Enemy
    {
        get => enemy;
        set => enemy = value;
    }
    
    public void Init(Vector3 _enemy, float _speed, string _nameTag)
    {
        if(rb==  null)rb = GetComponent<Rigidbody2D>();
        enemy = _enemy;
        speed = _speed;
        nameTag = _nameTag;
        AttackEnemy();
    }
    private void AttackEnemy()
    { 
        toward = (enemy- transform.position).normalized;
        rb.velocity=(toward * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(nameTag))
        {
            PoolingManager.Despawn(this.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            PoolingManager.Despawn(this.gameObject);
        }
    }
}