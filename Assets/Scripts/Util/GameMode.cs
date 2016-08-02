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
    public float virusMultiSpawn = 10f;
    public float difficultyTimeInterval = 5f;
    public float difficultyModNum = 0.25f;

    private float difficultyTimer;
    private int attributeToIncrease;

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
        googlePlayData.FirstTimeAchievementUnlock();
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
            googlePlayData.HighScore100AchievementUnlock();
        }

        if(combo >= 10)
        {
            googlePlayData.Combo10AchievementUnlock();
        }

        if(gameTimer >= 60)
        {
            googlePlayData.MinuteManAchievementUnlock();
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
        //Get amount of viruses to spawn.
        float multiSpawn = globalData.globalRandom.Next(1, 100);

        if(multiSpawn < virusMultiSpawn)
        {
            float numVirusToSpawn = globalData.globalRandom.Next(2, 4);
            while(numVirusToSpawn > 0)
            {
                spawnManager.SpawnVirus();
                numVirusToSpawn -= 1;
            }
        }
        else
        {
            spawnManager.SpawnVirus();
        }
    }

    private void IncreaseDifficulty()
    {
        //Might want to randomize.
        int attribute = attributeToIncrease % 3;

        if(attribute == 0)
        {
            virusSpeed += difficultyModNum;
        }
        else if(attribute == 1)
        {
            virusSpawnInterval -= difficultyModNum;
        }
        else if(attribute == 2)
        {
            virusMultiSpawn += (difficultyModNum * 8);
        }

        attributeToIncrease++;
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
        Debug.Log("Score: " + score);
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
}
