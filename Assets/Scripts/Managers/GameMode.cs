using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour 
{
    private GlobalData globalData;
    private ScoreManager scoreManager;
    private SpawnManager spawnManager;
    
    private float gameTimer;
    private float maxGameTime;
    private float difficultyTimer;
    private float difficultyTimeInterval;

    //These values get set by difficulty.
    private float curObjSpeed;
    private float curSpawnInterval;
    private float curSinglePortPercent;
    private float difficultyMod;
    private int attributeToIncrease;    


    // Use this for initialization
    void Awake () 
    {
        DontDestroyOnLoad(transform.gameObject);
        scoreManager = GetComponent<ScoreManager>();
        spawnManager = GetComponent<SpawnManager>();

        ReadGlobalData();

        gameTimer = 0f;        
        maxGameTime = 90f;
        difficultyTimer = 0f;
        difficultyTimeInterval = 10f;

        attributeToIncrease = 0;        
    }
	
	// Update is called once per frame
	void Update () 
    {
        gameTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if(gameTimer >= maxGameTime || scoreManager.GetLives() <= 0)
        {
            //End spawning
            spawnManager.StopSpawningObjects();
        }

        if(difficultyTimer >= difficultyTimeInterval)
        {
            if (attributeToIncrease <= 21)
            {
                IncreaseDifficulty();
                difficultyTimer = 0f;
            }
        }
	}

    private void IncreaseDifficulty()
    {
        int attribute = attributeToIncrease % 3;
                
        if(attribute == 0)
        {
            curObjSpeed += difficultyMod;
        }
        else if(attribute == 1)
        {
            curSpawnInterval -= difficultyMod;
        }
        else if(attribute == 2)
        {
            curSinglePortPercent -= (difficultyMod * 20f);
        }        

        //Send to SpawnManager
        spawnManager.UpdateDifficulty();
        attributeToIncrease++;
    }

    private void ReadGlobalData()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        
        if(globalData.difficulty != 0)
        {
            if(globalData.difficulty == 1)
            {
                //Play around with.
                curObjSpeed = 3.75f;
                curSpawnInterval = 2.0f;
                curSinglePortPercent = 75.0f;
                difficultyMod = 0.25f;
            }
            else if(globalData.difficulty == 2)
            {
                //Play around with.
                curObjSpeed = 4.5f;
                curSpawnInterval = 1.75f;
                curSinglePortPercent = 75.0f;                
                difficultyMod = 0.25f;
            }
        }
        //Allow manually setting of data.
        else 
        {
            curObjSpeed = globalData.objMoveSpeed;
            curSpawnInterval = globalData.spawnInterval;
            curSinglePortPercent = globalData.singlePortPercent;
            difficultyMod = globalData.difficultyMod;
            //Don't have a box for it yet.
            difficultyMod = 0.25f;
        }        
    }

    public float GetGameTimer()
    {
        return gameTimer;
    }
    
    public ScoreManager GetScoreManager()
    {
        return scoreManager;
    }

    public SpawnManager GetSpawnManager()
    {
        return spawnManager;
    }

    public GlobalData GetGlobalData()
    {
        return globalData;
    }

    public float GetCurrentObjSpeed()
    { 
        return curObjSpeed;
    }

    public float GetCurrentSpawnInterval()
    {
        return curSpawnInterval;
    }

    public float GetCurrentSinglePortPercentage()
    {
        return curSinglePortPercent;
    }
}
