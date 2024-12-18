using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("------Player Selection--------")]
    [SerializeField] protected Transform playerSelectionPanel;
    [SerializeField] protected List<PlayerData> availablePlayers;
    [SerializeField] protected List<ChoicePlayer> choicePlayersList;

    [Header("-------Weapon Selection-------")]
    [SerializeField] protected Transform weaponSelectionPanel;
    [SerializeField] protected List<Transform> availableWeapon;
    [SerializeField] protected List<OptionWeapon> choiceWeaponsList;

    private void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        LoadPlayerData();
        LoadPlayerSelectionPanel();
        LoadChoicePlayersList();
        PopulatePlayerChoices();

        LoadWeaponData();
        LoadWeaponSelectionPanel();
        LoadChoiceWeaponsList();
        PopulateWeaponChoices();
    }

    private void Reset()
    {
        Initialize();
    }

    protected virtual void LoadPlayerSelectionPanel()
    {
        if (playerSelectionPanel != null) return;
        playerSelectionPanel = GameObject.Find("Canvas").transform.Find("OptionPlayer").transform;
    }

    public void ShowPlayerSelectionPanel()
    {
        playerSelectionPanel.gameObject.SetActive(true);
    }

    public void HidePlayerSelectionPanel()
    {
        playerSelectionPanel.gameObject.SetActive(false);
    }

    protected virtual void LoadPlayerData()
    {
        if (availablePlayers.Count != 0) return;
        string resourcePath = "Database";
        availablePlayers = Resources.Load<DataBase>(resourcePath).listPlayerData;
    }

    protected virtual void LoadChoicePlayersList()
    {
        if (choicePlayersList.Count != 0) return;
        Transform optionsContainer = playerSelectionPanel.Find("Content").Find("ChosenBox").Find("Options");
        foreach (Transform option in optionsContainer)
        {
            choicePlayersList.Add(option.GetComponent<ChoicePlayer>());
        }
    }

    protected virtual void PopulatePlayerChoices()
    {
        if (choicePlayersList.Count == 0)
        {
            Debug.LogWarning("Player options are not loaded.");
            return;
        }

        int i = 0;
        foreach (ChoicePlayer choicePlayer in choicePlayersList)
        {
            choicePlayer.Init(availablePlayers[i]);
            i++;
        }
    }
    protected virtual void LoadWeaponSelectionPanel()
    {
        if (weaponSelectionPanel != null) return;
        weaponSelectionPanel = GameObject.Find("Canvas").transform.Find("OptionWeapon").transform;
    }

    public void ShowWeaponSelectionPanel()
    {
        weaponSelectionPanel.gameObject.SetActive(true);
    }

    public void HideWeaponSelectionPanel()
    {
        weaponSelectionPanel.gameObject.SetActive(false);
    }

    protected virtual void LoadWeaponData()
    {
        if (availableWeapon.Count != 0) return;
        string resourcePath = "DataWeapon";
        availableWeapon = Resources.Load<DataWeapon>(resourcePath).weapons;
    }

    protected virtual void LoadChoiceWeaponsList()
    {
        if (choiceWeaponsList.Count != 0) return;
        Transform optionsContainer = weaponSelectionPanel.Find("Content").Find("ChosenBox").Find("Options");
        foreach (Transform option in optionsContainer)
        {
            choiceWeaponsList.Add(option.GetComponent<OptionWeapon>());
        }
    }

    protected virtual void PopulateWeaponChoices()
    {
        if (choiceWeaponsList.Count == 0)
        {
            Debug.LogWarning("Weapon options are not loaded.");
            return;
        }

        int i = 0;
        foreach (OptionWeapon choiceWeapon in choiceWeaponsList)
        {
            if (availableWeapon[i] != null)
            {
                choiceWeapon.Init(availableWeapon[i], i);
                i++;
            }
        }
    }
}