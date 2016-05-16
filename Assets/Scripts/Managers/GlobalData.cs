using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour 
{
    public int difficulty;
    public float objMoveSpeed;
    public float spawnInterval;
    public float singlePortPercent;
    public float difficultyMod;
    public bool buttonFlip;
    public System.Random globRandom;

    public enum PacketColors { Black = 0, White, Red, Green, Blue, Yellow, Magenta, Cyan }

    //Nothing at the moment.
    //May not be needed.
    void Awake()
    {
        globRandom = new System.Random();
        buttonFlip = false;
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
}
