using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndExpBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider sliderExp;
    [SerializeField] private TextMeshProUGUI txtHP;
    //[SerializeField] private TextMeshProUGUI txtExp;
    [SerializeField] private float maxExp;
    [SerializeField] private float curExp;

    private void Awake()
    {
        sliderHealth = transform.GetChild(0).GetComponentInChildren<Slider>();
        sliderExp = transform.GetChild(1).GetComponentInChildren<Slider>();
        txtHP = sliderHealth.GetComponentInChildren<TextMeshProUGUI>();
        //txtExp = sliderExp.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        
        RegisterEvent();
        maxExp = 8f;
        sliderExp.value = 0;
        curExp = 0;
        SetMaxExp();
    }

    
    
    private void RegisterEvent()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateMaxHealth,param=>SetMaxHealth((float)param));
        
        EventDispatcher.Instance.RegisterListener(EventID.OnGainExp,param=>SetExp((float)param));
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateCurrentHealth,param=>SetHealth((float)param));
    }

   

    protected void SetMaxHealth(float maxHP)
    {
        sliderHealth.maxValue = maxHP;
        txtHP.text = sliderHealth.value + "/" + sliderHealth.maxValue;
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
        maxExp *= 2;
        sliderExp.maxValue = maxExp;
    }

    protected void SetExp(float amount)
    {
        sliderExp.value += amount;
        if (Math.Abs(sliderExp.value - maxExp) < 0.1f) UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        curExp++;
        //txtExp.text = "Level " + curExp;
        SetMaxExp();
    }
}
