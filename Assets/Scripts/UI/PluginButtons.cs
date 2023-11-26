using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PluginButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;

    public void LoadMenu() 
    {
        SceneManager.LoadScene(sceneName[0]);
    }


}
