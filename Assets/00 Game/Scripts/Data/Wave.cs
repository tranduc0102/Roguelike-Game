using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int WaveID;
    public WaveData waveData; // data trong dataLevel
    public List<MiniWave> listMiniWaves;
    public List<MiniWaveData> listMiniWavesData;

    public void InitWave(WaveData data)
    {
        waveData = data;
        listMiniWavesData = data.listMiniWaveData;
        CreateMiniWaves();
    }

    public void CreateMiniWaves()
    {
        for (int i = 0; i < listMiniWavesData.Count; i++)
        {
            SpawnMiniWave(i);
        }
    }

    private void SpawnMiniWave(int id)
    {
        var miniWave = Instantiate(LevelManager.Instance.dataBase.prefabData.miniWavePrefab, transform); // Spawn ra các MiniWave
        miniWave.MiniWaveID = id;
        miniWave._Wave = this;
        miniWave.Init(listMiniWavesData[id]);
        listMiniWaves.Add(miniWave);
    }
}
