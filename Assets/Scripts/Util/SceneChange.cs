//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public float fadeSpeed;
    public string sceneToLoad;

    private Image fadeScreen;

    void Start()
    {
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Image>();
    }

    public void OnClick()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        InvokeRepeating("FadeOut", 0f, 0.005f);
        Invoke("DelayedSceneLoad", fadeSpeed);
    }

    private void FadeOut()
    {
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public void DelayedSceneLoad()
    {
        CancelInvoke("FadeOut");
        SceneManager.LoadScene(sceneToLoad);
    }
}
