using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private BasePlayer player;
    private void Start()
    {
        player = GameObject.Find("Player").transform.GetChild(0).GetComponent<BasePlayer>();
        player.Init(WaveManager.Instance.dataBase.listPlayerData[0]);
    }
}
