using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour 
{
    public float destroyDelay;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, destroyDelay);
    }
}
