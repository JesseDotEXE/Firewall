using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonsSideToggle : MonoBehaviour 
{
    public Text buttonSideText;
    private GlobalData globalData;

	// Use this for initialization
	void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (globalData.buttonFlip)
        {
            buttonSideText.text = "RIGHT";
        }
        else
        {
            buttonSideText.text = "LEFT";
        }
	}

    public void OnClick()
    {
        globalData.buttonFlip = !globalData.buttonFlip;
    }
}
