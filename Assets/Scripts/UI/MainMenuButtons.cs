using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;
    [SerializeField] private StarsCounterManager starSpawner;


    public GameObject debugButtons;

    private void Start()
    {
        debugButtons.SetActive(false);

#if UNITY_EDITOR
        debugButtons.SetActive(true);
#endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void GoToShop()
    {
        SceneManager.LoadScene(sceneName[1]);
    }

    public void GoToCredits() 
    {
        SceneManager.LoadScene(sceneName[2]);
    }

    public void GoToCPlugin()
    {
        SceneManager.LoadScene(sceneName[3]);
    }

    public void AddStars() 
    {
        starSpawner.AddStars(10);
    }

    public void ResetPlayerPrefs() 
    {
        PlayerPrefs.DeleteAll();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
