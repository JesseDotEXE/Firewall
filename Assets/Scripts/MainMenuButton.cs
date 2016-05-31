using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour 
{
    GlobalData globalData;

    // Use this for initialization
    void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnClick()
    {
        globalData.ResetData();
        SceneManager.LoadScene("MainMenu");
    }
}
