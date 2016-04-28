using UnityEngine;
using System.Collections;

public class TouchInputManager : MonoBehaviour 
{
    public Camera camera;
    private GameMode gameMode;
    private SwipeInput swipeInput;    

	// Use this for initialization
	void Start () 
    {
        gameMode = gameObject.GetComponent<GameMode>();
        swipeInput = gameMode.GetComponent<SwipeInput>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Clicked Mouse");
    
            Vector2 start = camera.ScreenToWorldPoint(camera.transform.position);
            Vector2 end = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {
                Debug.Log("Ray Hit");
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
                {
                    swipeInput.UpdateColor((int)GlobalData.PacketColors.Red);
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
                {
                    swipeInput.UpdateColor((int)GlobalData.PacketColors.Green);
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
                {
                    swipeInput.UpdateColor((int)GlobalData.PacketColors.Blue);
                }
            }

            //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //if (Physics2D.Raycast(ray, out hit))
            //{
            //    Debug.Log("Ray Hit");
            //    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
            //    {
            //        swipeInput.UpdateColor((int)GlobalData.PacketColors.Red);
            //    }
            //    else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
            //    {
            //        swipeInput.UpdateColor((int)GlobalData.PacketColors.Green);
            //    }
            //    else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
            //    {
            //        swipeInput.UpdateColor((int)GlobalData.PacketColors.Blue);
            //    }
            //}
        }

        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
        //    {
        //        // Construct a ray from the current touch coordinates
        //        Ray ray = camera.ScreenPointToRay(Input.GetTouch(i).position);
        //        if (Physics.Raycast(ray, out hit))
        //        {
        //            Debug.Log("Button Clicked");
        //            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
        //            {
        //                swipeInput.UpdateColor((int)GlobalData.PacketColors.Red);
        //            }
        //            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
        //            {
        //                swipeInput.UpdateColor((int)GlobalData.PacketColors.Green);
        //            }
        //            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
        //            {
        //                swipeInput.UpdateColor((int)GlobalData.PacketColors.Blue);
        //            }
        //        }
        //    }
        //}
    }
}
