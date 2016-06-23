using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlayButton : MonoBehaviour 
{
    private Image fadeScreen;
    public float fadeSpeed = 2f;
    public string sceneToLoad = "HowToPlay";

    // Use this for initialization
    void Start()
    {
        //audioSource = GameObject.Find("GUI").GetComponent<AudioSource>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        InvokeRepeating("FadeOut", 0f, 0.02f);
        Invoke("DelayedSceneLoad", fadeSpeed);
    }

    public void FadeOut()
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
