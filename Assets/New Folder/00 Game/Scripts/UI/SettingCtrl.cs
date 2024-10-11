using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCtrl : ComponentBehavior
{
    [SerializeField] protected Button continueBtn;
    [SerializeField] protected Button menuBtn;
    [SerializeField] protected Button restartBtn;
    [SerializeField] protected Button settingBtn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadContinueBtn();
        LoadMenuBtn();
        LoadRestartBtn();
        LoadSettingBtn();
    }

    protected virtual void LoadContinueBtn()
    {
        if (continueBtn != null) return;
        continueBtn = transform.Find("Right").Find("Continue").GetComponent<Button>();
    }
    protected virtual void LoadMenuBtn()
    {
        if (menuBtn != null) return;
        menuBtn = transform.Find("Right").Find("Menu").GetComponent<Button>();
    }
    protected virtual void LoadRestartBtn()
    {
        if (restartBtn != null) return;
        restartBtn = transform.Find("Right").Find("Restart").GetComponent<Button>();
    }
    protected virtual void LoadSettingBtn()
    {
        if (settingBtn != null) return;
        settingBtn = transform.Find("Right").Find("Setting").GetComponent<Button>();
    }

    private void OnEnable()
    {
        continueBtn.onClick.AddListener(() =>
        {
            CenterLayoutManager.Instance.CenterLayoutStatus = CenterLayoutManager.CenterLayoutType.None;

        });
    }
    
}
