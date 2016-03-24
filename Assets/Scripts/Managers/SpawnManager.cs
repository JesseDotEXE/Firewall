using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour 
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject dataPacket;
    public int difficultyLevel;

    private List<int> spawnList; 
    private float objSpeed;
    private float spawnInterval;
    private float singlePortPercent;
    private float doublePortPercent;
    private float triplePortPercent;
    private System.Random rand;
    private Vector3 spawnPoint1;
    private Vector3 spawnPoint2;
    private Vector3 spawnPoint3;
    private Vector3 spawnPoint4;
    private bool stopSpawning;

    // Use this for initialization
    void Start () 
    {
        stopSpawning = false;
        spawnList = new List<int>();
        rand = new System.Random();
        spawnPoint1 = spawner1.GetComponent<Transform>().position;
        spawnPoint2 = spawner2.GetComponent<Transform>().position;
        spawnPoint3 = spawner3.GetComponent<Transform>().position;
        spawnPoint4 = spawner4.GetComponent<Transform>().position;
        SetDifficulty();
        PopulateList(30);
        InvokeRepeating("SpawnObject", 3f, spawnInterval);
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    //Might eventually set from a "Game" Manager class.
    //Still needs some work but overall okay for testing now. 
    void SetDifficulty() 
    {
        if (difficultyLevel == 1) 
        {
            objSpeed = 2.5f;
            spawnInterval = 2.5f;
            singlePortPercent = 90.0f;
            doublePortPercent = 100.0f;
        } 
        else if (difficultyLevel == 2) 
        {
            objSpeed = 3.0f;
            spawnInterval = 1.5f;
            singlePortPercent = 70.0f;
            doublePortPercent = 100.0f;
        } 
        else if (difficultyLevel == 3) 
        {
            objSpeed = 4.0f;
            spawnInterval = 1.0f;
            singlePortPercent = 50.0f;
            doublePortPercent = 100.0f;
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
        int port = rand.Next(4) + 1;
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
            if (portToUse == 4) { SpawnDataPacket(spawnPoint4); }

            spawnList.RemoveAt(0);
        } 
        else if(numPorts >= singlePortPercent && numPorts < doublePortPercent) 
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
                    if (portToUse1 == 1) { portToUse2 = 4; }
                    else portToUse2--;
                }
                else
                {
                    if (portToUse1 == 4) { portToUse2 = 1; }
                    else portToUse2++;
                }
            }

            if (portToUse1 == 1) { SpawnDataPacket(spawnPoint1); }
            if (portToUse1 == 2) { SpawnDataPacket(spawnPoint2); }
            if (portToUse1 == 3) { SpawnDataPacket(spawnPoint3); }
            if (portToUse1 == 4) { SpawnDataPacket(spawnPoint4); }

            if (portToUse2 == 1) { SpawnDataPacket(spawnPoint1); }
            if (portToUse2 == 2) { SpawnDataPacket(spawnPoint2); }
            if (portToUse2 == 3) { SpawnDataPacket(spawnPoint3); }
            if (portToUse2 == 4) { SpawnDataPacket(spawnPoint4); }

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
