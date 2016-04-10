using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyTextLogic : MonoBehaviour 
{
    private int difficulty;
    private Text diffText;

    // Use this for initialization
    void Start () 
    {
        diffText = gameObject.GetComponent<Text>();
        difficulty = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        diffText.text = "Difficulty: " + difficulty;
	}

    public void SetDifficulty(int newDiff)
    {
        difficulty = newDiff;
    }
}
