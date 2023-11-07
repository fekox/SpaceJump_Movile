using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private Hud hud;
    [SerializeField] private PlatformMovement[] platformMovement;
    private bool canAumentSpeed = false;

    void Update()
    {
        ClimbDificult();
    }

    private void ClimbDificult()
    {
        if (hud.platformCounter % 5 == 0 && !canAumentSpeed)
        {
            for (int i = 0; i < platformMovement.Length; i++) 
            {
                platformMovement[i].moveSpeed += 1;
            }

            canAumentSpeed = true;
        }

        if(hud.platformCounter % 5 != 0 && canAumentSpeed)
        {
            canAumentSpeed = false;
        }
    }
}
