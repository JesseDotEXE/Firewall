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
        //time += Time.deltaTime;

        //var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        //var seconds = time % 60;//Use the euclidean division for the seconds.
        //var fraction = (time * 100) % 100;
        time = gameMode.GetGameTimer();
        float seconds = time % 60;

        //update the label value
        timerText.text = "Timer:" + seconds.ToString() ;//string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
    }
}
