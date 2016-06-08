using UnityEngine;
using System.Collections;
using UnityEditor;

public class QuitButton : MonoBehaviour 
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        StartCoroutine(DelayedQuit());
    }

    public IEnumerator DelayedQuit()
    {
        yield return new WaitForSeconds(.35f);
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
