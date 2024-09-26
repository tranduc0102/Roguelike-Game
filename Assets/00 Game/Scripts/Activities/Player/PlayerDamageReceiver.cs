using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    
    protected override void LoadData()
    {
        maxHp = data.listPlayerData[0].basicHp;
    }

    protected override void OnDead()
    {
        Debug.Log("Game Over");
    }
}
