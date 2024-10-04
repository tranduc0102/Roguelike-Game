using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class OptionManager : ComponentBehavior
{
    [SerializeField] protected List<OptionStatsParam> data;
    [SerializeField] protected Transform chooseTrf;
    [SerializeField] protected List<OptionCtrl> listOption;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChooseTrf();
        LoadData();
        LoadListOption();
    }

    protected virtual void LoadChooseTrf()
    {
        if (chooseTrf!= null) return;
        chooseTrf = GameObject.Find("Canvas").transform.GetChild(1).Find("OptionChosen").transform;
    }

    protected virtual void LoadData()
    {
        if (data.Count != 0) return;
        string resPath = "OptionStatsData";
        data = Resources.Load<OptionStatsData>(resPath).ListOptionStats;
    }

    protected virtual void LoadListOption()
    {
        if (listOption.Count != 0) return;
        Transform options = chooseTrf.Find("Content").Find("ChosenBox").Find("Options");
        foreach (Transform option in options)
        {
            listOption.Add(option.GetComponent<OptionCtrl>());
        }
        
    }
    protected void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnLevelUp,param=>DisplayOptions());
    }

   
    protected virtual void DisplayOptions()
    {
        TimeScaleManager.Instance.StopGame();
        LoadDataForOption();
        chooseTrf.gameObject.SetActive(true);
    }

    protected virtual void LoadDataForOption()
    {
        if (listOption.Count == 0)
        {
            Debug.LogWarning("OptionCtrls are not loaded by Option Manager");
            return;
        }
        foreach (OptionCtrl optionCtrl in listOption)
        {
            int id = Random.Range(0, listOption.Count);
            optionCtrl.Init(data[id].image,data[id].name,data[id].description,data[id].statsType, data[id].value);
        }
    }
}
