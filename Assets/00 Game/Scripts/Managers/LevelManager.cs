using System.Collections.Generic;
using UnityEngine;
using Unity;

public class LevelManager : Singleton<LevelManager>
{
    public DataBase dataBase;
    public DataLevel levelData;

    public Transform spawnersTrf;
    public List<Wave> listWaves = new List<Wave>();

    protected void Start()
    {
        CreateWave(0);
    }
    
    
    //sinh quai cho wave
    public void CreateWave(int waveID)
    {
        var wave = Instantiate(dataBase.prefabData.wavePrefab);
        wave.WaveID = waveID;
        wave.name = "Wave" + (waveID + 1);
        wave.InitWave(levelData.listWavesData[waveID]);
        listWaves.Add(wave);

    }
}