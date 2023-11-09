using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
