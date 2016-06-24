//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour 
{
    private Image fadeScreen;
    public float fadeSpeed; //Was 2f
    public string sceneToLoad;

    //========== Unity Methods Begin ==========//
    void Start()
    {
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Image>();
    }
    
    void Update()
    {

    }

    public void OnClick()
    {
        ChangeScene();
    }
    //========== Unity Methods End ==========//

    public void ChangeScene()
    {
        InvokeRepeating("FadeOut", 0f, 0.02f);
        Invoke("DelayedSceneLoad", fadeSpeed);
    }

    private void FadeOut()
    {
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public void DelayedSceneLoad()
    {
        //yield return new WaitForSeconds(3f);
        CancelInvoke("FadeOut");
        SceneManager.LoadScene(sceneToLoad);
    }
}
