using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiffiucltySliderLogic : MonoBehaviour 
{
    private GlobalData globalData;
    private Slider diffSlider;
    private DifficultyTextLogic diffText;
    
	// Use this for initialization
	void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        diffText = GameObject.Find("SelectDiffText").GetComponent<DifficultyTextLogic>();
        diffSlider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnValueChanged()
    {
        Debug.Log("Chaning to Value: " + (int)diffSlider.value);
        globalData.difficulty = (int)diffSlider.value;
        diffText.SetDifficulty((int)diffSlider.value);
    }
}
