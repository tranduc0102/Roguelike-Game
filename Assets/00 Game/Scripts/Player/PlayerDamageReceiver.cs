using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadCtrl()
    {
        playerCtrl = transform.GetComponent<PlayerCtrl>();
    }

    protected override void LoadData()
    {
        maxHp = playerCtrl.data.listPlayerData[playerCtrl.playerIndex].basicHp;
    }

    protected override void OnDead()
    {
        Debug.Log("Game Over");
    }
}
