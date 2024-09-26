using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamageSender : DamageSender
{
    public int playerIndex = 0;
    protected override void LoadData()
    {
        damage = data.listPlayerData[playerIndex].basicDamage;
    }
}
