using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private PlayerCtrl player;
    private void OnEnable()
    {
        
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        if (player == null) return;
        player.LoadData(WaveManager.Instance.dataBase.listPlayerData[0]);
    }
}
