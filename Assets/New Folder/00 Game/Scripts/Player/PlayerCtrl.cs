using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] protected int iD;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected PlayerAnimation playerAnimation;
    [SerializeField] protected RuntimeAnimatorController runtimeAnimatorController;
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    [SerializeField] protected List<Weapon> listWeapon;
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

    public virtual void LoadData(PlayerData data)
    {
        maxHp = data.basicHp;
        damage = data.basicDamage;
        Speed = data.basicSpeed;
        runtimeAnimatorController = data.animator;
        iD = data.playerID;
        playerAnimation.LoadRunTimeAnimator();
        playerDamageReceiver.LoadHP();
    }
}
