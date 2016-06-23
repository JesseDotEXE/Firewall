using UnityEngine;
using System.Collections;

public class SwipeCollision : MonoBehaviour 
{
    private GlobalData globalData;

    int swipeColor;

	// Use this for initialization
	void Start () 
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        swipeColor = (int)GlobalData.PacketColors.Black;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("FallingObject"))
        {
            Debug.Log("Hitting FallingObject from SwipeCollision.");
            coll.transform.gameObject.GetComponent<VirusLogic>().CheckColor(swipeColor);
        }
    }

    public void SetSwipeColor(int newColor)
    {
        swipeColor = newColor;
    }

    public int GetSwipeColor()
    {
        return swipeColor;
    }
}
