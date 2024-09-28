using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : ComponentBehavior
{
    // dùng để quản lý các liên kết, các dữ liệu của enemy
    // khi có thay đổi hoặc lấy dữ liệu các scrip sẽ lấy thông tin từ scrip này
    public DataBase enemyData;

    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected EnemyAttack enemyAttack;
    
    [SerializeField] protected Transform player;
    public int enemyID;
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

    public EnemyMovement EnemyMovement => enemyMovement;

    public EnemyAttack EnemyAttack => enemyAttack;
    protected override void LoadComponent()
    {
        LoadData();
        LoadEnemyData();
        LoadPlayer();
        LoadScripts();
    }

    protected virtual void LoadData()
    {
        if (enemyData != null) return;
        enemyData = Resources.Load<DataBase>("DataBase");
    }
    protected virtual void LoadPlayer()
    {
        player = GameObject.Find("Player").transform;
    }
    protected virtual void LoadEnemyData()
    {
        maxHP = enemyData.listEnemyData[enemyID].maxHp;
        damage = enemyData.listEnemyData[enemyID].damage;
        speed = enemyData.listEnemyData[enemyID].speed;
        timeAttack = enemyData.listEnemyData[enemyID].timeAttack;
        attackRange = enemyData.listEnemyData[enemyID].attackRange;
    }

    protected virtual void LoadScripts()
    {
        LoadEnemyMovement();
        LoadEnemyAttack();
    }

    protected virtual void LoadEnemyMovement()
    {
        if(enemyMovement != null) return;
        enemyMovement = transform.GetComponentInChildren<EnemyMovement>();
    }
    protected virtual void LoadEnemyAttack()
    {
        if (enemyAttack != null) return;
        enemyAttack = transform.GetComponentInChildren<EnemyAttack>();
    }

}
