using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject star;
    private GameObject newStar;

    private float maxStarPosY = 3f;
    private float minStarPosY = 0f;

    public void SpawStar() 
    {
        float starPosY = Random.Range(maxStarPosY, minStarPosY);
        transform.position = new Vector3(transform.position.x, starPosY, 0f);
        newStar = Instantiate(star, transform.position, transform.rotation);
    }
}
