using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour 
{
    public Camera camera;
    //private LineRenderer lineRenderer;
    bool dragging = false;
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
    public GameObject colorButtons;
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;
    public GameObject swipeObj;
    private SwipeCollision swipeCollision;
    private TrailRenderer trailRenderer;
    public Sprite offButton;
    public Sprite onButton;
    Vector2 touchStart;
    Vector2 touchEnd;
    Vector2 lineStart;
    Vector2 lineEnd;

    private AudioSource audioSourceSwipe;
    private AudioSource audioSourceButton;
    public AudioClip swipeSFX;
    public AudioClip colorToggleSFX;

    
    private int color; //0 = red, 1 = green, 2 = blue

    // Use this for initialization
    void Start () 
    {
        trailRenderer = swipeObj.GetComponent<TrailRenderer>();
        trailRenderer.sortingLayerName = "Viruses";
        swipeCollision = swipeObj.GetComponent<SwipeCollision>();
        audioSourceSwipe = swipeObj.GetComponent<AudioSource>();
        audioSourceButton = colorButtons.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        //CheckTouchInput();
        CheckMKBInput();
    }

    void CheckTouchInput()
    {
        //Only allow one swipe at a time.
        if (Input.touchCount == 1)
        {
            Debug.Log("Inside Touch.");

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
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
                    //lineRenderer.enabled = true;
                    touchStart = camera.ScreenToWorldPoint(touch.position);
                    swipeObj.transform.position = touchStart;
                    swipeObj.SetActive(true);
                    //lineRenderer.SetPosition(0, touchStart);
                    dragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (swipeActive)
                {
                    touchEnd = camera.ScreenToWorldPoint(touch.position);
                    swipeObj.transform.position = touchEnd;
                    //lineRenderer.SetPosition(1, touchEnd);

                    if (!audioSourceSwipe.isPlaying)
                    {
                        audioSourceSwipe.PlayOneShot(swipeSFX, 1);
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (swipeActive)
                {
                    //DoRayCast(touchStart, touchEnd);
                    //lineRenderer.enabled = false;
                    swipeObj.SetActive(false);
                    touchStart = Vector2.zero;
                    touchEnd = Vector2.zero;
                    dragging = false;
                }
            }
        }
    }

    void CheckMKBInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateColor((int)GlobalData.PacketColors.Red);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpdateColor((int)GlobalData.PacketColors.Green);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateColor((int)GlobalData.PacketColors.Blue);
        }

        if (Input.GetMouseButtonDown(0) && !dragging)
        {
            Debug.Log("Button Clicked Mouse");

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //Check mto see if we hit a button, if so don't make the drag effect.
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
                if (redOn || greenOn || blueOn)
                {
                    swipeActive = true;
                }
            }

            if (swipeActive)
            {
                //Debug.Log("Starting Touch!");
                //lineRenderer.enabled = true;

                //Add object here
                swipeObj.transform.position = lineStart;
                swipeObj.SetActive(true);

                lineStart = camera.ScreenToWorldPoint(Input.mousePosition);
                //lineRenderer.SetPosition(0, lineStart);
                dragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (swipeActive)
            {
                ///Debug.Log("Ending Touch!");
                //DoRayCast(lineStart, lineEnd);
                //lineRenderer.enabled = false; //Will play animation thing here.

                //Stop object here
                swipeObj.SetActive(false);

                lineStart = Vector2.zero;
                lineEnd = Vector2.zero;
                dragging = false;
            }
        }

        if (dragging)
        {
            if (swipeActive)
            {
                //Debug.Log("Moving Touch!");
                lineEnd = camera.ScreenToWorldPoint(Input.mousePosition);
                //lineRenderer.SetPosition(1, lineEnd);

                //Set object position here
                swipeObj.transform.position = lineEnd;

                if (!audioSourceSwipe.isPlaying)
                {
                    audioSourceSwipe.PlayOneShot(swipeSFX, 1);
                }
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
                hit.transform.gameObject.GetComponent<VirusLogic>().CheckColor(color);
            }
        }
    }

    public void UpdateColor(int newColor)
    {
        if(!audioSourceButton.isPlaying)
            audioSourceButton.PlayOneShot(colorToggleSFX, 1);    

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
            //lineRenderer.SetColors(white, white);
            trailRenderer.material.SetColor("_TintColor", white);
            color = (int)GlobalData.PacketColors.White;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(redOn && greenOn && !blueOn)
        {
            //lineRenderer.SetColors(yellow, yellow);
            trailRenderer.material.SetColor("_TintColor", yellow);
            color = (int)GlobalData.PacketColors.Yellow;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(redOn && !greenOn && blueOn)
        {
            //lineRenderer.SetColors(magenta, magenta);
            trailRenderer.material.SetColor("_TintColor", magenta);
            color = (int)GlobalData.PacketColors.Magenta;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(!redOn && greenOn && blueOn)
        {
            //lineRenderer.SetColors(cyan, cyan);
            trailRenderer.material.SetColor("_TintColor", cyan);
            color = (int)GlobalData.PacketColors.Cyan;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(redOn && !greenOn && !blueOn)
        {
            //lineRenderer.SetColors(red, red);
            trailRenderer.material.SetColor("_TintColor", red);
            color = (int)GlobalData.PacketColors.Red;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(!redOn && greenOn && !blueOn)
        {
            //lineRenderer.SetColors(green, green);
            trailRenderer.material.SetColor("_TintColor", green);
            color = (int)GlobalData.PacketColors.Green;
            swipeCollision.SetSwipeColor(color);
            swipeActive = true;
        }
        else if(!redOn && !greenOn && blueOn)
        {
            //lineRenderer.SetColors(blue, blue);
            trailRenderer.material.SetColor("_TintColor", blue);
            color = (int)GlobalData.PacketColors.Blue;
            swipeCollision.SetSwipeColor(color);
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
