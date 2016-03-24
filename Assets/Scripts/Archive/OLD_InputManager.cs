//using UnityEngine;
//using System.Collections;

//public class OLD_InputManager : MonoBehaviour 
//{
//    public GameObject port1;
//    public GameObject port2;
//    public GameObject port3;
//    public GameObject port4;

//    private PortOpenClose portOC1;
//    private PortOpenClose portOC2;
//    private PortOpenClose portOC3;
//    private PortOpenClose portOC4;

//    // Use this for initialization
//    void Start () 
//    {
//        portOC1 = port1.GetComponent<PortOpenClose>();
//        portOC2 = port2.GetComponent<PortOpenClose>();
//        portOC3 = port3.GetComponent<PortOpenClose>();
//        portOC4 = port4.GetComponent<PortOpenClose>();
//    }
	
//	// Update is called once per frame
//	void Update () 
//    {
//	    if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.U))
//            portOC1.ClosePort();
//        else
//            portOC1.OpenPort();

//        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.I))
//            portOC2.ClosePort();
//        else
//            portOC2.OpenPort();

//        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.O))
//            portOC3.ClosePort();
//        else
//            portOC3.OpenPort();

//        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.P))
//            portOC4.ClosePort();
//        else
//            portOC4.OpenPort();
//    }
//}
