using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public DataBase dataBase;
    public DataLevel levelData;

    public Transform spawnersTrf;

    private int id = 0;
    private Wave oldWave;

    protected void Start()
    {
        StartCoroutine(CreateWaves());
    }

    // Tạo các wave theo thời gian
    IEnumerator CreateWaves()
    {
        while (id < levelData.listWavesData.Count)
        {
            CreateWave(id);
            yield return new WaitForSeconds(60); // Chờ 60 giây giữa các wave
            if (oldWave != null)
            {
                Destroy(oldWave.gameObject);
                oldWave = null;
            }
            id++;
        }
    }

    // Sinh quái cho từng wave
    protected void CreateWave(int waveID)
    {
        var wave = Instantiate(dataBase.prefabData.wavePrefab);
        wave.WaveID = waveID;
        wave.name = "Wave" + (waveID + 1);
        wave.InitWave(levelData.listWavesData[waveID]);
        Debug.LogWarning("Wave " + (waveID + 1) + " has been created.");
        oldWave = wave;
    }
}