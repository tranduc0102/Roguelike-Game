using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
     Moving();   
    }

    protected virtual void Moving()
    {
        Vector3 distance = (player.position - transform.position).normalized;
        transform.position += distance * speed * Time.deltaTime;
    }
}
