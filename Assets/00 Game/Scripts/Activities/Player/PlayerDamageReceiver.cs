using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    public DataBase data;
    protected override void LoadData()
    {
        maxHp = data.listPlayerData[0].basicHp;
    }
}
