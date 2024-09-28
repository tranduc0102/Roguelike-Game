using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamgeSender : DamageSender
{
    
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    protected override void LoadCtrl()
    {
        
    }

    protected override void LoadData()
    {
        
    }
}
