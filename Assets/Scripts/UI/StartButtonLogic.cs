using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonLogic : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        //audioSource = GameObject.Find("GUI").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnClick()
    {
        //audioSource.PlayOneShot(buttonClick, 1);
        StartCoroutine(DelayedSceneLoad());
    }

    public IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(3.25f);
        SceneManager.LoadScene("HowToPlay");
    }
}
