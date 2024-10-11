using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadCtrl()
    {
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }

    protected override void LoadData()
    {
        maxHp = playerCtrl.MaxHp;
        EventDispatcher.Instance.PostEvent(EventID.OnUpdateMaxHealth,maxHp);
        EventDispatcher.Instance.PostEvent(EventID.OnUpdateCurrentHealth,curHp);
    }

    public override void Deduct(float damage)
    {
        base.Deduct(damage);
        EventDispatcher.Instance.PostEvent(EventID.OnUpdateCurrentHealth,curHp);
    }

    protected override void OnDead()
    {
        //Debug.Log("Game Over");
    }

    
}
