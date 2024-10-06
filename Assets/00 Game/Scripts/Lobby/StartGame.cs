using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public virtual void OnStartGame()
    {
        GameManager.Instance.ActivePanelChoosePlayer();
    }
}
