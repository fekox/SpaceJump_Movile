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
    #region ACHIEVEMENTS

    public void Get10Points()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_beginer, 100f, success =>
        {
            if (success)
            {
                PlayGamesPlatform.Instance.ShowAchievementsUI();
            }
        });
    }

    public void Get50Points()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_jumper, 100f, success =>
        {
            if (success)
            {
                PlayGamesPlatform.Instance.ShowAchievementsUI();
            }
        });
    }

    public void Get100Points()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_jump_legend, 100f, success =>
        {
            if (success)
            {
                PlayGamesPlatform.Instance.ShowAchievementsUI();
            }
        });
    }

#endregion
}
