using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject tutorialPopUp;
    [SerializeField] private GameObject firstTap;
    [SerializeField] private GameObject secondTap;
    [SerializeField] private GameManger gameManager;

    [Header("Setup")]
    private int taps = 0;
    private bool isSecondTapPressed = false;
    private float timer;

    public float maxTime;

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if (isSecondTapPressed)
        {
            timer -= Time.deltaTime;
        }
    }

    public void CheckTaps()
    {
        if (taps == 0) 
        {
            firstTap.SetActive(true);
            secondTap.SetActive(false);
        }

        if (taps > 0) 
        {
            isSecondTapPressed = true;
            firstTap.SetActive(false);
            secondTap.SetActive(true);
        }

        if (timer <= 0)
        {
            timer = maxTime;
            isSecondTapPressed = false;

            tutorialPopUp.SetActive(false);
            firstTap.SetActive(false);
            secondTap.SetActive(false);
            gameManager.pauseGame = false;
            gameManager.selecCharacter = false;
        }
    }

    public void AddTaps(int number) 
    {
        if (Input.GetMouseButton(0))
        {
            taps += number;
        }
    }
}
