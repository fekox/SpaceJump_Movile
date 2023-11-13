using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private string scorePlayerPref;

    private int saveScore = 0;

    public int platformCounter = 0;

    [Header("References")]
    public TextMeshProUGUI score;

    private void Start()
    {
        ShowScore();
    }

    private void Update()
    {
        ShowScore();
        UpdateHightScore();
    }

    private void ShowScore()
    {
        score.text = platformCounter.ToString();
    }

    private void UpdateHightScore()
    {
        saveScore = platformCounter;

        PlayerPrefs.SetInt(scorePlayerPref, saveScore);
    }
}
