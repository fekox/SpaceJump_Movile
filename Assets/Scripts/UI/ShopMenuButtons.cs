using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuButtons : MonoBehaviour
{
    [SerializeField] private string[] sceneName;

    public void ReturnMenu()
    {
        SceneManager.LoadScene(sceneName[0]);
    }
}
