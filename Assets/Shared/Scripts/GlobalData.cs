using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour 
{
    public int difficulty;
    public float objMoveSpeed;
    public float spawnInterval;
    public float singlePortPercent;
    public float difficultyMod;
    public bool soundOn;
    public bool buttonFlip;
    public System.Random globRandom;
    public int finalScore;

    public enum PacketColors { Black = 0, White, Red, Green, Blue, Yellow, Magenta, Cyan }

    //Nothing at the moment.
    //May not be needed.
    void Awake()
    {
        globRandom = new System.Random();
        soundOn = true;
        buttonFlip = false;
        finalScore = 0;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        if(difficulty == 1)
        {
            objMoveSpeed = 0f;
        }
        else if(difficulty == 2)
        {
            objMoveSpeed = 0f;
        }
    }

    public void ResetData()
    {
        globRandom = new System.Random();
        finalScore = 0;
        DontDestroyOnLoad(transform.gameObject);
    }
}
