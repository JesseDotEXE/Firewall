//Author: Jesus Villagomez - JesseDotEXE
//References: 
//N/A

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VirusLogic : MonoBehaviour
{
    public Material threeMat;
    public Material fourMat;
    public Material fiveMat;
    public Material sixMat;
    public Material sevenMat;
    public Material eightMat;
    public Material nineMat;

    public GameObject explosion;

    public AudioClip explodeSFX;

    private GameMode gameMode;
    private BreachManager breachManager;

    private SpriteRenderer spriteRenderer;
    private ParticleSystem particleSys;
    private ParticleSystem explosionSys;
    private ParticleSystemRenderer particleRenderer;

    private AudioSource audioSource;

    private int virusColor = 1;
    private int sides;

    private bool harmless;

    void Awake()
    {
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        breachManager = GameObject.Find("Database").GetComponent<BreachManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSys = GetComponent<ParticleSystem>();
        particleRenderer = GetComponent<ParticleSystemRenderer>();

        audioSource = GetComponent<AudioSource>();

        harmless = false;

        InitializeColors();
        InitializeSides();
    }

    void Update()
    {
        if(virusColor == (int)GlobalData.PacketColors.Black)
        {
            harmless = true;
            Destroy(gameObject, 3.0f);
        }
    }

    void InitializeSides()
    {
        if(sides == 3)
        {
            particleRenderer.material = threeMat;
        }
        else if(sides == 4)
        {
            particleRenderer.material = fourMat;
        }
        else if(sides == 5)
        {
            particleRenderer.material = fiveMat;
        }
        else if(sides == 6)
        {
            particleRenderer.material = sixMat;
        }
        else if(sides == 7)
        {
            particleRenderer.material = sevenMat;
        }
        else if(sides == 8)
        {
            particleRenderer.material = eightMat;
        }
        else if(sides == 9)
        {
            particleRenderer.material = nineMat;
        }
    }

    void InitializeColors()
    {
        if(virusColor == (int)GlobalData.PacketColors.White)
        {
            spriteRenderer.material.color = Color.white;
            particleSys.startColor = Color.white;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Red)
        {
            spriteRenderer.material.color = Color.red;
            particleSys.startColor = Color.red;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Green)
        {
            spriteRenderer.material.color = Color.green;
            particleSys.startColor = Color.green;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Blue)
        {
            spriteRenderer.material.color = Color.blue;
            particleSys.startColor = Color.blue;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Yellow)
        {
            spriteRenderer.material.color = Color.yellow;
            particleSys.startColor = Color.yellow;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Magenta)
        {
            spriteRenderer.material.color = Color.magenta;
            particleSys.startColor = Color.magenta;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Cyan)
        {
            spriteRenderer.material.color = Color.cyan;
            particleSys.startColor = Color.cyan;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("DataStore"))
        {
            breachManager.SpawnBreachSmall(transform.position);
            gameMode.DecreaseLives();
            Explode();
        }
    }

    public void CheckColor(int swipeColor)
    {
        if(swipeColor == virusColor)
        {
            Explode();
        }
        else
        {
            //Bad Stuff
            gameMode.BreakStreak();
        }
    }

    public void Explode()
    {
        gameMode.AddPoints();

        GameObject tempPSys = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSys = tempPSys.GetComponent<ParticleSystem>();
        SetExplosionColor();
        explosionSys.Emit(sides);

        audioSource.PlayOneShot(explodeSFX, 1);

        particleSys.Stop();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        Destroy(gameObject, 0.25f);
    }

    private void SetExplosionColor()
    {
        if(virusColor == (int)GlobalData.PacketColors.White)
        {
            explosionSys.startColor = Color.white;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Red)
        {
            explosionSys.startColor = Color.red;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Green)
        {
            explosionSys.startColor = Color.green;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Blue)
        {
            explosionSys.startColor = Color.blue;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Yellow)
        {
            explosionSys.startColor = Color.yellow;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Magenta)
        {
            explosionSys.startColor = Color.magenta;
        }
        else if(virusColor == (int)GlobalData.PacketColors.Cyan)
        {
            explosionSys.startColor = Color.cyan;
        }
    }

    public void SetColor(int color)
    {
        virusColor = color;
        InitializeColors();
    }

    public void SetSides(int newSides)
    {
        sides = newSides;
        InitializeSides();
    }
}
