//using UnityEngine;
//using System;
//using System.Collections;
//using System.Collections.Generic;

//public class OLD_SpawnManager : MonoBehaviour 
//{
//    public GameObject dataPrefab;
//    public GameObject virusPrefab;
//    public GameObject emptyPrefab;
//    public GameObject spawner1;
//    public GameObject spawner2;
//    public GameObject spawner3;
//    public GameObject spawner4;
    
//    public int difficultyLevel;
    
//    private float objSpeed;
//    private float spawnInterval;
//    private float dualPortPercent;
//    private float lockTime;
//    private int numItems;

//    private System.Random rand;
//    private PatternManager patternManager;
//    private Queue<char> spawnQueue1 = new Queue<char>();
//    private Queue<char> spawnQueue2 = new Queue<char>();
//    private Queue<char> spawnQueue3 = new Queue<char>();
//    private Queue<char> spawnQueue4 = new Queue<char>();
//    private Vector3 spawnPoint1;
//    private Vector3 spawnPoint2;
//    private Vector3 spawnPoint3;
//    private Vector3 spawnPoint4;

//    private bool stopSpawning;

//    // Use this for initialization
//    void Start () 
//    {
//        rand = new System.Random();
//        stopSpawning = false;      
//        patternManager = GetComponent<PatternManager>();
//        Debug.Log(patternManager);
//        spawnPoint1 = spawner1.GetComponent<Transform>().position;
//        spawnPoint2 = spawner2.GetComponent<Transform>().position;
//        spawnPoint3 = spawner3.GetComponent<Transform>().position;
//        spawnPoint4 = spawner4.GetComponent<Transform>().position;
//        SetDifficulty();
//        PopulateQueue();
//        Debug.Log("Done populating queue.");

//        InvokeRepeating("SpawnFromAllQueues", 3f, spawnInterval);
//    }
	
//	// Update is called once per frame
//	void Update () 
//    {     
//        if(stopSpawning)
//        {
//            spawnQueue1.Clear();
//            spawnQueue2.Clear();
//            spawnQueue3.Clear();
//            spawnQueue4.Clear();
//        }
//    }

//    //Might eventually set from a "Game" Manager class.
//    //Still needs some work but overall okay for testing now. 
//    void SetDifficulty()
//    {
//        if(difficultyLevel == 1)
//        {
//            objSpeed = 3.0f;
//            spawnInterval = 0.225f;
//            lockTime = 0f;
//            dualPortPercent = 10.0f;
//            numItems = 100;
//        }
//        else if(difficultyLevel == 2)
//        {
//            objSpeed = 4.5f;
//            spawnInterval = 0.1875f;
//            lockTime = 0.5f;
//            dualPortPercent = 20.0f;
//            numItems = 100;
//        }
//        else if(difficultyLevel == 3)
//        {
//            objSpeed = 6.0f;
//            spawnInterval = 0.15f;
//            lockTime = 1f;
//            dualPortPercent = 35.0f;
//            numItems = 100;
//        }
//    }

//    void SpawnFromAllQueues()
//    {
//        SpawnFromQueue(objSpeed, ref spawnQueue1, spawnPoint1);
//        SpawnFromQueue(objSpeed, ref spawnQueue2, spawnPoint2);
//        SpawnFromQueue(objSpeed, ref spawnQueue3, spawnPoint3);
//        SpawnFromQueue(objSpeed, ref spawnQueue4, spawnPoint4);
//    }

//    void PopulateQueue()
//    {
//        for (int i = 0; i < numItems; i++)
//        {
//            AddToQueue();
//        }
//    }

//    //Might want to see if I can refactor this method to be smaller.
//    void AddToQueue()
//    {
//        //Always reassign to help diversify randomness.
//        //rand = new System.Random();
        
//        bool singlePort = true;
//        int singleCheck = rand.Next(100);
//        if(singleCheck < dualPortPercent)
//        {
//            singlePort = false;
//        }

//        //singlePort = true;

//        if(singlePort)
//        {
//            //Fill only 1 queue with real data.
//            int patternNum = rand.Next(80);
//            //Debug.Log("pattern num: " + patternNum);
//            string selectedPattern = patternManager.GetPattern(patternNum);
//            //Debug.Log("selected pattern: " + selectedPattern);
//            int portNum = rand.Next(4);            
            
//            if(portNum == 0)
//            {
//                //Add pattern to queue1.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern, ref spawnQueue1);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue2);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue3);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue4);
//            }
//            else if (portNum == 1)
//            {
//                //Add pattern to queue2.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue1);
//                ParseStringAndAddToQueue(selectedPattern, ref spawnQueue2);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue3);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue4);
//            }
//            else if (portNum == 2)
//            {
//                //Add pattern to queue3.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue1);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue2);
//                ParseStringAndAddToQueue(selectedPattern, ref spawnQueue3);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue4);
//            }
//            else if (portNum == 3)
//            {
//                //Add pattern to queue4.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue1);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue2);
//                ParseStringAndAddToQueue("XXXX", ref spawnQueue3);
//                ParseStringAndAddToQueue(selectedPattern, ref spawnQueue4);
//            }

//        }
//        else
//        {
//            //Fill 2 queues with real data.
//            //Fill only 1 queue with real data.
//            int patternNum1 = rand.Next(80);
//            int patternNum2 = rand.Next(80);
//            int portNum1 = rand.Next(4);
//            int portNum2 = rand.Next(4);
//            bool[] portsFilled = new bool[4];  
//            string selectedPattern1 = patternManager.GetPattern(patternNum1);
//            string selectedPattern2 = patternManager.GetPattern(patternNum2);

//            while (portNum1 == portNum2)
//            {
//                //Have to modify so its never the same.
//                portNum2 = rand.Next(4);
//            }

//            for (int i = 0; i < portsFilled.Length; i++)
//            {
//                portsFilled[i] = false;
//            }

//           //Fill first port.
//            if (portNum1 == 0)
//            {
//                //Add pattern to queue1.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern1, ref spawnQueue1);
//            }
//            else if (portNum1 == 1)
//            {
//                //Add pattern to queue2.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern1, ref spawnQueue2);
//            }
//            else if (portNum1 == 2)
//            {
//                //Add pattern to queue2.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern1, ref spawnQueue3);
//            }
//            else if (portNum1 == 3)
//            {
//                //Add pattern to queue3.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern1, ref spawnQueue4);
//            }
//            portsFilled[portNum1] = true;

//            //Fill second port.
//            if (portNum2 == 0)
//            {
//                //Add pattern to queue1.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern2, ref spawnQueue1);
//            }
//            else if (portNum2 == 1)
//            {
//                //Add pattern to queue2.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern2, ref spawnQueue2);
//            }
//            else if (portNum2 == 2)
//            {
//                //Add pattern to queue2.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern2, ref spawnQueue3);
//            }
//            else if (portNum2== 3)
//            {
//                //Add pattern to queue3.
//                //Fill others with blanks.
//                ParseStringAndAddToQueue(selectedPattern2, ref spawnQueue4);
//            }
//            portsFilled[portNum2] = true;

//            for(int i = 0; i < portsFilled.Length; i++)
//            {
//                if(portsFilled[i] == false)
//                {
//                    if (i == 0)
//                        ParseStringAndAddToQueue("XXXX", ref spawnQueue1);
//                    else if (i == 1)
//                        ParseStringAndAddToQueue("XXXX", ref spawnQueue2);
//                    else if (i == 2)
//                        ParseStringAndAddToQueue("XXXX", ref spawnQueue3);
//                    else if (i == 3)
//                        ParseStringAndAddToQueue("XXXX", ref spawnQueue4);
//                }
//            }
//        }
//    }

//    void ParseStringAndAddToQueue(string pattern, ref Queue<char> queue)
//    {
//        for(int i = 0; i < pattern.Length; i++)
//        {            
//            queue.Enqueue(pattern[i]);            
//        }
//    }

//    void SpawnFromQueue(float speed, ref Queue<char> queue, Vector3 spawnPoint)
//    {
//        if (queue.Count > 0 && !stopSpawning)
//        {
//            char c = queue.Dequeue();
//            if (c.Equals('X'))
//            {
//                GameObject newObj = (GameObject)Instantiate(emptyPrefab, spawnPoint, Quaternion.identity);
//                DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
//                downMove.speed = speed;
//            }
//            else if (c.Equals('D'))
//            {
//                GameObject newObj = (GameObject)Instantiate(dataPrefab, spawnPoint, Quaternion.identity);
//                DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
//                downMove.speed = speed;
//            }
//            else if (c.Equals('V'))
//            {
//                GameObject newObj = (GameObject)Instantiate(virusPrefab, spawnPoint, Quaternion.identity);
//                DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
//                downMove.speed = speed;
//            }
//        }
//    } 
    
//    public void StopSpawningObjects()
//    {
//        stopSpawning = true;
//    }   
//}
