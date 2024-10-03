using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : ComponentBehavior
{
    [SerializeField] protected Transform chooseTrf;
    [SerializeField] protected float curTimeScale;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChooseTrf();
    }

    protected virtual void LoadChooseTrf()
    {
        if (chooseTrf!= null) return;
        chooseTrf = GameObject.Find("Canvas").transform.GetChild(1).Find("OptionChosen").transform;
    }

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
        chooseTrf.gameObject.SetActive(true);
    }
}
