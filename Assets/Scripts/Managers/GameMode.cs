using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMode : MonoBehaviour 
{
    private GlobalData globalData;
    private ScoreManager scoreManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;
    private JukeBoxLogic jukeBoxLogic;
    
    public GameObject colorButtons;
    public GameObject redScreen;
    public GameObject bigDataStoreBreach;
    public GameObject databaseBreak;

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

    private bool levelEnded;

    public AudioClip breakSound;
    public AudioClip failureSound;


    // Use this for initialization
    void Awake () 
    {
        //DontDestroyOnLoad(transform.gameObject);
        scoreManager = GetComponent<ScoreManager>();
        spawnManager = GetComponent<SpawnManager>();
        audioSource = GetComponent<AudioSource>();
        jukeBoxLogic = GameObject.Find("JukeBox").GetComponent<JukeBoxLogic>();

        ReadGlobalData();

        SetButtonPosition(globalData.buttonFlip);

        levelEnded = false;

        gameTimer = 0f;       
        difficultyTimer = 0f;
        difficultyTimeInterval = 5f;

        attributeToIncrease = 0;        
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!levelEnded)
        {
            gameTimer += Time.deltaTime;
            difficultyTimer += Time.deltaTime;

            if (scoreManager.GetLives() <= 0)
            {
                CleanUpGameObject("Virus");
                EndLevel();
            }

            if (difficultyTimer >= difficultyTimeInterval)
            {
                if (attributeToIncrease <= 21)
                {
                    IncreaseDifficulty();
                    difficultyTimer = 0f;
                }
            }
        }
	}

    private void CleanUpGameObject(string tag)
    {
        GameObject[] goList = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < goList.Length; i++)
        {
            goList[i].SetActive(false);
        }
    }

    private void EndLevel()
    {
        levelEnded = true;
        jukeBoxLogic.StopPlaying();
        spawnManager.StopSpawningObjects();

        //Repeat 3 times, shoot 1 final virus at 3x speed.
        //Upon impact it will play the big explosion on the wall.
        //Then play failure sound and spawn giant data leak.
        InvokeRepeating("BreakDatabase", 0, 0.65f);
        Invoke("CreateDataLeak", 3f);
        Invoke("GameOver", 5f);

    }

    void BreakDatabase()
    {
        audioSource.PlayOneShot(breakSound);
        GameObject dbBreak = (GameObject)Instantiate(databaseBreak, new Vector2(0f, -5.75f), Quaternion.identity);
    }

    void CreateDataLeak()
    {
        CleanUpGameObject("Breach");
        CancelInvoke("BreakDatabase");
        GameObject.Find("DatabaseWall").GetComponent<SpriteRenderer>().enabled = false;
        audioSource.PlayOneShot(failureSound);
        GameObject breach = (GameObject)Instantiate(bigDataStoreBreach, new Vector2(0f, -6f), Quaternion.identity);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
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

    private void SetButtonPosition(bool flipped)
    {
        if(flipped)
        {
            colorButtons.GetComponent<Transform>().position = new Vector2(3.5f, 0f);  
        }
        else
        {
            colorButtons.GetComponent<Transform>().position = new Vector2(-3.5f, 0f);
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
