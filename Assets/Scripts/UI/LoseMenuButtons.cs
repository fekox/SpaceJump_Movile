using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;

    public void Restart() 
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void ReturnMenu() 
    {
        SceneManager.LoadScene(sceneName[1]);
    }
}
