﻿using UnityEngine;
using System.Collections;

public class StartButtonLogic : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnClick()
    {
        Application.LoadLevel("ColorPrototype");
    }
}
