using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TutorialManager tutorialManager;

    [Header("Player")]
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private InputManager inputManager;

    [Header("Platform Movement")]
    [SerializeField] private PlatformMovement[] platformMovement;

    [Header("Asteroid")]
    [SerializeField] private AsteroidMovement asteroidMovement;

    [Header("Parallax")]
    [SerializeField] private Parallax[] parallax;

    [Header("Setup")]
    private bool canAumentPlatformSpeed = false;
    public int maxScoreToIncreastDificult;
    public int newAsteroidSpeed;

    public bool pauseGame = true;

    void Update()
    {
        tutorialManager.AddTaps(1);
        tutorialManager.CheckTaps();

        if (pauseGame == false) 
        {
            inputManager.CheckInputs();
            playerMove.CorrectPlayerSpeed();
            playerMove.CheckMousePos();
            playerJump.CheckIsGrounded();

            IncreaseGameSpeed();

            for (int i = 0; i < platformMovement.Length; i++)
            {
                platformMovement[i].PlatformMove();
                platformMovement[i].RepositionPlatform();
            }

            asteroidMovement.AsteroidMove();
            asteroidMovement.RepositionAsteroid();

            for (int i = 0; i < parallax.Length; i++)
            {
                parallax[i].Scroll();
                parallax[i].CheckReset();
            }
        }
    }

    private void IncreaseGameSpeed() 
    {
        if (scoreManager.platformCounter % maxScoreToIncreastDificult == 0 && !canAumentPlatformSpeed)
        {
            IncreasePlatformsSpeed();
            IncreaseAsteroidSpeed();

            canAumentPlatformSpeed = true;
        }

        if (scoreManager.platformCounter % maxScoreToIncreastDificult != 0 && canAumentPlatformSpeed)
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
