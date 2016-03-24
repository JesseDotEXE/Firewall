using UnityEngine;
using System.Collections;

public class ScannerToggle : MonoBehaviour 
{
    private bool portIsOpen {get; set;}
    public bool portIsLocked { get; set;}

    private SpriteRenderer scannerRenderer;
    private BoxCollider2D scannerCollider;

	// Use this for initialization
	void Start () 
    {
        portIsOpen = true;
        scannerRenderer = GetComponent<SpriteRenderer>();
        scannerCollider = GetComponent<BoxCollider2D>();        
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void CloseScanner() 
    {
        if (!portIsLocked)
        {
            //Debug.Log("Closing Port");
            scannerRenderer.enabled = true;
            scannerCollider.enabled = true;
            portIsOpen = false;
        }
    }

    public void OpenScanner()
    {
        //Debug.Log("Opening Port");
        scannerRenderer.enabled = false;
        scannerCollider.enabled = false;
        portIsOpen = true;
    }
    
    void OnMouseDown()
    {
        //If layer if on then turn off.
        if(gameObject.layer == LayerMask.NameToLayer("SecurityRed"))
        {
            scannerRenderer.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("SecurityRedOff");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityGreen"))
        {
            scannerRenderer.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("SecurityGreenOff");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityBlue"))
        {
            scannerRenderer.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("SecurityBlueOff");
        }

        //If the layer is already off, turn back on.
        else if (gameObject.layer == LayerMask.NameToLayer("SecurityRedOff"))
        {
            scannerRenderer.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("SecurityRed");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityGreenOff"))
        {
            scannerRenderer.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("SecurityGreen");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityBlueOff"))
        {
            scannerRenderer.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("SecurityBlue");
        }        
    }
}
