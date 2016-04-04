using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour 
{
    public int difficulty;

    //Nothing at the moment.
    //May not be needed.
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
