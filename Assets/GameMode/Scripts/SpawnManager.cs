//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpawnManager : MonoBehaviour 
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    // public GameObject spawner4;
    public GameObject dataPacket;

    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    private GameMode gameMode;
    private List<int> spawnList; 
    private float objSpeed;
    private float spawnInterval;
    private float singlePortPercent;
    //private float doublePortPercent;
    //private float triplePortPercent;
    private System.Random rand;
    private int numSpawnPoints;
    private Vector3 spawnPoint1;
    private Vector3 spawnPoint2;
    private Vector3 spawnPoint3;
    //private Vector3 spawnPoint4;
    private bool stopSpawning;

    private GlobalData globalData;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        gameMode = GetComponent<GameMode>();
        stopSpawning = false;
        spawnList = new List<int>();
        rand = new System.Random();
        numSpawnPoints = 3;
        spawnPoint1 = spawner1.GetComponent<Transform>().position;
        spawnPoint2 = spawner2.GetComponent<Transform>().position;
        spawnPoint3 = spawner3.GetComponent<Transform>().position;
        UpdateDifficulty();
        PopulateList(30);
        InvokeRepeating("SpawnObject", 3f, spawnInterval);
    }

    public void UpdateDifficulty()
    {
        objSpeed = gameMode.GetCurrentObjSpeed();
        spawnInterval = gameMode.GetCurrentSpawnInterval();
        singlePortPercent = gameMode.GetCurrentSinglePortPercentage();

        Debug.Log("Increasing Game Difficulty-----------------");
        Debug.Log("Object Speed: " + objSpeed);
        Debug.Log("Spawn Interval: " + spawnInterval);
        Debug.Log("Single Port Percentage: " + singlePortPercent);

    }

    // Update is called once per frame
    void Update () 
    {
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    void PopulateList(int count) 
    {
        for (int i = 0; i < count; i++)
        {
            AddToList();
        }
    }

    void AddToList() 
    {
        int port = rand.Next(numSpawnPoints) + 1;
        spawnList.Add(port);
    }

    void SpawnObject() 
    {
        if(spawnList.Count <= 3) 
        {
            PopulateList(10);
        }

        SpawnDataPacket();
        spawnList.RemoveAt(0);
    }

    GameObject SpawnDataPacket()
    {
        //Between -2.35 and 3.35
        float spawnX = UnityEngine.Random.Range(-2.35f, 3.35f);
        if (globalData.buttonFlip)
        {
            spawnX = UnityEngine.Random.Range(-3.35f, 2.35f);
        }
        float spawnY = 7.5f;

        GameObject newObj = null;
        newObj = (GameObject)Instantiate(dataPacket, new Vector2(spawnX, spawnY), Quaternion.identity);
        //newObj = (GameObject)Instantiate(dataPacket, spawnPoint, Quaternion.identity);

        SpriteRenderer spr = newObj.GetComponent<SpriteRenderer>();

        int spriteNum = rand.Next(3, 10);
        if(spriteNum == 3)
        {
            spr.sprite = three;
        }
        else if (spriteNum == 4)
        {
            spr.sprite = four;
        }
        else if (spriteNum == 4)
        {
            spr.sprite = four;
        }
        else if (spriteNum == 5)
        {
            spr.sprite = five;
        }
        else if (spriteNum == 6)
        {
            spr.sprite = six;
        }
        else if (spriteNum == 7)
        {
            spr.sprite = seven;
        }
        else if (spriteNum == 8)
        {
            spr.sprite = eight;
        }
       else if (spriteNum == 9)
        {
            spr.sprite = nine;
        }

        DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
        downMove.speed = objSpeed;      

        ParticleSystem particleSys = newObj.GetComponent<ParticleSystem>();
        particleSys.startSpeed = objSpeed * 2;

        VirusLogic dpl = newObj.GetComponent<VirusLogic>();
        //Ignore 0 because it is black in our enum.
        int color = rand.Next(1, 8);
        dpl.SetPacketColor(color);
        dpl.SetSides(spriteNum);      

        return newObj;
    }

    public void StopSpawningObjects()
    {
        stopSpawning = true;
    }
}
