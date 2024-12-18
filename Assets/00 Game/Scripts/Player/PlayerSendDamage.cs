using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSendDamage : DamageSender
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadCtrl()
    {
        if (playerCtrl == null)
        {
            playerCtrl = transform.GetComponent<PlayerCtrl>();   
        }
    }

    protected override void LoadData()
    {
    }
}
