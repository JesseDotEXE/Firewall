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
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
