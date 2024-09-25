using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Movemonet")] 
    [SerializeField] protected Transform hitdetection;
    [SerializeField] protected float radiusHit = 0.3f;
    [SerializeField]protected State state;
    
    [Header("Setting")] 
    [SerializeField] protected float attackRange = 2.5f;
    [SerializeField] protected LayerMask layerEnemy;
    
    [Header("Attack")] 
    [SerializeField] protected float damage;
    [SerializeField] protected float aimLeft = 12f;
    [SerializeField] protected float attackDelay=0.1f;
    [SerializeField] protected float speedAttack = 2f;
    protected List<BaseEnemy> enemyDamaged;
    protected float timeDelay;
    private Animator animator;

    private void OnEnable()
    {
        Load();
    }

    protected virtual void Load()
    {
        animator = GetComponent<Animator>();
        enemyDamaged = new List<BaseEnemy>();
        layerEnemy = LayerMask.GetMask("Enemy");
        hitdetection = GetComponent<Transform>().GetChild(0).GetChild(1);
    }


    protected virtual void Update()
    {
        switch (state)
        {
            case State.Idle:
                AutoAim();
                break;
            case State.Attack:
                Attacking();
                break;
            default:
                Debug.Log("Empty state");
                break;
        }
    }

    protected virtual void AutoAim()
    {
        BaseEnemy closeEnemy = GetEnemy();
        Vector2 targetPoint = Vector2.up;
        if (closeEnemy != null)
        {
            targetPoint = (closeEnemy.transform.position - transform.position).normalized;
            CheckDelayAttack(); 
        }
        else
        {
            StopAttack();
        }
        transform.up = Vector3.Lerp(transform.up, targetPoint, Time.deltaTime*aimLeft);
        UpdateTime();
    }
    protected virtual void CheckDelayAttack()
    {
        if (timeDelay > attackDelay)
        {
            StartAttack();
            timeDelay = 0;
        }
    }

    protected virtual void UpdateTime()
    {
        timeDelay += Time.deltaTime;
    }
    
    protected virtual void StartAttack()
    {
        animator.Play("Attack");
        state = State.Attack;
        animator.speed = speedAttack;
        enemyDamaged.Clear();
    }
    protected virtual void Attacking()
    {
        Attack();
    }
    protected virtual void StopAttack()
    {
        state = State.Idle;
        enemyDamaged.Clear();
    }

    protected virtual void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitdetection.position, radiusHit, layerEnemy);
        foreach (var enemy in enemies)
        {
            if (!enemyDamaged.Contains(enemy.GetComponent<BaseEnemy>()))
            {
                Debug.Log("Enemy be attacked");
                // Xử lí quái được nhận dâmge
                enemyDamaged.Add(enemy.GetComponent<BaseEnemy>());
            }
        }

        if (enemies.Length < 1)
        {
            StopAttack();
        }
    }

    protected virtual BaseEnemy GetEnemy()
    {
        BaseEnemy enemy = null;
        float minRange = attackRange;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, layerEnemy);
        if (enemies.Length <= 0)
            return null;
        
        foreach (var enm in enemies)
        {
            BaseEnemy enemyChecked = enm.GetComponent<BaseEnemy>();
            if (enemyChecked != null)
            {
                float distance = Vector2.Distance(transform.position , enemyChecked.transform.position);
                if (distance < minRange)
                {
                    minRange = distance; //cái này dùng để kiểm tra xem vị trí quái có bị gần với vị trí weapon kh
                    enemy = enemyChecked;
                }
            }
        }

        return enemy;
    }

    protected enum  State
    { 
        Idle,
        Attack
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,attackRange);
        
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(hitdetection.position,radiusHit);
    }
}
