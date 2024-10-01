using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int WaveID;
    public WaveData waveData; // data trong dataLevel
    public List<MiniWave> listMiniWaves = new List<MiniWave>(); // Khởi tạo listMiniWaves
    public List<MiniWaveData> listMiniWavesData;
    private int idMiniWave = 0;
    protected int time;
    protected int timeWave;

    public int TimeWave
    {
        get => timeWave;
    }

    public void InitWave(WaveData data)
    {
        listMiniWavesData.Clear();
        listMiniWaves.Clear();
        waveData = data;
        listMiniWavesData = data.listMiniWaveData;
        timeWave = data.TimeWave;
        CreateMiniWaves();
    }

    public void CreateMiniWaves()
    {
        idMiniWave = 0; // Reset lại idMiniWave
        time = 0;
        StartCoroutine(SpawnMiniWaves());
    }

    IEnumerator SpawnMiniWaves()
    {
        // Tạo ra các miniWave liên tục cứ sau mỗi 10s và nếu thời gian của wave còn dưới 20s thì không spawn miniWave nữa
        while (time <= timeWave)
        {
            /*if (time >= (timeWave - 10)) // Nếu thời gian còn dưới 20s thì không spawn miniWave nữa
            {
                yield break; // Thoát khỏi Coroutine nếu điều kiện thỏa
            }*/

            if (idMiniWave < listMiniWavesData.Count) // Kiểm tra nếu id không vượt quá số lượng MiniWaveData
            {
                SpawnMiniWave(idMiniWave);
                idMiniWave++;
            }
            else
            {
                idMiniWave = 0;
            }

            yield return new WaitForSeconds(3f); // Chờ 3 giây trước khi spawn MiniWave tiếp theo
            time += 5;
        }
    }

    private void SpawnMiniWave(int id)
    {
        var miniWave = Instantiate(WaveManager.Instance.dataBase.prefabData.miniWavePrefab, transform); // Spawn ra MiniWave
        miniWave.MiniWaveID = id;
        miniWave._Wave = this;
        miniWave.Init(listMiniWavesData[id], this.transform);
        listMiniWaves.Add(miniWave); // Thêm miniWave vào danh sách sau khi tạo
    }
}