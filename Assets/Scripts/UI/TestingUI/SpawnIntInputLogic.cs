using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnIntInputLogic : MonoBehaviour 
{
    private GlobalData globalData;
    private InputField spawnInput;
    
	// Use this for initialization
	void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        spawnInput = gameObject.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	   
	}

    public void OnValueChanged()
    {
        globalData.spawnInterval = float.Parse(spawnInput.text);
    }
}
