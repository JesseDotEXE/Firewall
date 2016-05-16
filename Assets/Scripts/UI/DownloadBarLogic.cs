using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownloadBarLogic : MonoBehaviour 
{
    private GameMode gameMode;

    Vector2 pos = new Vector2(20,40);
    Vector2 size = new Vector2(60,20);
    float barDisplay = 0f;

    Image fillImg;
    float timeAmt = 10;
    float time;


    // Use this for initialization
    void Start () 
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();

        fillImg = this.GetComponent<Image>();
    }

    void Update()
    {
        fillImg.fillAmount = (1 - (gameMode.GetGameTimer() / 90)) + 0.5f;
    }
}
