using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [Header("Setting")] 
    [SerializeField] protected Transform settingTrf;
    [SerializeField] protected Button settingBtn;
    
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
                    if (currentLayout != null)
                    {
                        currentLayout.gameObject.SetActive(false);
                        TimeScaleManager.Instance.ResetToInitialSpeed();
                        currentLayout = null;
                    }
                    break;
                case CenterLayoutType.UpgradePlayerStatus:
                    LoadDataForOption();
                    ChangeCurrentLayout(chooseTrf);
                    break;
                case CenterLayoutType.Setting:
                    ChangeCurrentLayout(settingTrf);
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

        LoadSettingTrf();
        LoadSettingBtn();
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

    protected virtual void LoadSettingTrf()
    {
        if(settingTrf != null) return;
        settingTrf = GameObject.Find("Canvas").transform.GetChild(1).Find("Setting").transform;
    }

    protected virtual void LoadSettingBtn()
    {
        if (settingBtn != null) return;
        settingBtn = GameObject.Find("Canvas").transform.Find("Top").Find("Setting Button").GetComponent<Button>();
    }
    protected void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnFinishWay, param =>
        {
            CenterLayoutStatus = CenterLayoutType.UpgradePlayerStatus;
        });
        settingBtn.onClick.AddListener(() =>
        {
            CenterLayoutStatus = CenterLayoutType.Setting;
        });
    }

    protected virtual void ChangeCurrentLayout(Transform newLayout)
    {
        // only 1 current layout allow to exist
        if (currentLayout != null) return;
       
        currentLayout = newLayout;
        TimeScaleManager.Instance.StopGame();
        currentLayout.gameObject.SetActive(true);
        
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
