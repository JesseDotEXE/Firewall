//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalData : MonoBehaviour
{
    public System.Random globalRandom;
    public Dictionary<string, float> globalVars;
    public enum GlobalTextVariable { VirusSpeed = 0, Score, Combo, MaxStreak, GameTimer };
    public enum PacketColors { Black = 0, White, Red, Green, Blue, Yellow, Magenta, Cyan }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        ResetData();
    }

    public void ResetData()
    {
        globalRandom = new System.Random();
        globalVars = new Dictionary<string, float>();

        globalVars.Add("virusSpeed", 0f);
        globalVars.Add("score", 0f);
        globalVars.Add("combo", 0f);
        globalVars.Add("maxStreak", 0f);
        globalVars.Add("gameTimer", 0f);
    }

    public void CleanUpGameObject(string tag)
    {
        GameObject[] goList = GameObject.FindGameObjectsWithTag(tag);
        for(int i = 0; i < goList.Length; i++)
        {
            goList[i].SetActive(false);
        }
    }
}
