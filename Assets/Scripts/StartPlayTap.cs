using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPlayTap : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("ColorPrototypeSwipe");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ColorPrototypeSwipe");
        }
    }
}
