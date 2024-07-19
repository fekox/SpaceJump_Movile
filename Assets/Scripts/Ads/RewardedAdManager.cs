using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAdManager : MonoBehaviour
{
    [SerializeField] private RewardedAd rewardedAd;

    private bool isAdLoad = false;
    private void Update()
    {
        if (!isAdLoad)
        {
            rewardedAd.LoadAd();
            isAdLoad = true;
        }
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
}
