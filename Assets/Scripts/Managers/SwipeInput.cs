using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour 
{
    public Camera camera;
    private LineRenderer lineRenderer;
    bool movingMouse = false;
    private Color white = Color.white;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color blue = Color.blue;
    private Color yellow = Color.yellow;
    private Color cyan = Color.cyan;
    private Color magenta = Color.magenta;
    private bool redOn = false;
    private bool greenOn = false;
    private bool blueOn = false;
    private bool swipeActive = false;
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;
    public Sprite offButton;
    public Sprite onButton;
    Vector2 lineStart;
    Vector2 lineEnd;
    
    private int color; //0 = red, 1 = green, 2 = blue

    // Use this for initialization
    void Start () 
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetWidth(0.1F, 0.1F);
        lineRenderer.SetColors(Color.black, Color.black);
    }
	
	// Update is called once per frame
	void Update () 
    {
        //Idea is check where swipe starts.
        //Draw line
        //Upon stopping run raycast from start and to stop to see if it intersects the Datapacket.

        //Only allow one swipe at a time.
        //if(Input.touchCount == 1 )
        //{
        //    Debug.Log("Inside Touch.");

        //    Vector2 touchStart;
        //    Vector2 touchEnd;
        //    RaycastHit hit = new RaycastHit();
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Debug.Log("Starting Touch!");
        //        touchStart = touch.position;
        //        lineRenderer.SetPosition(0, touchStart);
        //    }
        //    else if (touch.phase == TouchPhase.Moved)
        //    {
        //        Debug.Log("Moving Touch!");
        //        touchEnd = touch.position;
        //        lineRenderer.SetPosition(1, touchEnd);
        //    }
        //    else if (touch.phase == TouchPhase.Ended)
        //    {
        //        Debug.Log("Ending Touch!");
        //        touchEnd = touch.position;

        //        //Do line cast
        //    }
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Button Clicked Mouse");
            
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //    if (hit.collider != null)
        //    {
        //        Debug.Log("Ray Hit");
        //        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
        //        {
        //           UpdateColor((int)GlobalData.PacketColors.Red);
        //           swipeActive = false;
        //        }
        //        else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
        //        {
        //            UpdateColor((int)GlobalData.PacketColors.Green);
        //            swipeActive = false;
        //        }
        //        else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
        //        {
        //            UpdateColor((int)GlobalData.PacketColors.Blue);
        //            swipeActive = false;
        //        }
        //        else 
        //        {
        //            swipeActive = true;
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0) && !movingMouse)
        {
            Debug.Log("Button Clicked Mouse");

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Ray Hit");
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
                {
                    UpdateColor((int)GlobalData.PacketColors.Red);
                    swipeActive = false;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
                {
                    UpdateColor((int)GlobalData.PacketColors.Green);
                    swipeActive = false;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
                {
                    UpdateColor((int)GlobalData.PacketColors.Blue);
                    swipeActive = false;
                }
                else
                {
                    swipeActive = true;
                }
            }
            else 
            {
                swipeActive = true; 
            }

            if (swipeActive)
            {
                //Debug.Log("Starting Touch!");
                lineRenderer.enabled = true;
                lineStart = camera.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(0, lineStart);
                movingMouse = true;
            }           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (swipeActive)
            {
                ///Debug.Log("Ending Touch!");
                DoRayCast(lineStart, lineEnd);
                lineRenderer.enabled = false; //Will play animation thing here.
                lineStart = Vector2.zero;
                lineEnd = Vector2.zero;
                movingMouse = false;
            }
        }

        if (movingMouse)
        {
            if (swipeActive)
            {
                //Debug.Log("Moving Touch!");
                lineEnd = camera.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(1, lineEnd);
            }
        }
        
    }

    void DoRayCast(Vector3 start, Vector3 end)
    {
        Debug.Log("Casting Ray");
        RaycastHit2D hit = Physics2D.Raycast(start, (end - start), Vector2.Distance(end, start));
        
        if (hit.collider != null)
        {
            Debug.Log("Something Hit!");

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("FallingObject"))
            {
                //hit.transform.gameObject.SetActive(false);

                //2 = red, 3 = green, 4 = blue
                hit.transform.gameObject.GetComponent<DataPacketLogic>().CheckColor(color);
            }
        }
    }

    public void UpdateColor(int newColor)
    {
        Debug.Log("Updating Colors");
        if(newColor == (int)GlobalData.PacketColors.Red)
        {
            ToggleRed();
        }
        else if(newColor == (int)GlobalData.PacketColors.Green)
        {
            ToggleGreen();
        }
        else if(newColor == (int)GlobalData.PacketColors.Blue)
        {
            ToggleBlue();
        }

        if(redOn && greenOn && blueOn)
        {
            lineRenderer.SetColors(white, white);
            color = (int)GlobalData.PacketColors.White;
            swipeActive = true;
        }
        else if(redOn && greenOn && !blueOn)
        {
            lineRenderer.SetColors(yellow, yellow);
            color = (int)GlobalData.PacketColors.Yellow;
            swipeActive = true;
        }
        else if(redOn && !greenOn && blueOn)
        {
            lineRenderer.SetColors(magenta, magenta);
            color = (int)GlobalData.PacketColors.Magenta;
            swipeActive = true;
        }
        else if(!redOn && greenOn && blueOn)
        {
            lineRenderer.SetColors(cyan, cyan);
            color = (int)GlobalData.PacketColors.Cyan;
            swipeActive = true;
        }
        else if(redOn && !greenOn && !blueOn)
        {
            lineRenderer.SetColors(red, red);
            color = (int)GlobalData.PacketColors.Red;
            swipeActive = true;
        }
        else if(!redOn && greenOn && !blueOn)
        {
            lineRenderer.SetColors(green, green);
            color = (int)GlobalData.PacketColors.Green;
            swipeActive = true;
        }
        else if(!redOn && !greenOn && blueOn)
        {
            lineRenderer.SetColors(blue, blue);
            color = (int)GlobalData.PacketColors.Blue;
            swipeActive = true;
        }
        else if(!redOn && !greenOn && !blueOn)
        {
            swipeActive = false;
        }
    }

    void ToggleRed()
    {
        Debug.Log("Toggling Red");
        redOn = !redOn;
        if(redOn)
        {
            redButton.GetComponent<SpriteRenderer>().sprite = onButton;
        }
        else 
        {
            redButton.GetComponent<SpriteRenderer>().sprite = offButton;
        }
    }

    void ToggleGreen()
    {
        Debug.Log("Toggling Green");
        greenOn = !greenOn;
        if (greenOn)
        {
            greenButton.GetComponent<SpriteRenderer>().sprite = onButton;
        }
        else
        {
            greenButton.GetComponent<SpriteRenderer>().sprite = offButton;
        }
    }

    void ToggleBlue()
    {
        Debug.Log("Toggling Blue");
        blueOn = !blueOn;
        if (blueOn)
        {
            blueButton.GetComponent<SpriteRenderer>().sprite = onButton;
        }
        else
        {
            blueButton.GetComponent<SpriteRenderer>().sprite = offButton;
        }
    }
}
