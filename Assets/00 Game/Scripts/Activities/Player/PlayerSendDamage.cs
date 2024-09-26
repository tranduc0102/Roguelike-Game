using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSendDamage : DamageSender
{
    public DataBase data;
    protected override void LoadData()
    {
        damage = data.listPlayerData[0].basicDamage;
    }
}
