using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Setup")]
    public float moveSpeed;
    public float asteroidXPos;

    [Header("Refernces")]

    public GameObject asteroidLimitCollider;

    public void AsteroidMove()
    {
        float speedX = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(-speedX, 0f, 0f);
    }

    public void SetAsteroidXPosition(float posX)
    {
        float posY = 0;
        transform.position = new Vector3(posX, posY, 0f);
    }

    public void RepositionAsteroid()
    {
        if (transform.position.x <= asteroidLimitCollider.transform.position.x)
        {
            SetAsteroidXPosition(asteroidXPos);
        }
    }
}
