using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsCounterManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private string starsPlayerPref;
    
    public int starsScore;

    [Header("References")]
    public TextMeshProUGUI starsCounterText;

    void Start()
    {
        starsScore = GetPlayerStarsScore();
        ShowStartsScore();
    }

    void Update()
    {
        ShowStartsScore();
    }

    private void ShowStartsScore() 
    {
        starsCounterText.text = starsScore.ToString();
    }

    public void AddStars(int number) 
    {
        starsScore += number;
        SaveStarsScore();
    }

    public void RemoveStars(int number) 
    {
        starsScore -= number;
        SaveStarsScore();
    }

    public void SaveStarsScore()
    {
        PlayerPrefs.SetInt(starsPlayerPref, starsScore);
        PlayerPrefs.Save();
    }

    public int GetPlayerStarsScore() 
    {
        int savedCoins = PlayerPrefs.GetInt(starsPlayerPref, 0);

        return savedCoins;
    }
}
