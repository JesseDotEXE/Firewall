//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class DisplayText : MonoBehaviour
{
    public GlobalData.GlobalTextVariable variableToDisplay;

    private GlobalData globalData;
    private Text uiText;
    private string textToDisplay;
    private float time;
    
    void Start()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        uiText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if(variableToDisplay == GlobalData.GlobalTextVariable.VirusSpeed)
        {
            textToDisplay = "Virus Speed: " + globalData.globalVars["virusSpeed"].ToString();
        }   
        else if(variableToDisplay == GlobalData.GlobalTextVariable.Score)
        {
            textToDisplay = "Score: " + globalData.globalVars["score"].ToString();
        }
        else if(variableToDisplay == GlobalData.GlobalTextVariable.Combo)
        {
            textToDisplay = "Combo: " + globalData.globalVars["combo"].ToString();
        }
        else if(variableToDisplay == GlobalData.GlobalTextVariable.MaxStreak)
        {
            textToDisplay = "Max Streak: " + globalData.globalVars["maxStreak"].ToString();
        }
        else if(variableToDisplay == GlobalData.GlobalTextVariable.GameTimer)
        {
            textToDisplay = "Timer: " + (int)globalData.globalVars["gameTimer"];
        }

        uiText.text = textToDisplay;
    }
}