//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    private Color black = Color.black;
    private Color white = Color.white;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color blue = Color.blue;
    private Color yellow = Color.yellow;
    private Color cyan = Color.cyan;
    private Color magenta = Color.magenta;
    
    void Start()
    {
        //trailRenderer = GetComponent<TrailRenderer>();
        //trailRenderer.sortingLayerName = "Viruses";

        audioSource = GetComponent<AudioSource>();

        GetComponent<CircleCollider2D>().enabled = false;
        
        SetupSwipeColor();
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

    void SetupSwipeColor()
    {
        color = (int)GlobalData.PacketColors.Black;
        transform.Find("RedTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("GreenTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("BlueTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("YellowTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("MagentaTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("CyanTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("WhiteTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        transform.Find("BlackTrail").GetComponent<TrailRenderer>().sortingLayerName = "Viruses";
        SetTrailColor(color);
        colorSelectionIcon.GetComponent<SpriteRenderer>().color = black;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Virus"))
        {
            coll.transform.gameObject.GetComponent<VirusLogic>().CheckColor(color);
        }

        if(coll.gameObject.layer == LayerMask.NameToLayer("ColorButtonRed"))
        {
            UpdateColor((int)GlobalData.PacketColors.Red);
        }
        else if (coll.gameObject.layer == LayerMask.NameToLayer("ColorButtonGreen"))
        {
            UpdateColor((int)GlobalData.PacketColors.Green);
        }
        else if (coll.gameObject.layer == LayerMask.NameToLayer("ColorButtonBlue"))
        {
            UpdateColor((int)GlobalData.PacketColors.Blue);
        }
    }

    void CheckTouchInput()
    {
        //Only allow one swipe at a time.
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && !dragging)
            {
                swipeActive = true;

                if(swipeActive)
                {
                    transform.position = touchStart;
                    GetComponent<CircleCollider2D>().enabled = true;
                    
                    touchStart = camera.ScreenToWorldPoint(touch.position);                    
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
                        //audioSource.PlayOneShot(swipeSFX, 1);
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
                    swipeActive = false;
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
            swipeActive = true;

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
                swipeActive = false;
            }
        }

        if(swipeActive && dragging)
        {
            lineEnd = camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = lineEnd;


            if(!audioSource.isPlaying)
            {
                //audioSource.PlayOneShot(swipeSFX, 1);
            }
        }
    }

    public void UpdateColor(int newColor)
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(colorToggleSFX, 1);
        }

        //Debug.Log("Updating Color to " + newColor);
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
            //trailRenderer.material.SetColor("_TintColor", white);
            color = (int)GlobalData.PacketColors.White;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = white;
        }
        else if(redOn && greenOn && !blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", yellow);
            color = (int)GlobalData.PacketColors.Yellow;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = yellow;
        }
        else if(redOn && !greenOn && blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", magenta);
            color = (int)GlobalData.PacketColors.Magenta;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = magenta;
        }
        else if(!redOn && greenOn && blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", cyan);
            color = (int)GlobalData.PacketColors.Cyan;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = cyan;
        }
        else if(redOn && !greenOn && !blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", red);
            color = (int)GlobalData.PacketColors.Red;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = red;
        }
        else if(!redOn && greenOn && !blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", green);
            color = (int)GlobalData.PacketColors.Green;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = green;
        }
        else if(!redOn && !greenOn && blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", blue);
            color = (int)GlobalData.PacketColors.Blue;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = blue;
        }
        else if(!redOn && !greenOn && !blueOn)
        {
            //trailRenderer.material.SetColor("_TintColor", black);
            color = (int)GlobalData.PacketColors.Black;
            SetTrailColor(color);
            colorSelectionIcon.GetComponent<SpriteRenderer>().color = black;
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

    void SetTrailColor(int color)
    {
        if ((int)GlobalData.PacketColors.Red == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Green == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Blue == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Yellow == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Magenta == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Cyan == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.White == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = true;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
        }
        else if ((int)GlobalData.PacketColors.Black == color)
        {
            transform.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("MagentaTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("CyanTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("WhiteTrail").GetComponent<TrailRenderer>().enabled = false;
            transform.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = true;
        }
    }
}
