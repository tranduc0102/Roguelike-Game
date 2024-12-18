using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyCtrl : EnemyCtrl
{
    public Bullet bulletPrefab;
    [SerializeField] protected float bulletSpeed;

    public float BulletSpeed
    {
        get => bulletSpeed;
        set => bulletSpeed = value;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        bulletSpeed = 7f;
    }
}
