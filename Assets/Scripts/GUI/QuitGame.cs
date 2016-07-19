//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
//using UnityEditor;

public class QuitGame : MonoBehaviour
{
    void Start()
    {

    }

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
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
