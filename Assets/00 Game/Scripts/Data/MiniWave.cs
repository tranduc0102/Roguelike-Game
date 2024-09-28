using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MiniWave : MonoBehaviour
{
    protected int miniWaveID;
    protected Wave wave;
    protected MiniWaveData miniWaveData;
    protected List<EnemyData> listEnemyDatas = new List<EnemyData>();
    protected List<BaseEnemy> listEnemies = new List<BaseEnemy>();
    protected float spawnCoolDown;

    public int MiniWaveID
    {
        get => miniWaveID;
        set => miniWaveID = value;
    }

    public Wave _Wave
    {
        get => wave;
        set => wave = value;
    }

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.CheckAllEnemyDied,  
                param =>CheckIfAllEnemyDied((BaseEnemy)param));
    }
    public void Init(MiniWaveData data,Transform parent)
    {
        miniWaveData = data;
        spawnCoolDown = data.spawnCooldown;
        var listEnemiesID = data.listEnemiesID;
        for (int i = 0; i < listEnemiesID.Count; i++)
        {
            var enemy = WaveManager.Instance.dataBase.listEnemyData[listEnemiesID[i]];
            listEnemyDatas.Add(enemy);
        }
        
        transform.SetParent(parent);
        StartCoroutine(SpawnerMiniWave());
    }

    protected virtual IEnumerator SpawnerMiniWave()
    {
        for (int i = 0; i < listEnemyDatas.Count; i++)
        {
            SpawnEnermy(i);
            yield return new WaitForSeconds(spawnCoolDown);
        }
    }

    protected virtual void SpawnEnermy(int ID)
    {
        var enemy = PoolingManager.Spawn(WaveManager.Instance.dataBase.listEnemyData[miniWaveData.listEnemiesID[ID]].enemyPrefab);
        // truy cập vào WaveManager rồi truy cập vào databse lấy listEnemydata
        // sau đó truy cập vào miniData đã được Init ở scipt Wave sau đó truy cập đến List ID quái 
        // rồi từ cái ID đó ta sẽ truyền vào listEnemyData[ID].enemyPrefab để sinh ra Enemy Prefab với ID tương ứng
        enemy.name = listEnemyDatas[ID].enemyName + " " + (ID + 1);
        enemy.transform.position = new Vector3(Random.Range(-10,10),Random.Range(-10,10));
        enemy.LoadData(listEnemyDatas[ID]);
        listEnemies.Add(enemy);
        enemy.transform.SetParent(transform);
    }

    protected virtual void CheckIfAllEnemyDied(BaseEnemy enemy)
    {
        if (listEnemies != null)
        {
            listEnemies.Remove(enemy);
        }
        else
        {
            Debug.Log("Clear Enemy");
        }
    }
}
