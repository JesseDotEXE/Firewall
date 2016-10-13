using UnityEngine;
using System.Collections;

public class LeaderboardUtil : MonoBehaviour 
{
    private GlobalData globalData;
    private GooglePlayData googlePlayData;

	// Use this for initialization
	void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        googlePlayData = GameObject.Find("GooglePlay").GetComponent<GooglePlayData>();

        if(Application.platform == RuntimePlatform.Android)
        {
            googlePlayData.PostScore((long)globalData.globalVars["score"]);
        }
	}
}
