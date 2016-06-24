//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEditor;

public class QuitGame : MonoBehaviour 
{
    //========== Unity Methods Begin ==========//
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
    //========== Unity Methods End ==========//

    public IEnumerator DelayedQuit()
    {
        yield return new WaitForSeconds(.35f);
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
