using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    
    protected override void LoadData()
    {
        speed = 5f;
        attackRange = 2f;
    }

   
}
