using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class GooglePlayData : MonoBehaviour 
{
    public static int ACHIEVEMENT_INITIALIZE_SYSTEM = 1;
    public static int ACHIEVEMENT_TRAINING_COMPLETE = 2;
    public static int ACHIEVEMENT_SEQUENCE_10 = 3;
    public static int ACHIEVEMENT_SEQUENCE_30 = 4;    
    public static int ACHIEVEMENT_RUNTIME_90 = 5;
    public static int ACHIEVEMENT_RUNTIME_120 = 6;
    public static int ACHIEVEMENT_RANK_100 = 7;
    public static int ACHIEVEMENT_RANK_500 = 8;
    public static int ACHIEVEMENT_RANK_1000 = 9;
    public static int ACHIEVEMENT_INITIALIZE_CREDITS = 10;

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
        Debug.LogError("Testing Login");
        if(!isConnectedToGoogleServices)
        {
            Social.localUser.Authenticate((bool loginSuccess) => 
            {
                if(loginSuccess)
                {                 
                    Debug.LogError("Login Successful");
                    AchievementUnlock(ACHIEVEMENT_INITIALIZE_SYSTEM);
                }
                else
                {
                    Debug.LogError("Login Failed");
                }

                isConnectedToGoogleServices = loginSuccess;
            });
        }
    }

    public bool IsConnectedToGooglePlayServices()
    {
        return isConnectedToGoogleServices;
    }

    public void AchievementUnlock(int achievmentNum)
    {
        if (achievmentNum == ACHIEVEMENT_INITIALIZE_SYSTEM)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQAw", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment initializeSystemProtection(true); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock initializeSystemProtection(true);.");
                }
            });
        }
        else if(achievmentNum == ACHIEVEMENT_TRAINING_COMPLETE)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQBA", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment trainingComplete(true); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock trainingComplete(true);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_SEQUENCE_10)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQBg", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment sequenceProcess(10); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock sequenceProcess(10);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_SEQUENCE_30)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQBw", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment sequenceProcess(30); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock sequenceProcess(30);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_RUNTIME_90)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQCA", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment firewallRunTimeMS(90000); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock firewallRunTimeMS(90000);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_RUNTIME_120)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQCQ", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment firewallRunTimeMS(120000); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock firewallRunTimeMS(120000);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_RANK_100)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQCg", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment securityRank(100); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock securityRank(100);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_RANK_500)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQCw", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment securityRank(500); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock securityRank(500);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_RANK_1000)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQBQ", 100.0f, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment securityRank(1000); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock securityRank(1000);.");
                }
            });
        }
        else if (achievmentNum == ACHIEVEMENT_INITIALIZE_CREDITS)
        {
            Social.ReportProgress("CgkIqO6pv6ofEAIQDA", 100, (bool achievementSuccess) =>
            {
                if (achievementSuccess)
                {
                    Debug.LogError("Achievment creditsInitiated(true); unlocked!");
                }
                else
                {
                    Debug.LogError("Failed to unlock creditsInitiated(true);.");
                }
            });
        }
    }

    public void PostScore(long score)
    {
        Social.ReportScore(score, "CgkIqO6pv6ofEAIQDQ", (bool scoreSuccess) => 
        {
            if(scoreSuccess)
            {
                Debug.LogError("Successfully posted to leaderboard High Scores!");
            }
            else
            {
                Debug.LogError("Failed to post to leaderboard High Scores.");
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
