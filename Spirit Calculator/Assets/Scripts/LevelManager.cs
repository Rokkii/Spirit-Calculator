using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ChangeScene(string loadLevel)
    {
        SceneManager.LoadScene(loadLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
