using UnityEngine;
using System.Collections;

public class WatchAdLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    public IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(.35f);
        //Do whatever to watch AD.
    }
}
