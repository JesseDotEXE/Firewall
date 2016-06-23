using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerTextLogic : MonoBehaviour
{
    private GameMode gameMode;
    private Text timerText;    

    private float time;

    void Start()
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        timerText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        time = gameMode.GetGameTimer();
        timerText.text = "Timer:" + (int)time;
    }
}
