using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Setup")]
    public float moveSpeed;
    public float platformXPos;

    [Header("Refernces")]
    [SerializeField] private Hud hud;
    
    public GameObject platformCollider;


    void Update()
    {
        PlatformMove();
        RepositionPlatform();
    }

    private void PlatformMove() 
    {
        float speedX = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(-speedX, 0f, 0f);
    }

    public void SetPlatformXPosition(float posX) 
    {
        float posY = -4.5f;
        transform.position = new Vector3(posX, posY, 0f);
    }
    
    private void RepositionPlatform() 
    {
        if (transform.position.x <= platformCollider.transform.position.x)
        {
            SetPlatformXPosition(platformXPos);
            hud.platformCounter++;
        }
    }   
}
