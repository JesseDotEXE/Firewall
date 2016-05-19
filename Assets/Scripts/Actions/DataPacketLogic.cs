using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPacketLogic : MonoBehaviour 
{
    //Not sure where to put this
    enum PacketColors{Black = 0, White, Red, Green, Blue, Yellow, Magenta, Cyan}
    private int packetColor;
    private int sides;
    //private List<int> compositeColors;

    private GameMode gameMode;
    private SpriteRenderer spriteRenderer;
    private ParticleSystemRenderer particleRenderer;
    private ParticleSystem particleSys;
    private ScoreManager scoreManager;

    public GameObject explosion;
    private ParticleSystem explosionSys;

    public GameObject dataStoreBreach;

    public Material threeMat;
    public Material fourMat;
    public Material fiveMat;
    public Material sixMat;
    public Material sevenMat;
    public Material eightMat;
    public Material nineMat;

    private bool harmless;

	// Use this for initialization
	void Awake () 
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSys = GetComponent<ParticleSystem>();
        particleRenderer = GetComponent<ParticleSystemRenderer>();
        scoreManager = gameMode.GetComponent<ScoreManager>();
        harmless = false;
        //compositeColors = new List<int>();
        InitializeColors();
        InitializeSides();
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

    void InitializeSides()
    {
        if(sides == 3)
        {
            particleRenderer.material = threeMat;
        }
        else if (sides == 4)
        {
            particleRenderer.material = fourMat;
        }
        else if (sides == 5)
        {
            particleRenderer.material = fiveMat;
        }
        else if (sides == 6)
        {
            particleRenderer.material = sixMat;
        }
        else if (sides == 7)
        {
            particleRenderer.material = sevenMat;
        }
        else if (sides == 8)
        {
            particleRenderer.material = eightMat;
        }
        else if (sides == 9)
        {
            particleRenderer.material = nineMat;
        }
    }

    void InitializeColors()
    {
        if (packetColor == (int)PacketColors.White)
        {
            //explosionSys.startColor = Color.white;
            spriteRenderer.material.color = Color.white;
            particleSys.startColor = Color.white;
        }
        else if (packetColor == (int)PacketColors.Red)
        {
            //explosionSys.startColor = Color.red;
            spriteRenderer.material.color = Color.red;
            particleSys.startColor = Color.red;
        }
        else if (packetColor == (int)PacketColors.Green)
        {
            //explosionSys.startColor = Color.green;
            spriteRenderer.material.color = Color.green;
            particleSys.startColor = Color.green;
        }
        else if (packetColor == (int)PacketColors.Blue)
        {
            //explosionSys.startColor = Color.blue;
            spriteRenderer.material.color = Color.blue;
            particleSys.startColor = Color.blue;
        }
        else if (packetColor == (int)PacketColors.Yellow)
        {
            //explosionSys.startColor = Color.yellow;
            spriteRenderer.material.color = Color.yellow;
            particleSys.startColor = Color.yellow;
        }
        else if (packetColor == (int)PacketColors.Magenta)
        {
            //explosionSys.startColor = Color.magenta;
            spriteRenderer.material.color = Color.magenta;
            particleSys.startColor = Color.magenta;
        }
        else if (packetColor == (int)PacketColors.Cyan)
        {
            //explosionSys.startColor = Color.cyan;
            spriteRenderer.material.color = Color.cyan;
            particleSys.startColor = Color.cyan;
        }        
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("DataStore")) 
        {
            gameMode.GetScoreManager().ResetCombo();
            gameMode.GetScoreManager().ResetComboCount();
            gameMode.GetScoreManager().DecreaseLives();
            //Also will need to cause explosion.
            SpawnDataStoreBreach();
        }
    }

    private void SpawnDataStoreBreach()
    {
        GameObject breach = (GameObject)Instantiate(dataStoreBreach, transform.position, Quaternion.identity);
    }

    public void CheckColor(int swipeColor)
    {
        if(swipeColor == packetColor)
        {
            Explode();
        }
        else 
        {
            //Bad Stuff
            gameMode.GetScoreManager().ResetComboCount();
            //Play screenshake or something.
        }
    }

    public void Explode()
    {
         
        GameObject tempPSys = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSys = tempPSys.GetComponent<ParticleSystem>();
        SetExplosionColor();
        explosionSys.Emit(sides);

        particleSys.Stop();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        gameMode.GetScoreManager().AddPoints();

        Destroy(gameObject, 0.5f);
    }

    private void SetExplosionColor()
    {
        if (packetColor == (int)PacketColors.White)
        {
            explosionSys.startColor = Color.white;
        }
        else if (packetColor == (int)PacketColors.Red)
        {
            explosionSys.startColor = Color.red;
        }
        else if (packetColor == (int)PacketColors.Green)
        {
            explosionSys.startColor = Color.green;
        }
        else if (packetColor == (int)PacketColors.Blue)
        {
            explosionSys.startColor = Color.blue;
        }
        else if (packetColor == (int)PacketColors.Yellow)
        {
            explosionSys.startColor = Color.yellow;
        }
        else if (packetColor == (int)PacketColors.Magenta)
        {
            explosionSys.startColor = Color.magenta;
        }
        else if (packetColor == (int)PacketColors.Cyan)
        {
            explosionSys.startColor = Color.cyan;
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

    public void SetSides(int newSides)
    {
        sides = newSides;
        InitializeSides();
    }
}
