﻿using UnityEngine;
using System.Collections;

public class ShowAchievements : MonoBehaviour 
{
    private GooglePlayData googlePlayData;

    // Use this for initialization
    void Start()
    {
        googlePlayData = GameObject.Find("GooglePlay").GetComponent<GooglePlayData>();
    }

    public void OnClick()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            googlePlayData.ShowAchievements();
        }
    }
}
