//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpawnManager : MonoBehaviour
{
    public GameObject virus;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    private GlobalData globalData;

    void Start()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
    }

    public GameObject SpawnVirus(float multiSpawnOffset)
    {
        //Between -2.35 and 3.35
        float spawnX = UnityEngine.Random.Range(-2f, 3.35f);
        float spawnY = 7.5f;
        if(multiSpawnOffset > 0)
        {
            //This is just to slightly offset the mutli spawning so they are not all in the same spot.
            spawnY = spawnY + multiSpawnOffset;
        }

        GameObject newObj = null;
        newObj = (GameObject)Instantiate(virus, new Vector2(spawnX, spawnY), Quaternion.identity);

        SpriteRenderer spr = newObj.GetComponent<SpriteRenderer>();

        int spriteNum = globalData.globalRandom.Next(3, 10);
        if(spriteNum == 3)
        {
            spr.sprite = three;
        }
        else if(spriteNum == 4)
        {
            spr.sprite = four;
        }
        else if(spriteNum == 4)
        {
            spr.sprite = four;
        }
        else if(spriteNum == 5)
        {
            spr.sprite = five;
        }
        else if(spriteNum == 6)
        {
            spr.sprite = six;
        }
        else if(spriteNum == 7)
        {
            spr.sprite = seven;
        }
        else if(spriteNum == 8)
        {
            spr.sprite = eight;
        }
        else if(spriteNum == 9)
        {
            spr.sprite = nine;
        }

        DownwardMovment downMove = newObj.GetComponent<DownwardMovment>();
        downMove.speed = globalData.globalVars["virusSpeed"];

        ParticleSystem particleSys = newObj.GetComponent<ParticleSystem>();
        particleSys.startSpeed = globalData.globalVars["virusSpeed"] * 2;

        VirusLogic virusLogic = newObj.GetComponent<VirusLogic>();
        //Ignore 0 because it is black in our enum.
        int color = globalData.globalRandom.Next(1, 8);
        virusLogic.SetColor(color);
        virusLogic.SetSides(spriteNum);

        return newObj;
    }
}
