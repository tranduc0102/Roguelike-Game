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
    [SerializeField] protected float damagePlayer;
    
    [Header("Attack")] 
    [SerializeField] protected float damage;
    [SerializeField] protected float aimLeft = 12f;
    [SerializeField] protected float attackDelay=0.1f;
    [SerializeField] protected float speedAttack = 2f;
    protected List<EnemyCtrl> enemyDamaged;
    protected float timeDelay;
    private Animator animator;


    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    protected virtual void Start()
    {
        Load();
    }

    protected virtual void Load()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();   
        }
        enemyDamaged = new List<EnemyCtrl>();
        layerEnemy = LayerMask.GetMask("Enemy");
        if (transform.GetChild(0)!= null)
        {
            hitdetection = transform.GetChild(0).GetChild(1);
        }
        damagePlayer = transform.parent.GetComponent<PlayerCtrl>().Damage;
        damage = damagePlayer;
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
        EnemyCtrl closeEnemy = GetClosestEnemy();
        Vector2 targetPoint = Vector2.up;
        if (closeEnemy != null)
        {
            targetPoint = (closeEnemy.transform.position - transform.position).normalized;
            CheckDelayAttack(); 
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
        AttackEnemy();
    }
    protected virtual void StopAttack()
    {
        state = State.Idle;
        enemyDamaged.Clear();
    }

    protected virtual void AttackEnemy()
    {
    }

    protected virtual EnemyCtrl GetClosestEnemy()
    {
        EnemyCtrl enemy = null;
        float minRange = attackRange;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, layerEnemy);
        if (enemies.Length <= 0)
            return null;
        
        foreach (var enm in enemies)
        {
            EnemyCtrl enemyChecked = enm.GetComponent<EnemyCtrl>();
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
        if (hitdetection != null)
        {
            Gizmos.DrawWireSphere(hitdetection.position, radiusHit);
        }
    }
}
