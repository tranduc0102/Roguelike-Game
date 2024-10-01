using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndExpBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider sliderExp;
    [SerializeField] private TextMeshProUGUI txtHP;

    private void Awake()
    {
        sliderHealth = transform.GetChild(0).GetComponentInChildren<Slider>();
        sliderExp = transform.GetChild(1).GetComponentInChildren<Slider>();
        txtHP = sliderHealth.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateMaxHealth,param=>SetMaxHealth((float)param));
        //EventDispatcher.Instance.RegisterListener(EventID.OnUpdateMaxExp,param=>SetMaxExp((float)param));
        //EventDispatcher.Instance.RegisterListener(EventID.OnExp,param=>SetExp((float)param));
        EventDispatcher.Instance.RegisterListener(EventID.OnUpdateCurrentHealth,param=>SetHealth((float)param));
    }

    /*private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.OnUpdateCurrentHealth);
       // EventDispatcher.Instance.RemoveListener(EventID.OnUpdateMaxExp);
        EventDispatcher.Instance.RemoveListener(EventID.OnUpdateMaxHealth);
        //EventDispatcher.Instance.RemoveListener(EventID.OnExp);
    }*/

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

    protected void SetMaxExp(float amount)
    {
        sliderExp.maxValue = amount;
        sliderExp.value = 0;
    }

    protected void SetExp(float amount)
    {
        sliderExp.value = amount;
    }
}
