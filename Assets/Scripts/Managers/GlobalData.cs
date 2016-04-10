using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour 
{
    public int difficulty;
    public float objMoveSpeed;
    public float spawnInterval;
    public float singlePortPercent;
    public float difficultyMod;

    //Nothing at the moment.
    //May not be needed.
    void Awake()
    {
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
