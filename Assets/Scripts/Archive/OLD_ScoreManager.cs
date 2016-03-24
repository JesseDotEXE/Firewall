//using UnityEngine;
//using System;
//using System.Collections;

//public class OLD_ScoreManager : MonoBehaviour 
//{
//    private int score;
//    private int combo;
//    private int connectionMeter;
//    private int corruptionMeter;
//    private PortOpenClose poc = null;

//    private System.Random rand;
    
//    //Eventually move to corruption manager
//    public GameObject port1;
//    public GameObject port2;
//    public GameObject port3;
//    public GameObject port4;

//	// Use this for initialization
//	void Awake () 
//    {
//        rand = new System.Random();
//        score = 0;
//        combo = 1;
//        connectionMeter = 0;
//        corruptionMeter = 0;
//	}
	
//	// Update is called once per frame
//	void Update () 
//    {
//        //PrintScore();
//	}

//    public void AddPoints()
//    {
//        score += (score * combo);
//    }

//    public int GetPoints()
//    {
//        return score;
//    }

//    public void AddCombo()
//    {
//        combo += 1;
//    }

//    public int GetCombo()
//    {
//        return combo;
//    }

//    public void ResetCombo()
//    {
//        combo = 1;
//    }

//    public void AddConnection()
//    {
//        connectionMeter += 1;
//    }

//    public int GetConnection()
//    {
//        return connectionMeter;
//    }

//    public void AddCorruption()
//    {
//        corruptionMeter += 1;

//        if(corruptionMeter % 2 == 0)
//        {
//            StartCoroutine("LockPort");
//        }
//    }

//    public int GetCorruption()
//    {
//        return corruptionMeter;
//    }

//    //Eventually move to corruption manager
//    public IEnumerator LockPort()
//    {
//        int portToLock = rand.Next(3);        

//        if(portToLock == 0)
//        {
//            poc = GameObject.Find("Port1").GetComponent<PortOpenClose>();
//        }
//        else if(portToLock == 1)
//        {
//            poc = GameObject.Find("Port2").GetComponent<PortOpenClose>();
//        }
//        else if(portToLock == 2)
//        {
//            poc = GameObject.Find("Port3").GetComponent<PortOpenClose>();
//        }
//        else if(portToLock == 3)
//        {
//            poc = GameObject.Find("Port4").GetComponent<PortOpenClose>();
//        }

//        Debug.Log("Locking Port");
//        poc.portIsLocked = true;
//        yield return new WaitForSeconds(2f);
//        poc.portIsLocked = false;
//        Debug.Log("UnLocking Port");
//        Debug.Log("Done with Coroutin");
//    }

//    public void PrintScore()
//    {
//        Debug.Log("Begin Score Print");
//        Debug.Log("Score = " + score);
//        Debug.Log("Combo = " + combo);
//        Debug.Log("ConnectionMeter = " + connectionMeter.ToString());
//        Debug.Log("CorruptionMeter = " + corruptionMeter.ToString());
//        Debug.Log("End Score Print");
//    }
//}
