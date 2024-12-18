using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("InGame");
        TimeScaleManager.Instance.ResetToInitialSpeed();
    }
    public void Home()
    {
        SceneManager.LoadScene("Lobby");
        TimeScaleManager.Instance.ResetToInitialSpeed();
    }
}
