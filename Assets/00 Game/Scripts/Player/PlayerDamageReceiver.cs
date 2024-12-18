using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected GameObject panel;
    protected override void Start()
    {
        base.Start();
        panel = GameObject.Find("Over");
    }

    protected override void Reset()
    {
        base.Reset();
        panel = GameObject.Find("Over");
    }

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
        TimeScaleManager.Instance.StopGame();
        panel.transform.GetChild(0).gameObject.SetActive(true);
    }

    
}
