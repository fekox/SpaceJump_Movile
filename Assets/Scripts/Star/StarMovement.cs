using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    [Header("Setup")]
    public float starSpeed;
    public string playerTag;

    [Header("References")]
    [SerializeField] private StarsCounterManager starsCM;
    [SerializeField] private StarSpawner starSpawner;

    private void Start()
    {
        starSpeed = 5;
    }

    private void Update()
    {
        StarMove();
    }

    public void StarMove() 
    {
        float speedX = starSpeed * Time.deltaTime;
        transform.position -= new Vector3(speedX, 0f, 0f);
    }
}
