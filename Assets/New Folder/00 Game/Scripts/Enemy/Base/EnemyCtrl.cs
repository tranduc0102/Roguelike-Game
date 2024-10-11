using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    // dùng để quản lý các liên kết, các dữ liệu của enemy
    // khi có thay đổi hoặc lấy dữ liệu các scrip sẽ lấy thông tin từ scrip này
    
    //Scripts
    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected EnemyAttack enemyAttack;
    [SerializeField] protected EnemyDespawner enemyDespawner;
    
    //Transforms
    [SerializeField] protected Transform player;
    
    //Specifications
    [SerializeField] protected int enemyID;
    [SerializeField] protected float maxHP;
    
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float timeAttack;
    [SerializeField] protected float attackRange;

    public Transform Player
    {
        get => player;
        set => player = value;
    }
    public float MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }

    public float TimeAttack
    {
        get => timeAttack;
    }

    public EnemyMovement EnemyMovement => enemyMovement;

    public EnemyAttack EnemyAttack => enemyAttack;

    public EnemyDespawner EnemyDespawner => enemyDespawner;
    protected virtual void OnEnable()
    {
        LoadComponent();
    }
    protected virtual void LoadComponent()
    {
       
        LoadPlayer();
        LoadScripts();
    }
    
    protected virtual void LoadPlayer()
    {
        player = GameObject.Find("Player").transform.GetComponentInChildren<PlayerDamageReceiver>().transform;
    }
    public virtual void LoadData(EnemyData enemyData)
    {
        maxHP = enemyData.maxHp;
        damage = enemyData.damage;
        speed = enemyData.speed;
        timeAttack = enemyData.timeAttack;
        attackRange = enemyData.attackRange;
        enemyID = enemyData.enemyID;
    }

    protected virtual void LoadScripts()
    {
        LoadEnemyMovement();
        LoadEnemyAttack();
        LoadEnemyDespawner();
    }

    protected virtual void LoadEnemyMovement()
    {
        if (enemyMovement == null)
        {
            enemyMovement = transform.GetComponentInChildren<EnemyMovement>();   
        }
    }
    protected virtual void LoadEnemyAttack()
    {
        if (enemyAttack == null)
        {
            enemyAttack = transform.GetComponentInChildren<EnemyAttack>();   
        }
    }

    protected virtual void LoadEnemyDespawner()
    {
        if (enemyDespawner == null)
        {
            enemyDespawner = transform.GetComponentInChildren<EnemyDespawner>();   
        }
    }

}
