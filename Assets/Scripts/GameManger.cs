using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private ButtonData buttonData;

    [Header("Player")]
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private InputManager inputManager;

    [Header("Platform Movement")]
    [SerializeField] private PlatformMovement[] platformMovement;

    [Header("Asteroid")]
    [SerializeField] private AsteroidMovement asteroidMovement;

    [Header("Star")]
    [SerializeField] private StarMovement starMovement;
    [SerializeField] private StarSpawner starSpawner;

    [Header("Parallax")]
    [SerializeField] private Parallax[] parallax;

    [Header("Enable PowerUps")]
    [SerializeField] private GameObject X2PowerUp;
    [SerializeField] private GameObject plusFiftyPowerUp;

    private bool canAumentPlatformSpeed = false;
    private bool canSpawnStar = false;
    private bool add50M = false;

    [Header("Setup")]
    public int maxScoreToIncreastDificult;
    public int newAsteroidSpeed;

    public int maxScoreToSpawnStar;

    public bool pauseGame = false;
    public bool selecCharacter = false;

    void Update()
    {
        if(selecCharacter == true) 
        {
            tutorialManager.AddTaps(1);
            tutorialManager.CheckTaps();
        }

        if (pauseGame == false) 
        {
            X2PowerUp.SetActive(true);
            plusFiftyPowerUp.SetActive(true);
            inputManager.CheckInputs();
            playerMove.CorrectPlayerSpeed();
            playerMove.CheckMousePos();
            playerJump.CheckIsGrounded();
            Plus50Meters();

            IncreaseGameSpeed();

            for (int i = 0; i < platformMovement.Length; i++)
            {
                platformMovement[i].PlatformMove();
                platformMovement[i].RepositionPlatform();
            }

            SpawnStart();

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
            IncreaseStarSpeed();

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

    private void IncreaseStarSpeed() 
    {
        starMovement.starSpeed += 1;
    }

    private void SpawnStart() 
    {
        if (scoreManager.platformCounter % maxScoreToSpawnStar == 0 && scoreManager.platformCounter != 0 && !canSpawnStar)
        {
            starSpawner.SpawStar();

            canSpawnStar = true;
        }

        if (scoreManager.platformCounter % maxScoreToSpawnStar != 0 && canSpawnStar)
        {
            canSpawnStar = false;
        }
    }

    private void Plus50Meters() 
    {
        int num = 50;

        if (buttonData.isPlus50Buyed == true && add50M == false) 
        {
            plusFiftyPowerUp.SetActive(true);
            scoreManager.platformCounter += num;
            add50M = true;
        }

        if(buttonData.isX2Buyed == true) 
        {
            X2PowerUp.SetActive(true);
        }
    }
}
