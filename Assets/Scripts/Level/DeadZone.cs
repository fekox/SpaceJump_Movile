using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [Header("Setup")]
    public string playerTagName;

    [Header("References")]
    [SerializeField] private LoadLevel loadLevel;
    [SerializeField] private StarsCounterManager starsCounterManager;
    [SerializeField] private InterstitialAd interstitialAd;
    [SerializeField] private AnalyticsTraker analyticsTraker;

    private bool isAdLoad = false;
    private void Update()
    {
        if (!isAdLoad) 
        {
            interstitialAd.LoadAd();
            isAdLoad = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTagName))
        {
            analyticsTraker.RecordInterstitialAdImpression();
            VibrateCellPhone();
            interstitialAd.ShowAd();
            isAdLoad = false;
            loadLevel.LoadScene();
        }
    }

    private void VibrateCellPhone() 
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }

        else
        {
            Debug.LogWarning("Vibrate Failed");
        }
    }
}
