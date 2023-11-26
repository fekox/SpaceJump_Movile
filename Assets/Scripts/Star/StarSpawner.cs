using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [Header("References")]
    public Star star;

    private float maxStarPosY = 3f;
    private float minStarPosY = 0f;

    public void SpawStar() 
    {
        float starPosY = Random.Range(maxStarPosY, minStarPosY);
        transform.position = new Vector3(transform.position.x, starPosY, 0f);
        
        Star newStar = Instantiate(star);
        Star starClone = (StarMovement)newStar.Clone();
        starClone.transform.position = new Vector3(transform.position.x, starPosY, 0f);
    }
}
