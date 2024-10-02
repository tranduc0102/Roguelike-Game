using System;

using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "LevelUpStatsData ",menuName = "Data/LevelUpStatsData")]
public class LevelUpStatsData : ScriptableObject
{
    public List<LevelUpStatsParam> ListLevelUpStats;
}

[Serializable]
public class LevelUpStatsParam
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
    MaxHp
}
