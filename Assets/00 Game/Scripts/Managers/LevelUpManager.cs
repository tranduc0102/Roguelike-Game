using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : ComponentBehavior
{
    [SerializeField] protected float curTimeScale;
    protected void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnLevelUp,param=>DisplayOptions());
    }

    protected virtual void SetNewSpeedGame(float newSpeed)
    {
        curTimeScale = Time.timeScale;
        Time.timeScale = newSpeed;
    }

    protected virtual void ResetToInitialSpeed()
    {
        Time.timeScale = curTimeScale;
    }
    protected virtual void DisplayOptions()
    {
        SetNewSpeedGame(0);
        Debug.Log("Display Option");
    }
}
