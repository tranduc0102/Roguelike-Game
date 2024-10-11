using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] protected DamageSender _damageSender;
    public string enemyTag;

    protected virtual void OnEnable()
    {
        _damageSender = transform.GetComponent<DamageSender>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            _damageSender.SendDamage(other.transform);
        }
    }
}
