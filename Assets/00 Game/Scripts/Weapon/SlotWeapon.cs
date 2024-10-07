﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotWeapon : MonoBehaviour
{
    private List<Vector3> posWeapon = new List<Vector3>()
    {
        new Vector3(1, 0, 0),        // 0 độ
        new Vector3(-1, 0, 0),       // 180 độ
        new Vector3(0.707f, 0.707f, 0),   // 45 độ
        new Vector3(-0.707f, 0.707f, 0),  // 135 độ
        new Vector3(0, 1, 0),        // 90 độ
        new Vector3(-0.707f, -0.707f, 0), // 225 độ
        new Vector3(0.707f, -0.707f, 0),  // 315 độ
        new Vector3(0, -1, 0)        // 270 độ
    };
    private int index = 0;
    private List<Transform> slots = new List<Transform>();

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.AddWeapon,param=>AddWeapon());
    }

    private void Start()
    {
        LoadData();
    }
    private void LoadData()
    {
        slots = Resources.Load<DataWeapon>("DataWeapon").weapons;
        GameObject newWeapon = PoolingManager.Spawn(slots[GameManager.Instance.IDWeapon].gameObject, transform.position + posWeapon[index], Quaternion.identity);
        newWeapon.transform.parent = transform;
        index++;
    }
    private void AddWeapon()
    {
        if (index >= posWeapon.Count)
        {
            return;
        }

        int randomIndex = Random.Range(0, slots.Count);
        GameObject newWeapon = PoolingManager.Spawn(slots[randomIndex].gameObject, transform.position+posWeapon[index],Quaternion.identity);
        newWeapon.transform.parent = transform;
        index++;
    }
}