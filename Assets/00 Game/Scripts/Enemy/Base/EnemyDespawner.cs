using UnityEditor;
using UnityEngine;

public class EnemyDespawner : ComponentBehavior
{
    [SerializeField] protected GameObject expPrefab;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    

    protected override void LoadComponent()
    {
        LoadCtrl();
        LoadExp();
    }

    protected virtual void LoadCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadExp()
    {
        if (expPrefab != null) return;
        
        string resPath = "Exp";

        expPrefab = Resources.Load<GameObject>(resPath);
    }

    protected virtual bool CanDespawn()
    {
        return false;
    }

    protected virtual void OnDespawn()
    {
        // thực hiên các hành động trước khi xóa object
        // 
        if (!CanDespawn()) return;
        Despawning();
    }

    public virtual void Despawning()
    {
        PoolingManager.Despawn(transform.parent.gameObject);
        AfterDespawn();
    }

    protected virtual void AfterDespawn()
    {
        PoolingManager.Spawn(expPrefab, transform.parent.position,Quaternion.identity);
    }
    
}
