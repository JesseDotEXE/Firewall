using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class GooglePlayData : MonoBehaviour 
{
    private bool isConnectedToGoogleServices = false;    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        InitGooglePlayServices();
    }

    private void InitGooglePlayServices()
    {
        #if UNITY_ANDROID
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            ConnectToGooglePlayServices();
        #endif
    }

    public void ConnectToGooglePlayServices()
    {
        Debug.Log("Testing Login");
        if(!isConnectedToGoogleServices)
        {
            Social.localUser.Authenticate((bool loginSuccess) => 
            {
                if(loginSuccess)
                {                 
                    Debug.Log("Login Successful");
                    LoggedInAchievementUnlock();
                }
                else
                {
                    Debug.Log("Login Failed");
                }

                isConnectedToGoogleServices = loginSuccess;
            });
        }
    }

    public bool IsConnectedToGooglePlayServices()
    {
        return isConnectedToGoogleServices;
    }

    public void LoggedInAchievementUnlock()
    {
        Social.ReportProgress("CgkIqO6pv6ofEAIQAw", 100.0f, (bool achievementSuccess) =>
        {
            if(achievementSuccess)
            {
                Debug.Log("Achievment CgkIqO6pv6ofEAIQAw unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock CgkIqO6pv6ofEAIQAw.");
            }
        });
    }

    public void FirstTimeAchievementUnlock()
    {
        Social.ReportProgress("CgkIqO6pv6ofEAIQBA", 100.0f, (bool achievementSuccess) =>
        {
            if(achievementSuccess)
            {
                Debug.Log("Achievment CgkIqO6pv6ofEAIQBA unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock CgkIqO6pv6ofEAIQBA.");
            }
        });
    }

    public void HighScore100AchievementUnlock()
    {
        Social.ReportProgress("CgkIqO6pv6ofEAIQBQ", 100.0f, (bool achievementSuccess) =>
        {
            if(achievementSuccess)
            {
                Debug.Log("Achievment CgkIqO6pv6ofEAIQBQ unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock CgkIqO6pv6ofEAIQBQ.");
            }
        });
    }

    public void Combo10AchievementUnlock()
    {
        Social.ReportProgress("CgkIqO6pv6ofEAIQBw", 100.0f, (bool achievementSuccess) =>
        {
            if(achievementSuccess)
            {
                Debug.Log("Achievment CgkIqO6pv6ofEAIQBw unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock CgkIqO6pv6ofEAIQBw.");
            }
        });
    }

    public void MinuteManAchievementUnlock()
    {
        Social.ReportProgress("CgkIqO6pv6ofEAIQBg", 100.0f, (bool achievementSuccess) =>
        {
            if(achievementSuccess)
            {
                Debug.Log("Achievment CgkIqO6pv6ofEAIQBg unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock CgkIqO6pv6ofEAIQBg.");
            }
        });
    }

    public void PostScore(long score)
    {
        Social.ReportScore(score, "CgkIqO6pv6ofEAIQAQ", (bool scoreSuccess) => 
        {
            if(scoreSuccess)
            {
                Debug.Log("Successfully posted to leaderboard CgkIqO6pv6ofEAIQAQ!");
            }
            else
            {
                Debug.Log("Failed to post to leaderboard CgkIqO6pv6ofEAIQAQ.");
            }
        });
    }

    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }

}
