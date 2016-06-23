using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTextLogic : MonoBehaviour 
{
    public GameMode gameMode;
    private ScoreManager scoreManager;
    private Text livesText;
    private int combo;

    // Use this for initialization
    void Start()
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        scoreManager = gameMode.GetScoreManager();
        livesText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "LIves: " + scoreManager.GetLives();
    }
}
