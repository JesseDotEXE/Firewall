//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    private int lives;
    private int score;
    public int pointsPerVirus;
    private int combo;
    public int comboCount;

    void Awake() 
    {
        
    }

	// Use this for initialization
	void Start () 
    {
        lives = 3;
        pointsPerVirus = 1;
        score = 0;
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

    public void AddPoints() 
    {
        score = score + (pointsPerVirus * combo);
        comboCount++;
        if (comboCount > 1) 
        { 
            IncreaseCombo(); 
        }
    }

    public void IncreaseCombo() 
    {
        combo++;
        ResetComboCount();
    }

    public void ResetCombo() 
    {
        combo = 1;
    }

    public void ResetComboCount()
    {
        comboCount = 1;
    }
}
