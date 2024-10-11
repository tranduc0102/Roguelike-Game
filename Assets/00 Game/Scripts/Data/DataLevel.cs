using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData ", menuName = "Data/LevelData")]
public class DataLevel : ScriptableObject
{
    public List<WaveData> listWavesData;
}
[Serializable]
public class WaveData
{
    public string name;
    public List<MiniWaveData> listMiniWaveData;
    public int TimeWave;
}
[Serializable]
public class MiniWaveData
{
    public string name;
    public float spawnCooldown;
    public List<int> listEnemiesID;
}