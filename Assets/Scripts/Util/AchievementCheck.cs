using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AchievementCheck : MonoBehaviour 
{
    void Awake() 
    {
        GooglePlayData googlePlayData = GameObject.Find("GooglePlay").GetComponent<GooglePlayData>();

        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Credits")
        {
            googlePlayData.AchievementUnlock(GooglePlayData.ACHIEVEMENT_INITIALIZE_CREDITS);
        }
    }
}
