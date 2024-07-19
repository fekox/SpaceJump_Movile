using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Random Platform Position Y")]
    [SerializeField] float minPosY;
    [SerializeField] float maxPosY;

    [Header("Setup")]
    private float platformPosY;
    public float platformPosX;
    public float moveSpeed;

    [Header("Refernces")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ButtonData buttonData;

    public GameObject platformCollider;

    public void PlatformMove() 
    {
        float speedX = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(-speedX, 0f, 0f);
    }

    public void SetPlatformPosition(float posX) 
    {
        platformPosY = Random.Range(minPosY, maxPosY);
        transform.position = new Vector3(posX, (int)platformPosY, 0f);
    }
    
    public void RepositionPlatform() 
    {
        if (transform.position.x <= platformCollider.transform.position.x)
        {
            platformPosX = 9.3f;

            SetPlatformPosition(platformPosX);

            MultiplyScore();
        }
    }

    private void MultiplyScore()
    {
        if (buttonData.LoadInfo("X2"))
        {
            scoreManager.platformCounter += 2;
        }

        if (!buttonData.LoadInfo("X2"))
        {
            scoreManager.platformCounter++;
        }
    }
}