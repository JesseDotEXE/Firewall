using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListenForTap : MonoBehaviour
{
    public AudioClip transitionSFX;

    private SceneChange sceneChange;
    private AudioSource audioSource;

    void Start()
    {
        sceneChange = GetComponent<SceneChange>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                audioSource.PlayOneShot(transitionSFX, 1);
                sceneChange.ChangeScene();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(transitionSFX, 1);
            sceneChange.ChangeScene();
        }
    }
}
