using UnityEngine;
using System.Collections;

public class DownwardMovment : MonoBehaviour 
{
    public float speed;

	// Use this for initialization
	void Start () 
    {
        //Will eventually set private.
        //speed = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        float step = speed * Time.deltaTime;
        Vector3 pos = this.gameObject.transform.position;
        pos.y -= 10;

        transform.position = Vector3.MoveTowards(transform.position, pos, step);
    }
}
