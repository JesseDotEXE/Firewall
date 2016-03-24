using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboTextLogic : MonoBehaviour 
{
    public GameMode gameMode;

    private ScoreManager scoreManager;
    private Text comboText;

    // Use this for initialization
    void Start()
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        scoreManager = gameMode.GetScoreManager();
        comboText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {        
        comboText.text = "Combo: " + scoreManager.GetCombo();
    }
}
