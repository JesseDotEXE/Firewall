using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListenForTap : MonoBehaviour
{
    private Image fadeScreen;
    public float fadeSpeed = 2f;
    private AudioSource audioSource;
    public AudioClip transitionSFX;

    public string sceneToLoad;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                audioSource.PlayOneShot(transitionSFX, 1);
                InvokeRepeating("FadeOut", 0f, 0.02f);
                Invoke("DelayedSceneLoad", fadeSpeed);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(transitionSFX, 1);
            InvokeRepeating("FadeOut", 0f, 0.02f);
            Invoke("DelayedSceneLoad", fadeSpeed);
        }
    }

    public void DelayedSceneLoad()
    {
        //yield return new WaitForSeconds(3f);
        CancelInvoke("FadeOut");
        SceneManager.LoadScene(sceneToLoad);
    }

    public void FadeOut()
    {
        fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
