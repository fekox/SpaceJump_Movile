using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System;
    
public class PlayGamesAchievements1 : MonoBehaviour
{
    public static PlayGamesAchievements1 instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowAchievements1() 
    {
#if UNITY_ANDROID
        if (Social.localUser.authenticated) 
        {
            Social.ShowAchievementsUI();
        }
#endif
    }

    public void Get10Points() 
    {
#if UNITY_ANDROID
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkI7aPZp4cCEAIQAQ", 100f, success => 
            {
                if (success) 
                {
                    Social.ShowAchievementsUI();
                }
            });
        }
#endif
    }

    public void Get50Points()
    {
#if UNITY_ANDROID
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkI7aPZp4cCEAIQAg", 100f, success => 
            {
                if (success)
                {
                    Social.ShowAchievementsUI();
                }
            });
        }
#endif
    }

    public void Get100Points()
    {
#if UNITY_ANDROID
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkI7aPZp4cCEAIQAw", 100f, success => 
            {
                if (success)
                {
                    Social.ShowAchievementsUI();
                }
            });
        }
#endif
    }
}
