using DG.Tweening;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float timeAttack;
    [SerializeField] protected float timer;
    [SerializeField] private float timeHide;
    [SerializeField] private GameObject objHide;
    [SerializeField] private GameObject objActive;
    [SerializeField] private Collider2D _collider2D;
    protected enum EnemyState
    {
        Hide,
        Movement,
        Attack
    }

    [SerializeField] protected EnemyState enemyState;
    protected virtual void OnEnable()
    {
       
        LoadPlayer();
        timer = 0f;
        HideEnemy();
    }

    protected internal abstract void LoadData(EnemyData data);
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.Find("Player").transform;
       
    }

    protected virtual void ChangeState()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= attackRange) enemyState = EnemyState.Attack;
        else enemyState = EnemyState.Movement;
    }
    protected virtual void Movement()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * (Time.deltaTime * speed));
    }

    protected virtual void Attack()
    {}

    protected virtual void UpdateLogicAttack()
    {
        timer += Time.deltaTime;
        if (timer > timeAttack)
        {
            Attack();
            timer = 0;
        }
    }

    private void HideEnemy() // Hàm này để ẩn quái thông báo cho người chơi vị trí quái sẽ Spawn
    {
        enemyState = EnemyState.Hide;
        _collider2D = GetComponent<Collider2D>();
        objActive = transform.GetChild(1).gameObject;
        objHide = transform.GetChild(0).gameObject;
        objHide.SetActive(true);
        objActive.SetActive(false);
        _collider2D.enabled = false;
        var originalScale = objHide.transform.localScale;
        var toScale = originalScale*1.5f;
        OnScale(objHide.transform,originalScale,toScale);
    }
    private void OnScale(Transform obj,Vector3 originalScale,Vector3 toScale)
    {
        // Hàm này dùng để chỉnh scale của gameObject Hide
        obj.DOScale(toScale, 0.5f)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => {
                obj.DOScale(originalScale, 0.25f)
                    .SetEase(Ease.OutBounce)
                    .SetDelay(0.1f)
                    .OnComplete(()=> OnScale(obj, originalScale, toScale)); 
            })
            .SetLoops(5)
            .OnComplete(()=>OnActive());
    }
    
    private void OnActive() // Quái Xuất hiện
    {
        objActive.SetActive(true);
        objHide.SetActive(false);
        _collider2D.enabled = true;
        enemyState = EnemyState.Movement;
    }
    protected virtual void Update()
    {
        if (enemyState != EnemyState.Hide)
        {
            ChangeState();
            if(enemyState == EnemyState.Movement) Movement();
            else UpdateLogicAttack();   
        }
    }
    
}
