//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;

public class ColorButtonLogic : MonoBehaviour
{
    public GameObject gameMode;
    public GlobalData globalData;

    private SwipeInput swipeInput;

    void Start()
    {
        swipeInput = gameMode.GetComponent<SwipeInput>();
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
    }
}
