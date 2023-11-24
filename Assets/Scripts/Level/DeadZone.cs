using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [Header("Setup")]
    public string playerTagName;

    [Header("References")]
    [SerializeField] private LoadLevel loadLevel;
    [SerializeField] private StarsCounterManager starsCounterManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTagName))
        {
            VibrateCellPhone();
            loadLevel.LoadScene();
        }
    }

    private void VibrateCellPhone() 
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }

        else
        {
            Debug.LogWarning("Vibrate Failed");
        }
    }
}
