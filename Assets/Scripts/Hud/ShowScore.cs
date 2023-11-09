using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private string scorePlayerPref;

    private int saveCoins;

    private int defaultValue = 0;

    void Start()
    {
        saveCoins = PlayerPrefs.GetInt(scorePlayerPref, defaultValue);
        scoreText.text = "SCORE: " + saveCoins.ToString();
    }
}
