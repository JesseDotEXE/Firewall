using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    private int lives;
    private int score;
    private int combo;
    private int comboCount;

    void Awake() 
    {
        
    }

	// Use this for initialization
	void Start () 
    {
        lives = 3;
        combo = 1;
        comboCount = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public int GetLives() 
    {
        return lives;
    }

    public int GetScore() 
    {
        return score;
    }

    public int GetCombo() 
    {
        return combo;
    }

    public void DecreaseLives() 
    {
        lives--;
    }

    public void AddPoints(int points) 
    {
        score = score + (points * combo);
        comboCount++;
        if (comboCount >= 10) 
        { 
            IncreaseCombo(); 
        }
    }

    public void IncreaseCombo() 
    {
        combo++;
        ResetCombo();
    }

    public void ResetCombo() 
    {
        combo = 0;
    }
}
