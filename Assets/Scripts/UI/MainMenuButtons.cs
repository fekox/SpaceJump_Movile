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
        FindObjectOfType<AudioManager>().Play("GamePlayMusic");

        debugButtons.SetActive(false);

#if UNITY_EDITOR
        debugButtons.SetActive(true);
#endif
    }

    public void PlayGame()
    {
        PlayButtonSound();
        SceneManager.LoadScene(sceneName[0]);
    }

    public void GoToShop()
    {
        PlayButtonSound();
        SceneManager.LoadScene(sceneName[1]);
    }

    public void GoToCredits() 
    {
        PlayButtonSound();
        SceneManager.LoadScene(sceneName[2]);
    }

    public void GoToCPlugin()
    {
        PlayButtonSound();
        SceneManager.LoadScene(sceneName[3]);
    }

    public void AddStars() 
    {
        PlayButtonSound();
        starSpawner.AddStars(10);
    }

    public void ResetPlayerPrefs() 
    {
        PlayButtonSound();
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs deleted");
    }

    public void ExitGame()
    {
        PlayButtonSound();
        Application.Quit();
    }

    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
