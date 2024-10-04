using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CenterLayoutManager : Singleton<CenterLayoutManager> 
{
    /// <summary>
    /// Use for manage center layout
    /// </summary>
    [Header("Option Layout")]
    [SerializeField] protected List<OptionStatsParam> data;
    [SerializeField] protected Transform chooseTrf;
    [SerializeField] protected List<OptionCtrl> listOption;

    [SerializeField] protected Transform currentLayout;
    public enum CenterLayoutType
    {
        None,
        UpgradePlayerStatus,
        Setting
    }

    [SerializeField] protected CenterLayoutType centerLayoutStatus;

    public CenterLayoutType CenterLayoutStatus
    {
        get => centerLayoutStatus;
        set
        {
            centerLayoutStatus = value;
            switch (centerLayoutStatus)
            {
                case CenterLayoutType.None:
                    if(currentLayout != null) currentLayout.gameObject.SetActive(false);
                    break;
                case CenterLayoutType.UpgradePlayerStatus:
                    currentLayout = chooseTrf;
                    DisplayOptions();
                    break;
            }
        }
    }

    protected virtual void Start()
    {
        LoadComponent();
    }

    protected void Reset()
    {
        LoadComponent();
    }

    protected virtual void LoadComponent()
    {
       
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
        EventDispatcher.Instance.RegisterListener(EventID.OnFinishWay, param =>
        {
            CenterLayoutStatus = CenterLayoutType.UpgradePlayerStatus;
        });
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
