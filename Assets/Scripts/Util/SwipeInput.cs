//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour
{
    public Camera camera;

    public GameObject colorButtons;
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;
    public GameObject colorSelectionIcon;
    public Sprite offButton;
    public Sprite onButton;

    public AudioClip swipeSFX;
    public AudioClip colorToggleSFX;

    private TrailRenderer trailRenderer;
    private bool swipeActive = false;
    private bool dragging = false;
    private Vector2 touchStart;
    private Vector2 touchEnd;
    private Vector2 lineStart;
    private Vector2 lineEnd;

    private bool redOn = false;
    private bool greenOn = false;
    private bool blueOn = false;

    private AudioSource audioSource;
    
    private int color;
    private Color white = Color.white;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color blue = Color.blue;
    private Color yellow = Color.yellow;
    private Color cyan = Color.cyan;
    private Color magenta = Color.magenta;
    
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.sortingLayerName = "Viruses";

        audioSource = GetComponent<AudioSource>();

        GetComponent<CircleCollider2D>().enabled = false;
        colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.black;
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            CheckTouchInput();
        }
        else
        {
            CheckMKBInput();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Virus"))
        {
            coll.transform.gameObject.GetComponent<VirusLogic>().CheckColor(color);
        }
    }

    void CheckTouchInput()
    {
        //Only allow one swipe at a time.
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if(hit.collider != null)
                {
                    //Check mto see if we hit a button, if so don't make the drag effect.
                    if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
                    {
                        UpdateColor((int)GlobalData.PacketColors.Red);
                        swipeActive = false;
                    }
                    else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
                    {
                        UpdateColor((int)GlobalData.PacketColors.Green);
                        swipeActive = false;
                    }
                    else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
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

                if(swipeActive)
                {
                    touchStart = camera.ScreenToWorldPoint(touch.position);
                    transform.position = touchStart;
                    GetComponent<CircleCollider2D>().enabled = true;
                    dragging = true;
                }
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                if(swipeActive)
                {
                    touchEnd = camera.ScreenToWorldPoint(touch.position);
                    transform.position = touchEnd;

                    if(!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(swipeSFX, 1);
                    }
                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                if(swipeActive)
                {
                    GetComponent<CircleCollider2D>().enabled = false;
                    touchStart = Vector2.zero;
                    touchEnd = Vector2.zero;
                    dragging = false;
                }
            }
        }
    }

    void CheckMKBInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UpdateColor((int)GlobalData.PacketColors.Red);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            UpdateColor((int)GlobalData.PacketColors.Green);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            UpdateColor((int)GlobalData.PacketColors.Blue);
        }

        if(Input.GetMouseButtonDown(0) && !dragging)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                //Check mto see if we hit a button, if so don't make the drag effect.
                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
                {
                    UpdateColor((int)GlobalData.PacketColors.Red);
                    swipeActive = false;
                }
                else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
                {
                    UpdateColor((int)GlobalData.PacketColors.Green);
                    swipeActive = false;
                }
                else if(hit.transform.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
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
                Debug.Log("Didn't hit the button!");
                if(redOn || greenOn || blueOn)
                {
                    swipeActive = true;
                }
            }

            if(swipeActive)
            {
                transform.position = lineStart;
                GetComponent<CircleCollider2D>().enabled = true;

                lineStart = camera.ScreenToWorldPoint(Input.mousePosition);
                dragging = true;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(swipeActive)
            {
                GetComponent<CircleCollider2D>().enabled = false;

                lineStart = Vector2.zero;
                lineEnd = Vector2.zero;
                dragging = false;
            }
        }

        if(dragging)
        {
            if(swipeActive)
            {
                lineEnd = camera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = lineEnd;


                if(!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(swipeSFX, 1);
                }
            }
        }
    }

    public void UpdateColor(int newColor)
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(colorToggleSFX, 1);
        }

        Debug.Log("Updating Color to " + newColor);
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
            trailRenderer.material.SetColor("_TintColor", white);
            color = (int)GlobalData.PacketColors.White;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.white;
            swipeActive = true;
        }
        else if(redOn && greenOn && !blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", yellow);
            color = (int)GlobalData.PacketColors.Yellow;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            swipeActive = true;
        }
        else if(redOn && !greenOn && blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", magenta);
            color = (int)GlobalData.PacketColors.Magenta;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.magenta;
            swipeActive = true;
        }
        else if(!redOn && greenOn && blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", cyan);
            color = (int)GlobalData.PacketColors.Cyan;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.cyan;
            swipeActive = true;
        }
        else if(redOn && !greenOn && !blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", red);
            color = (int)GlobalData.PacketColors.Red;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.red;
            swipeActive = true;
        }
        else if(!redOn && greenOn && !blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", green);
            color = (int)GlobalData.PacketColors.Green;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.green;
            swipeActive = true;
        }
        else if(!redOn && !greenOn && blueOn)
        {
            trailRenderer.material.SetColor("_TintColor", blue);
            color = (int)GlobalData.PacketColors.Blue;
            colorSelectionIcon.GetComponent<SpriteRenderer>().material.color = Color.blue;
            swipeActive = true;
        }
        else if(!redOn && !greenOn && !blueOn)
        {
            swipeActive = false;
        }
    }

    void ToggleRed()
    {
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
        greenOn = !greenOn;
        if(greenOn)
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
        blueOn = !blueOn;
        if(blueOn)
        {
            blueButton.GetComponent<SpriteRenderer>().sprite = onButton;
        }
        else
        {
            blueButton.GetComponent<SpriteRenderer>().sprite = offButton;
        }
    }
}
