using UnityEngine;
using System.Collections;

public class BitSpawner : MonoBehaviour 
{
    public GameObject bitPrefab;
    public float spawnXMin;
    public float spawnXMax;
    private float spawnXDelta;
    public int numBits;
    GameMode gameMode;
    float lastForceTime;
    private GlobalData globalData;
    public Sprite sprZero;
    public Sprite sprOne;

    // Use this for initialization
    void Start()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();
        GetSpawnDeltas();
        SpawnBits(numBits); 
        lastForceTime = 0f;
    }
	
	// Update is called once per frame
	void Update () 
    {
        lastForceTime += Time.deltaTime;
        if (lastForceTime >= 0.1f)
        {
            ShakeRandomBits();
            lastForceTime = 0f;
        }
	}

    void GetSpawnDeltas()
    {
        spawnXDelta = (Mathf.Abs(spawnXMin) + Mathf.Abs(spawnXMax)) / numBits;
    }

    void SpawnBits(int count)
    {
        GameObject bit;
        Vector2 spawnPoint;
        float x = spawnXMin;
        float y = transform.position.y;
        for (int i = 1; i < numBits; i++)
        {
            Vector2 randVect = new Vector2(globalData.globRandom.Next(-3, 4) * 2, globalData.globRandom.Next(-3, 4) * 2);
            spawnPoint = new Vector2(x, y);
            int randSprite = globalData.globRandom.Next(0, 2);
            
            bit = (GameObject)Instantiate(bitPrefab, new Vector2(0, 0), Quaternion.identity);
            if(randSprite == 1)
            {
                //Only need one as 0 will be the default.
                bit.GetComponent<SpriteRenderer>().sprite = sprOne;
            }
            bit.transform.parent = this.transform;
            bit.transform.position = spawnPoint;
            bit.GetComponent<Rigidbody2D>().AddForce(randVect, ForceMode2D.Impulse);

            x += spawnXDelta;
        }
    }

    void MakeBit(Vector3 spawnPoint)
    {
        GameObject bit = (GameObject)Instantiate(bitPrefab, spawnPoint, Quaternion.identity);
    }

    void ShakeRandomBits()
    {
        Vector2 randVect = new Vector2(globalData.globRandom.Next(-3, 4) * 2, globalData.globRandom.Next(-3, 4) * 2);
        transform.GetChild(globalData.globRandom.Next(0, numBits - 1)).GetComponent<Rigidbody2D>().AddForce(randVect, ForceMode2D.Impulse);
        transform.GetChild(globalData.globRandom.Next(0, numBits - 1)).GetComponent<Rigidbody2D>().AddForce(randVect, ForceMode2D.Impulse);
        transform.GetChild(globalData.globRandom.Next(0, numBits - 1)).GetComponent<Rigidbody2D>().AddForce(randVect, ForceMode2D.Impulse);
    }

    void ShakeBits()
    {
        Debug.Log("Shaking Bits!");
       foreach(Transform child in transform)
       {
            Debug.Log("Shake!");
            Vector2 randVect = new Vector2(globalData.globRandom.Next(-3, 4), globalData.globRandom.Next(-3, 4));
            child.gameObject.GetComponent<Rigidbody2D>().AddForce(randVect, ForceMode2D.Impulse); 
       }
    }
}
