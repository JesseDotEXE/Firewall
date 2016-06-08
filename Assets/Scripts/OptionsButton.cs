using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour 
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
        StartCoroutine(DelayedSceneLoad());
    }

    public IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(.35f);
        SceneManager.LoadScene("OptionsMenu");
    }
}
