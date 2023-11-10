using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private Hud hud;
    [SerializeField] private PlatformMovement[] platformMovement;
    [SerializeField] private AsteroidMovement asteroidMovement;

    [Header("Setup")]
    private bool canAumentPlatformSpeed = false;
    public int maxScoreToIncreastDificult;
    public int newAsteroidSpeed;

    void Update()
    {
        IncreaseGameSpeed();
    }

    private void IncreaseGameSpeed() 
    {
        if (hud.platformCounter % maxScoreToIncreastDificult == 0 && !canAumentPlatformSpeed)
        {
            IncreasePlatformsSpeed();
            IncreaseAsteroidSpeed();

            canAumentPlatformSpeed = true;
        }

        if (hud.platformCounter % maxScoreToIncreastDificult != 0 && canAumentPlatformSpeed)
        {
            canAumentPlatformSpeed = false;
        }
    }

    private void IncreasePlatformsSpeed() 
    {
        for (int i = 0; i < platformMovement.Length; i++)
        {
            platformMovement[i].moveSpeed += 1;
        }
    }

    private void IncreaseAsteroidSpeed()
    {
        asteroidMovement.moveSpeed += 1;
        asteroidMovement.asteroidXPos += newAsteroidSpeed;
    }
}
