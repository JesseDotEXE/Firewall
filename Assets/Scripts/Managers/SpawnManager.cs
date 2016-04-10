﻿using UnityEngine;
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

    void Awake()
    {

    }

    // Use this for initialization
    void Start () 
    {
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

        int numPorts = rand.Next(100) + 1;
        if(numPorts < singlePortPercent) 
        {
            //Spawn into 1 queue.
            int portToUse = spawnList[0];
            
            if (portToUse == 1) { SpawnDataPacket(spawnPoint1); }
            if (portToUse == 2) { SpawnDataPacket(spawnPoint2); }
            if (portToUse == 3) { SpawnDataPacket(spawnPoint3); }

            spawnList.RemoveAt(0);
        } 
        else 
        {
            //Spawn into 2 queues.
            int portToUse1 = spawnList[0];
            int portToUse2 = spawnList[1];

            //Fix same port collision.
            if (portToUse1 == portToUse2)
            {
                int plusOrMin = rand.Next(2);
                if (plusOrMin == 0)
                {
                    if (portToUse1 == 1) { portToUse2 = 3; }
                    else portToUse2--;
                }
                else
                {
                    if (portToUse1 == 3) { portToUse2 = 1; }
                    else portToUse2++;
                }
            }

            if (portToUse1 == 1) { SpawnDataPacket(spawnPoint1); }
            if (portToUse1 == 2) { SpawnDataPacket(spawnPoint2); }
            if (portToUse1 == 3) { SpawnDataPacket(spawnPoint3); }

            if (portToUse2 == 1) { SpawnDataPacket(spawnPoint1); }
            if (portToUse2 == 2) { SpawnDataPacket(spawnPoint2); }
            if (portToUse2 == 3) { SpawnDataPacket(spawnPoint3); }

            spawnList.RemoveAt(0);
            spawnList.RemoveAt(0);
        } 
    }

    void SpawnDataPacket(Vector3 spawnPoint)
    {
        GameObject newObj = null;
        newObj = (GameObject)Instantiate(dataPacket, spawnPoint, Quaternion.identity);

        DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
        downMove.speed = objSpeed;

        DataPacketLogic dpl = newObj.GetComponent<DataPacketLogic>();
        int color = rand.Next(1, 7);
        dpl.SetPacketColor(color);
    }

    public void StopSpawningObjects()
    {
        stopSpawning = true;
    }
}
