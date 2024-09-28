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

    public float MaxHp
    {
        get => maxHp;
        set => maxHp = value;
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
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

    protected virtual void LoadScripts()
    {
        LoadPlayerMovement();
        LoadPlayerAnimator();
    }

    protected virtual void LoadPlayerMovement()
    {
        playerMovement = transform.GetComponentInChildren<PlayerMovement>();
    }

    protected virtual void LoadPlayerAnimator()
    {
        playerAnimation = transform.GetComponentInChildren<PlayerAnimation>();
    }

    public virtual void LoadData(PlayerData data)
    {
        maxHp = data.basicHp;
        damage = data.basicDamage;
        speed = data.basicSpeed;
        runtimeAnimatorController = data.animator;
        iD = data.playerID;
    }
}
