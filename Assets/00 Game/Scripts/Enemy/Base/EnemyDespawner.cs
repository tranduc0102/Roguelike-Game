using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    
    protected virtual void LoadData()
    {
        
    }
    protected virtual bool CanDespawn()
    {
        return false;
    }
    
}
