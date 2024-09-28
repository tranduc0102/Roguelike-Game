using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : ComponentBehavior
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
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
        
        Debug.Log("Enemy drop exp");
    }
    
}
