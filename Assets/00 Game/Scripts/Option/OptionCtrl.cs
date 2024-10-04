using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionCtrl : ComponentBehavior
{
    
   
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI optionName;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected Button chooseBtn;

    [SerializeField] protected StatsType statsType;
    [SerializeField] protected float valueAdded;
    
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();
        LoadImage();
        LoadOptionName();
        LoadDescription();
        LoadChooseBtn();
       
    }

    protected virtual void LoadPlayer()
    {
        if (playerCtrl != null) return;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.Find("ImgAndName").Find("Image").GetComponent<Image>();
    }

    protected virtual void LoadOptionName()
    {
        if(optionName != null) return;
        optionName = transform.Find("ImgAndName").Find("Name").GetComponent<TextMeshProUGUI>();
    }

    protected virtual void LoadDescription()
    {
        if (description != null) return;
        description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    protected virtual void LoadChooseBtn()
    {
        if (chooseBtn != null) return;
        chooseBtn = transform.Find("Button").GetComponent<Button>();
    }

   
    public void Init(Sprite _image, string _optionName, string _description, StatsType _statsType, float _value)
    {
        if (_image != null) image.sprite = _image;
        if (_optionName != String.Empty) optionName.text = _optionName;
        else optionName.text = "";
        if (_description != String.Empty) description.text = _description;
        else description.text = "";
        statsType = _statsType;
        valueAdded = _value;
    }

    private void OnEnable()
    {
        chooseBtn.onClick.AddListener(UpgradePlayerStatus);
    }

    protected virtual bool CanCalculatePercentage()
    {
        return description.text.Contains("%");
    }
    protected virtual float GetNewValue(float oldValue)
    {
        float newVal = oldValue;
        if (!CanCalculatePercentage()) newVal += valueAdded;
        else newVal = (1 + valueAdded) * oldValue;
        return newVal;

    }
    protected virtual void UpgradePlayerStatus()
    {
        
        switch (statsType)
        {
            case StatsType.Damage:
                playerCtrl.Damage = GetNewValue(playerCtrl.Damage);
                break;
            case StatsType.MaxHp:
                playerCtrl.MaxHp = GetNewValue(playerCtrl.MaxHp);
                break;
            case StatsType.Speed:
                playerCtrl.Speed = GetNewValue(playerCtrl.Speed);
                break;
        }

        HireChooseOption();
        TimeScaleManager.Instance.ResetToInitialSpeed();
        
    }

    protected virtual void HireChooseOption()
    {
       
        CenterLayoutManager.Instance.CenterLayoutStatus = CenterLayoutManager.CenterLayoutType.None;
    }
}
