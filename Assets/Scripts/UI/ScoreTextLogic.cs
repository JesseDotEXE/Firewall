using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextLogic : MonoBehaviour
{
    public GameMode gameMode;
    private ScoreManager scoreManager;
    private Text scoreText;
    private int score;

    // Use this for initialization
    void Start()
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        scoreManager = gameMode.GetScoreManager();
        scoreText = gameObject.GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreManager.GetScore();
        scoreText.text = "Score: " + score.ToString();
    }
}
