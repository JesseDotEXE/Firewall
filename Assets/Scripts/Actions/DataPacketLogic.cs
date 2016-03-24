using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPacketLogic : MonoBehaviour 
{
    //Not sure where to put this
    enum PacketColors{Black = 0, White, Red, Green, Blue, Yellow, Magenta, Cyan}
    private int packetColor;
    private List<int> compositeColors;

    private GameMode gameMode;

    private bool harmless;

	// Use this for initialization
	void Awake () 
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        harmless = false;
        compositeColors = new List<int>();
        InitializeColors();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(packetColor == (int)PacketColors.Black)
        {
            harmless = true;
            Destroy(gameObject, 2.0f);
        }
	}

    void InitializeColors()
    {
        if (compositeColors.Count > 0) { compositeColors.Clear(); }

        if (packetColor == (int)PacketColors.White)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            compositeColors.Add((int)PacketColors.Red);
            compositeColors.Add((int)PacketColors.Green);
            compositeColors.Add((int)PacketColors.Blue);
        }
        else if (packetColor == (int)PacketColors.Red)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
            compositeColors.Add((int)PacketColors.Red);
        }
        else if (packetColor == (int)PacketColors.Green)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
            compositeColors.Add((int)PacketColors.Green);
        }
        else if (packetColor == (int)PacketColors.Blue)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
            compositeColors.Add((int)PacketColors.Blue);
        }
        else if (packetColor == (int)PacketColors.Yellow)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            compositeColors.Remove((int)PacketColors.Green);
            compositeColors.Remove((int)PacketColors.Red);
        }
        else if (packetColor == (int)PacketColors.Magenta)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.magenta;
            compositeColors.Add((int)PacketColors.Blue);
            compositeColors.Add((int)PacketColors.Red);
        }
        else if (packetColor == (int)PacketColors.Cyan)
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.cyan;
            compositeColors.Add((int)PacketColors.Green);
            compositeColors.Add((int)PacketColors.Blue);
        }        
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("SecurityRed"))
        {
            ChangeColor((int)PacketColors.Red);
            //compositeColors.Remove((int)PacketColors.Red);
        }
        else if (coll.gameObject.layer == LayerMask.NameToLayer("SecurityGreen")) 
        {
            ChangeColor((int)PacketColors.Green);
            //compositeColors.Remove((int)PacketColors.Red);
        }
        else if (coll.gameObject.layer == LayerMask.NameToLayer("SecurityBlue")) 
        {
            ChangeColor((int)PacketColors.Blue);
            //compositeColors.Remove((int)PacketColors.Red);
        }
        else if(coll.gameObject.layer == LayerMask.NameToLayer("DataStore")) 
        {
            if(packetColor == (int)PacketColors.Black) 
            {
                gameMode.GetScoreManager().AddPoints(10);
            }
            else 
            {
                gameMode.GetScoreManager().DecreaseLives();
            }
        }
    }

    void ChangeColor(int colorRemoved)
    {
        //Modify White packets.
        if (packetColor == (int)PacketColors.White)
        {
            if(colorRemoved == (int)PacketColors.Red)
            {
                packetColor = (int)PacketColors.Cyan;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.cyan;
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                packetColor = (int)PacketColors.Magenta;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.magenta;
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                packetColor = (int)PacketColors.Yellow;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.yellow;
            }
        }

        //Modify Red packets.
        else if (packetColor == (int)PacketColors.Red)
        {
            if(colorRemoved == (int)PacketColors.Red)
            {
                packetColor = (int)PacketColors.Black;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
            }

            if(colorRemoved == (int)PacketColors.Green)
            {
                //Bad Stuff
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                //Bad Stuff
            }
        }

        //Modify Green packets.
        else if (packetColor == (int)PacketColors.Green)
        {
            if (colorRemoved == (int)PacketColors.Red)
            {
                //Bad stuff
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                packetColor = (int)PacketColors.Black;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                //Bad Stuff
            }
        }

        //Modify Blue packets.
        else if (packetColor == (int)PacketColors.Blue)
        {
            if (colorRemoved == (int)PacketColors.Red)
            {
                //Bad stuff
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                //Bad stuff
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                packetColor = (int)PacketColors.Black;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
            }
        }

        //Modify Yellow packets.
        else if (packetColor == (int)PacketColors.Yellow)
        {
            if (colorRemoved == (int)PacketColors.Red)
            {
                packetColor = (int)PacketColors.Green;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                packetColor = (int)PacketColors.Red;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                //Bad stuff
            }
        }

        //Modify Magenta packets.
        else if (packetColor == (int)PacketColors.Magenta)
        {
            if (colorRemoved == (int)PacketColors.Red)
            {
                packetColor = (int)PacketColors.Blue;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                //Bad stuff
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                packetColor = (int)PacketColors.Red;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
            }
        }

        //Modify Cyan packets.
        else if (packetColor == (int)PacketColors.Cyan)
        {
            if (colorRemoved == (int)PacketColors.Red)
            {
                //Bad stuff
            }

            if (colorRemoved == (int)PacketColors.Green)
            {
                packetColor = (int)PacketColors.Blue;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
            }

            if (colorRemoved == (int)PacketColors.Blue)
            {
                packetColor = (int)PacketColors.Green;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
            }
        }
    }

    public int GetPacketColor()
    {
        return packetColor;
    }

    public void SetPacketColor(int color)
    {
        packetColor = color;
        InitializeColors();
    }
}
