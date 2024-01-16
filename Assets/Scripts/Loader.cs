using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnApplicationQuit()
    {
        // SAVE
    }

    public void OnApplicationPause(bool pause)
    {
        // SAVE
        Debug.Log(pause + " pause ");
    }
}
