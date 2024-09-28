using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniWave : MonoBehaviour
{
    protected int miniWaveID;
    protected Wave wave;
    protected MiniWaveData miniWaveData;
    protected List<EnemyData> listEnemyDatas = new List<EnemyData>();
    protected List<EnemyCtrl> listEnemies = new List<EnemyCtrl>();
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
    
    public void Init(MiniWaveData data)
    {
        miniWaveData = data;
        spawnCoolDown = data.spawnCooldown;
        var listEnemiesID = data.listEnemiesID;
        for (int i = 0; i < listEnemiesID.Count; i++)
        {
            var enemy = LevelManager.Instance.dataBase.listEnemyData[listEnemiesID[i]];
            listEnemyDatas.Add(enemy);
        }
        
        transform.SetParent(LevelManager.Instance.spawnersTrf);

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
       
        var enemy = PoolingManager.Spawn(LevelManager.Instance.dataBase.listEnemyData[miniWaveData.listEnemiesID[ID]].enemyPrefab);
        // truy cập vào levelManager rồi truy cập vào databse lấy listEnemydata
        // sau đó truy cập vào miniData đã được Init ở scipt Wave sau đó truy cập đến List ID quái 
        // rồi từ cái ID đó ta sẽ truyền vào listEnemyData[ID].enemyPrefab để sinh ra Enemy Prefab với ID tương ứng
        
        enemy.name = listEnemyDatas[ID].enemyName + " " + (ID + 1);
        
        enemy.transform.position = new Vector3(Random.Range(-10,10),Random.Range(-10,10));
        enemy.LoadData(listEnemyDatas[ID]);
        listEnemies.Add(enemy);
        enemy.transform.SetParent(transform);
    }
}
