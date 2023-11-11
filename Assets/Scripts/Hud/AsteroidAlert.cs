using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidAlert : MonoBehaviour
{
    [Header("Setup")]
    public GameObject alertLetter;
    public string asteroidTag;

    [Header("Timer")]
    [SerializeField] private float maxTime;
    public float time;
    private bool startTimer = false;

    private void Start()
    {
        time = maxTime;
    }

    private void Update()
    {
        if (startTimer == true)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            startTimer = false;
            StopBlinking();
            time = maxTime;
        }
    }

    private void StopBlinking()
    {
        alertLetter.SetActive(false);
    }

    private void StartBlinking()
    {
        alertLetter.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(asteroidTag))
        {
            startTimer = true;
            StartBlinking();
        }
    }
}
