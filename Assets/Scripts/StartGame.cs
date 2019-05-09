using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string scene1;

    public void OnStartPressed()
    {
        SceneManager.LoadScene(scene1);
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}

