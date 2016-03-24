using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour 
{
    private GlobalData globalData;
    private ScoreManager scoreManager;
    private SpawnManager spawnManager;
    private float timer;

	// Use this for initialization
	void Awake () 
    {
        scoreManager = GetComponent<ScoreManager>();
        spawnManager = GetComponent<SpawnManager>();
        globalData = GetComponent<GlobalData>();
        timer = 0;       
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if(timer >= 60.0f || scoreManager.GetLives() <= 0)
        {
            //End spawning
            spawnManager.StopSpawningObjects();
        }
	}

    public float GetTimer()
    {
        return timer;
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
}
