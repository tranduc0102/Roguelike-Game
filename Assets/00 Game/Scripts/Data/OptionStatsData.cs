using System;

using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "OptionStatsData ",menuName = "Data/OptionStatsData")]
public class OptionStatsData : ScriptableObject
{
    public List<OptionStatsParam> ListOptionStats;
}

[Serializable]
public class OptionStatsParam
{
    public Sprite image;
    public string name;
    public string description;
    public StatsType statsType;
   
    public float value;
}

public enum StatsType
{
    Damage,
    MaxHp,
    Speed,
    Weapon
}
