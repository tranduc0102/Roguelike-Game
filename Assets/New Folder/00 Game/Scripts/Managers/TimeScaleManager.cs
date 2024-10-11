using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : Singleton<TimeScaleManager>
{
    [SerializeField] protected float curTimeScale;
    public virtual void SetNewSpeedGame(float newSpeed)
    {
        curTimeScale = Time.timeScale;
        Time.timeScale = newSpeed;
    }

    public virtual void ResetToInitialSpeed()
    {
        Time.timeScale = curTimeScale;
    }

    public virtual void StopGame()
    {
        SetNewSpeedGame(0);
    }
    
}
