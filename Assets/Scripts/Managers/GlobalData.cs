using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour 
{
    public int difficulty;
    public float objMoveSpeed;
    public float spawnInterval;
    public float singlePortPercent;

    //Nothing at the moment.
    //May not be needed.
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
