using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "Data/ Database")]
public class DataBase : ScriptableObject
{
    public PrefabData prefabData;
    public List<PlayerData> listPlayerData;
    public List<EnemyData> listEnemyData;
}
[Serializable]
public class PlayerData
{
    public string playerName;
    public int playerID;
    public float basicHp;
    public float basicDamage;
    public float basicSpeed = 5f;
    public RuntimeAnimatorController animator;
}
[Serializable]
public class EnemyData
{
    public string enemyName;
    public int enemyID;
    public float maxHp;
    public float damage;
    public float speed = 2f;
    public float timeAttack;
    public float attackRange;
    public EnemyCtrl enemyPrefab;
}
[Serializable]
public class PrefabData 
{
    public Wave wavePrefab;// dot quai
    public MiniWave miniWavePrefab;// dot quai nho
}