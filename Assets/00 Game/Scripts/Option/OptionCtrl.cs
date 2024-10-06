using System;
using UnityEngine;


public class OptionCtrl : OptionBase
{
    
   
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected StatsType statsType;
    [SerializeField] protected float valueAdded;
    
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();    
    }

    protected virtual void LoadPlayer()
    {
        if (playerCtrl != null) return;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
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
