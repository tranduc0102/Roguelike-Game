using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("------Choice Plyer--------")]
    [SerializeField] protected Transform chooseTrf;
    [SerializeField] protected List<PlayerData> playerData;
    [SerializeField] protected List<ChoicePlayer> playerList;
    public PlayerData dataPlayer;
    private void OnEnable()
    {
        Load();
        DontDestroyOnLoad(gameObject);
    }
    protected void Load()
    {
        LoadDataPlayer();
        LoadChoosePlayerTrf();
        LoadListPlayer();
        LoadOptionPlayer();
    }
    public void LoadData(PlayerData data)
    {
        dataPlayer = data;
    }
    protected virtual void LoadChoosePlayerTrf()
    {
        if (chooseTrf != null) return;
        chooseTrf = GameObject.Find("Canvas").transform.Find("OptionPlayer").transform;
    }
    public void ActivePanelChoosePlayer()
    {
        chooseTrf.gameObject.SetActive(true);
    }
    public void HintPanelChoosePlayer()
    {
        chooseTrf.gameObject.SetActive(false);
    }
    protected virtual void LoadDataPlayer()
    {
        if (playerData.Count != 0) return;
        string resPath = "Database";
        playerData = Resources.Load<DataBase>(resPath).listPlayerData;
    }

    protected virtual void LoadListPlayer()
    {
        if (playerList.Count != 0) return;
        Transform options = chooseTrf.Find("Content").Find("ChosenBox").Find("Options");
        foreach (Transform option in options)
        {
            playerList.Add(option.GetComponent<ChoicePlayer>());
        }
    }
    protected virtual void LoadOptionPlayer()
    {
        if (playerList.Count == 0)
        {
            Debug.LogWarning("OptionCtrls are not loaded by Option Manager");
            return;
        }
        int i = 0;
        foreach (ChoicePlayer option in playerList)
        {
            option.Init(playerData[i]);
            i++;
        }
    }
}
