//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    private GlobalData globalData;
    private GooglePlayData googlePlayData;
    private SpawnManager spawnManager;
    private BreachManager breachManager;
    private MusicManager musicManager;

    private float gameTimer;

    public float virusSpeed = 3.75f;
    public float virusSpawnInterval = 2f;
    public float virusMultiSpawn = 15f;
    public float difficultyTimeInterval = 15f;
    public float difficultyModNum = 0.25f;

    private float difficultyTimer;
    private int attributeToIncrease;
    private int currentDifficulty = 0;
    private bool allowRGB = false;
    private bool allowYCM = false;
    private bool allowWhite = false;
    private bool allowDouble = false;
    private bool allowIncrease = false;

    private float spawnTimer;

    public int lives = 3;
    public int pointsPerVirus = 1;
    public int comboCount = 1;

    private bool levelEnded;
    private int score;
    private int combo;
    private int streak;
    private int maxStreak;
    private int maxCombo;

    void Awake()
    {
        SetupComponents();
        SetupTiming();
        SetupDifficulty();
        SetupScoring();
        SetupSpawning();
        if(Application.platform == RuntimePlatform.Android)
        {
            googlePlayData.FirstTimeAchievementUnlock();
        }
    }

    void Update()
    {
        UpdateGlobalData();

        if(!levelEnded)
        {
            gameTimer += Time.deltaTime;
            difficultyTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;

            if(lives <= 0)
            {
                EndLevel();
            }

            if(difficultyTimer >= difficultyTimeInterval)
            {
                //Limits difficulty
                if(attributeToIncrease <= 21)
                {
                    IncreaseDifficulty();
                    difficultyTimer = 0f;
                }
            }

            if(spawnTimer >= virusSpawnInterval)
            {
                SpawnViruses();
                spawnTimer = 0f;
            }
        }
    }

    private void SetupComponents()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        googlePlayData = GameObject.Find("GooglePlay").GetComponent<GooglePlayData>();
        spawnManager = GetComponent<SpawnManager>();
        breachManager = GameObject.Find("Database").GetComponent<BreachManager>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    private void SetupTiming()
    {
        gameTimer = 0f;
    }

    private void SetupDifficulty()
    {
        difficultyTimer = 0f;
        attributeToIncrease = 0;
        IncreaseDifficulty();
    }

    private void SetupScoring()
    {
        levelEnded = false;
        score = 0;
        combo = 1;
        streak = 0;
        maxCombo = 0;
    }

    private void SetupSpawning()
    {
        spawnTimer = 0f;
    }

    private void CheckForAchievements()
    {
        if(score >= 100)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                googlePlayData.HighScore100AchievementUnlock();
            }
        }

        if(combo >= 10)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                googlePlayData.Combo10AchievementUnlock();
            }
        }

        if(gameTimer >= 60)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                googlePlayData.MinuteManAchievementUnlock();
            }
        }
    }

    private void UpdateGlobalData()
    {
        globalData.globalVars["virusSpeed"] = virusSpeed;
        globalData.globalVars["score"] = score;
        globalData.globalVars["combo"] = combo;
        globalData.globalVars["maxStreak"] = maxStreak;
        globalData.globalVars["gameTimer"] = gameTimer;
    }

    private void EndLevel()
    {
        levelEnded = true;
        globalData.CleanUpGameObject("Virus");
        musicManager.StopPlaying();
        breachManager.DestroyDatabase();
    }

    private void SpawnViruses()
    {
        //Set over so we will only spawn once unless allowDouble is allowed.
        float doubleSpawn = 100;
        
        if (allowDouble)
        {
            doubleSpawn = globalData.globalRandom.Next(1, 100);
        }

        if(doubleSpawn < virusMultiSpawn)
        {
            spawnManager.SpawnVirus(0);
            spawnManager.SpawnVirus(1);
        }
        else
        {
            spawnManager.SpawnVirus(0);
        }
    }

    private void IncreaseDifficulty()
    {
        currentDifficulty++;

        if(currentDifficulty == 1)
        {
            allowRGB = true;
        }
        else if(currentDifficulty == 2)
        {
            allowYCM = true;
        }
        else if(currentDifficulty == 3)
        {
            allowWhite = true;
        }
        else if(currentDifficulty == 4)
        {
            allowDouble = true;
        }
        else if(currentDifficulty == 5)
        {
            allowIncrease = true;
            difficultyTimeInterval = 10f;
        }

        Debug.Log("Difficulty: " + allowRGB + " | " + allowYCM + " | " + allowWhite + " | " + allowDouble + " | " + allowIncrease);

        //This is only used after the player has passed all the "stages".
        if (allowIncrease)
        {
            //Might want to randomize.
            int attribute = attributeToIncrease % 3;

            if (attribute == 0)
            {
                virusSpeed += difficultyModNum;
            }
            else if (attribute == 1)
            {
                virusSpawnInterval -= (difficultyModNum * 0.5f);
            }
            else if (attribute == 2)
            {
                virusMultiSpawn += (difficultyModNum * 12);
            }

            attributeToIncrease++;
        }
    }

    public void DecreaseLives()
    {
        lives--;
        streak = 0;
        combo = 1;
    }

    public void AddPoints()
    {
        score = score + (pointsPerVirus * combo);
        //Debug.Log("Score: " + score);
        streak++;

        if(streak > maxStreak)
        {
            maxStreak = streak;
        }

        if((streak % comboCount) == 0)
        {
            combo++;
        }
    }

    public void BreakStreak()
    {
        streak = 0;
    }

    public bool IsRGBAllowed()
    {
        return allowRGB;
    }

    public bool IsYCMAllowed()
    {
        return allowYCM;
    }

    public bool IsWhiteAllowed()
    {
        return allowWhite;
    }

    public bool IsDoubleAllowed()
    {
        return allowDouble;
    }

    public bool IsIncreaseAllowed()
    {
        return allowIncrease;
    }
}
