using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionWeapon : OptionBase
{
    private Transform weapons;
    private int idWeapon;

    public void Init(Transform weapon,int id)
    {
        description.text = weapon.name;
        this.weapons = weapon;
        idWeapon = id;
    }
    private void OnEnable()
    {
        chooseBtn.onClick.AddListener(Choice);
    }

    protected virtual void Choice()
    {
        SelectWeapon();
        HideWeaponSelectionPanel();
    }

    private void SelectWeapon()
    {
        GameManager.Instance.IDWeapon = idWeapon;
        SceneManager.LoadScene("InGame");
    }

    protected virtual void HideWeaponSelectionPanel()
    {
        GameManager.Instance.HideWeaponSelectionPanel();
    }
}
