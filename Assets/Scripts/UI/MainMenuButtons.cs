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

    public void GoToShop()
    {
        SceneManager.LoadScene(sceneName[1]);
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
