using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChromaText : MonoBehaviour 
{
    private Text uiText;
    private int currentColor;
    private List<Color> colors;

	// Use this for initialization
	void Start () 
    {
        uiText = GetComponent<Text>();
        colors.Add(Color.white);
        colors.Add(Color.red);
	}
	
	// Update is called once per frame
	void Update () 
    {
        uiText.color = Color.white;
	}
}
