using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private BasePlayer player;
    private void Start()
    {
        
        player = GameObject.Find("Player").transform.GetChild(0).GetComponent<BasePlayer>();
        if (player == null) return;
        player.Init(LevelManager.Instance.dataBase.listPlayerData[0]);
    }
}
