using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    protected int iD;
    protected float maxHp;
    protected float damage;
    protected float speed;
    protected PlayerMovement playerMovement;
    protected PlayerAnimation playerAnimation;
    protected RuntimeAnimatorController runtimeAnimatorController;
    protected PlayerDamageReceiver playerDamageReceiver;
    protected List<Weapon> listWeapon;
    public float MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = value;
            EventDispatcher.Instance.PostEvent(EventID.OnUpdateMaxHealth,maxHp);
            playerDamageReceiver.MaxHp = maxHp;
        }
    }

    public float Damage
    {
        get => damage;
        set
        {
            damage = value;
        }
    }

    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            playerMovement.Speed = value;
        }
    }

    public PlayerMovement PlayerMovement => playerMovement;
    public PlayerAnimation PlayerAnimation => playerAnimation;

    public RuntimeAnimatorController AnimationCurveRuntimeAnimatorController
    {
        get => runtimeAnimatorController;
        set => runtimeAnimatorController = value;
    }

    private void OnEnable()
    {
        LoadScripts();
    }
    private void Start()
    {
        LoadData(GameManager.Instance.Player);
    }
    protected virtual void LoadScripts()
    {
        LoadPlayerMovement();
        LoadPlayerAnimator();
        LoadPlayerDamageReceiver();
        /*LoadListWeapon();*/
    }

    protected virtual void LoadPlayerMovement()
    {
        playerMovement = transform.GetComponentInChildren<PlayerMovement>();
    }

    protected virtual void LoadPlayerAnimator()
    {
        playerAnimation = transform.GetComponentInChildren<PlayerAnimation>();
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        playerDamageReceiver = transform.GetComponentInChildren<PlayerDamageReceiver>();
    }

 /*   protected virtual void LoadListWeapon()
    {
        foreach (Transform weapon in transform)
        {
            Weapon wp = weapon.GetComponent<Weapon>();
            if (wp != null) listWeapon.Add(wp);
        }
    }*/

    public virtual void LoadData(PlayerData data)
    {
        maxHp = data.basicHp;
        damage = data.basicDamage;
        speed = data.basicSpeed;
        runtimeAnimatorController = data.animator;
        iD = data.playerID;
        playerAnimation.LoadRunTimeAnimator();
        playerDamageReceiver.LoadHP();
        playerMovement.Speed = speed;
    }
}
