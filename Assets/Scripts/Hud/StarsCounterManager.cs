using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsCounterManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private string starsPlayerPref;
    
    private int starsScore = 0;

    [Header("References")]
    public TextMeshProUGUI starsCounterText;

    void Start()
    {
        ShowStartsScore();
    }

    void Update()
    {
        ShowStartsScore();
    }

    private void ShowStartsScore() 
    {
        starsCounterText.text = GetPlayerStarsScore().ToString();
    }

    public void AddStars(int number) 
    {
        starsScore += number;
    }

    public void SaveStarsScore()
    {
        PlayerPrefs.SetInt(starsPlayerPref, starsScore);
        PlayerPrefs.Save();
    }

    public int GetPlayerStarsScore() 
    {
        int savedCoins = PlayerPrefs.GetInt(starsPlayerPref, starsScore);

        return savedCoins;
    }
}
