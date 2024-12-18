using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSelect : Singleton<DataSelect>
{
    private int selectedWeapon;
    public int IDWeapon
    {
        get { return selectedWeapon; }
        set { selectedWeapon = value; }
    }
    private PlayerData selectedPlayer;
    public PlayerData Player
    {
        get { return selectedPlayer; }
        set { selectedPlayer = value; }
    }
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
}
