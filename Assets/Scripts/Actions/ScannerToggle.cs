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
        CheckScanners();
    }

    void CheckScanners()
    {
        //If layer if on then turn off.
        if (gameObject.layer == LayerMask.NameToLayer("SecurityRed"))
        {
            ToggleScanner(false, "SecurityRedOff");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityGreen"))
        {
            ToggleScanner(false, "SecurityGreenOff");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityBlue"))
        {
            ToggleScanner(false, "SecurityBlueOff");
        }

        //If the layer is already off, turn back on.
        else if (gameObject.layer == LayerMask.NameToLayer("SecurityRedOff"))
        {
            ToggleScanner(true, "SecurityRed");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityGreenOff"))
        {
            ToggleScanner(true, "SecurityGreen");
        }

        else if (gameObject.layer == LayerMask.NameToLayer("SecurityBlueOff"))
        {
            ToggleScanner(true, "SecurityBlue");
        }
    }

    void ToggleScanner(bool renderOn, string layerName)
    {
        scannerRenderer.enabled = renderOn;
        gameObject.layer = LayerMask.NameToLayer(layerName);
    }
}
