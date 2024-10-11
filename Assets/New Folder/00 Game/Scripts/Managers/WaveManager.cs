using System.Collections;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public DataBase dataBase;
    public DataLevel levelData;
    
    private int idWave = 0;
    private Wave oldWave;

    protected void Start()
    {
        StartCoroutine(CreateWaves());
    }

    // Tạo các wave theo thời gian
    IEnumerator CreateWaves()
    {
        while (idWave < levelData.listWavesData.Count)
        {
            CreateWave(idWave);
            yield return new WaitForSeconds(oldWave.TimeWave); // Chờ giữa các wave
            EventDispatcher.Instance.PostEvent(EventID.OnFinishWay);
            if (oldWave != null)
            {
                Destroy(oldWave.gameObject);
            }
            idWave++;
            if (idWave >= levelData.listWavesData.Count)
            {
                idWave = Random.Range(0, levelData.listWavesData.Count); // tạo vòng lặp Wave random Vô tận khi chạy hết các Wave đúng thứ tự
            }
        }
    }

    // Sinh quái cho từng wave
    protected void CreateWave(int waveID)
    {
       
        var wave = Instantiate(dataBase.prefabData.wavePrefab);
        wave.WaveID = waveID;
        wave.name = "Wave" + (waveID + 1);
        wave.InitWave(levelData.listWavesData[waveID]);
        Debug.Log("Wave " + (waveID + 1) + " has been created.");
        oldWave = wave;
    }
}