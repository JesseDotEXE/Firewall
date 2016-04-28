using UnityEngine;
using System.Collections;

public class ColorButtonLogic : MonoBehaviour 
{
    public GameObject gameMode;
    public GlobalData globalData;
    private SwipeInput swipeInput;
    public string color;

	// Use this for initialization
	void Start () 
    {
        swipeInput = gameMode.GetComponent<SwipeInput>();
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //void OnMouseDown()
    //{
    //    swipeInput.UpdateColor(color);
    //}
}
