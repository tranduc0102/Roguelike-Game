using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndExpBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider sliderExp;
    [SerializeField] private TextMeshProUGUI txtHP;
    [SerializeField] private float maxExp;

    private void Awake()
    {
        sliderHealth = transform.GetChild(0).GetComponentInChildren<Slider>();
        sliderExp = transform.GetChild(1).GetComponentInChildren<Slider>();
        txtHP = sliderHealth.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        
        RegisterEvent();
        maxExp = 8f;
        sliderExp.value = 0;
        SetMaxExp();
    }

    
    
    private void RegisterEvent()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateMaxHealth,param=>SetMaxHealth((float)param));
        
        EventDispatcher.Instance.RegisterListener(EventID.OnGainExp,param=>SetExp((float)param));
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateCurrentHealth,param=>SetHealth((float)param));
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.OnUpdateCurrentHealth);
       
        EventDispatcher.Instance.RemoveListener(EventID.OnUpdateMaxHealth);
        EventDispatcher.Instance.RemoveListener(EventID.OnGainExp);
    }

    protected void SetMaxHealth(float maxHP)
    {
        sliderHealth.maxValue = maxHP;
    }

    protected void SetHealth(float amount)
    {
        sliderHealth.value = amount;
        if (amount > 0)
        {
            txtHP.text = amount + "/" + sliderHealth.maxValue;
        }
        else
        {
            txtHP.text = 0 + "/" + sliderHealth.maxValue;
        }
    }

    protected void SetMaxExp()
    {
        sliderExp.value %= maxExp;
        sliderExp.maxValue = maxExp;
    }

    protected void SetExp(float amount)
    {
        sliderExp.value += amount;
        if (Math.Abs(sliderExp.value - maxExp) < 0.1f) UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        maxExp *= 2;
        SetMaxExp();
        // Post sự kiện
        EventDispatcher.Instance.PostEvent(EventID.OnLevelUp);
    }
}
