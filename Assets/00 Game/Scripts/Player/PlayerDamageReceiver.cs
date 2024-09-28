using System.Collections;
using System.Collections.Generic;
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
    }

    protected override void OnDead()
    {
        //Debug.Log("Game Over");
    }
}
