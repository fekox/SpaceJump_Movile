using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RewardedAd rewardedAd;

    private bool isAdLoad = false;

    [Header("Timer References")]
    [SerializeField] private NewTimer newTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timerSeg;
    private float maxTimerSeg = 300;

    private int seconds;
    private int minutes;

    private bool activeSave = true; 

    [SerializeField] private GameObject buttonSprite;
    [SerializeField] private GameObject text;
    private string timeText = "Time";

    [Header("Button References")]
    [SerializeField] private Button rewardedAdButton;

    void OnEnable()
    {
        timerSeg = GetTimer();

        if (newTimer.startTimer) 
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (!isAdLoad)
        {
            rewardedAd.LoadAd();
            isAdLoad = true;
        }

        if(newTimer.startTimer)
        {
            int oneMinute = 60;

            timerSeg -= Time.deltaTime;

            seconds = (int)timerSeg % oneMinute;
            minutes = (int)timerSeg / oneMinute;

            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);

            buttonSprite.SetActive(false);
        }

        if (activeSave) 
        {
            timerSeg = GetTimer();
            activeSave = false;
        }

        if (timerSeg <= 0) 
        {
            StopTimer();
            ResetTimer();
        }
    }

    public void StartTimer() 
    {
        newTimer.startTimer = true;
        rewardedAdButton.interactable = false;
        text.SetActive(true);
        buttonSprite.SetActive(false);
    }

    public void StopTimer()
    {
        newTimer.startTimer = false;
        rewardedAdButton.interactable = true;
        text.SetActive(false);
        buttonSprite.SetActive(true);
    }

    public void ResetTimer()
    {
        timerSeg = maxTimerSeg;
    }

    public void PlayRewardedAd() 
    {
        rewardedAd.ShowAd();
    }

    public void SetIsAdLoadToFalse()
    {
        bool newBool = false;

        isAdLoad = newBool;
    }
    public float GetTimer()
    {
        float savedTimer = PlayerPrefs.GetFloat(timeText, 0f);

        return savedTimer;
    }

    public void SaveTimer() 
    {
        PlayerPrefs.SetFloat(timeText, timerSeg);
        PlayerPrefs.Save();
    }
}
