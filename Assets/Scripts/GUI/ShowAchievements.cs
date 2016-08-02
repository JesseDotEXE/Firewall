using UnityEngine;
using System.Collections;

public class ShowAchievements : MonoBehaviour 
{
    private GooglePlayData googlePlayData;

    // Use this for initialization
    void Start()
    {
        googlePlayData = GameObject.Find("GooglePlayData").GetComponent<GooglePlayData>();
    }

    public void OnClick()
    {
        googlePlayData.ShowAchievements();
    }
}
