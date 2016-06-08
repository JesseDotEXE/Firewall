using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPlayTap : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip transitionSFX;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                StartCoroutine(DelayedSceneLoad());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(transitionSFX, 1);
            StartCoroutine(DelayedSceneLoad());
        }
    }

    public IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(.35f);
        SceneManager.LoadScene("ColorPrototypeSwipe");
    }
}
