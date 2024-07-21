using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticsTraker : MonoBehaviour
{
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    public void RecordInterstitialAdImpression()
    {
        CustomEvent adImpression = new CustomEvent("Show_Interstitial_Ad")
        {
            {"InterstitialAd","TestInterstitialAd"},
        };

        AnalyticsService.Instance.RecordEvent(adImpression);

        Debug.Log("Analytics: Show_Interstitial_Ad");
    }

    public void RecordRewardedAdImpression()
    {
        CustomEvent adImpression = new CustomEvent("Show_Rewarded_Ad")
        {
            {"RewardedAd","TestRewardedAd"},
        };

        AnalyticsService.Instance.RecordEvent(adImpression);

        Debug.Log("Analytics: Show_rewarded_Ad");
    }

    public void RecordStarsUsed(int startsSpent)
    {
        CustomEvent adImpression = new CustomEvent("Spent_Stars")
        {
            {"SpentStarts", startsSpent},
        };

        AnalyticsService.Instance.RecordEvent(adImpression);

        Debug.Log("Analytics: Spent_Stars " + startsSpent);
    }

    public void RecordCrashes()
    {
        CustomEvent adImpression = new CustomEvent("Crashes")
        {
            {"Crashes", "TestCrashes"},
        };

        AnalyticsService.Instance.RecordEvent(adImpression);

        Debug.Log("Analytics: Crashes");
    }
}