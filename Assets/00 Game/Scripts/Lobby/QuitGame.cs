using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public virtual void OnQuitGame()
    {
        Application.Quit();
    }
}
