//Author: Jesus Villagomez - JesseDotEXE
//References:
//http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreachManager : MonoBehaviour
{
    public Camera mainCamera;
    public AudioClip breakSound;
    public AudioClip breachSmallSound;
    public AudioClip failureSound;
    public GameObject databaseBreachSmall;
    public GameObject databaseBreachBig;
    public GameObject databaseBreak;

    private GlobalData globalData;
    private SceneChange sceneChange;
    private AudioSource audioSource;

    private Vector3 originalCameraPosition;
    private float shakeAmt = 0;

    void Awake()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        sceneChange = GetComponent<SceneChange>();
        audioSource = GetComponent<AudioSource>();
        originalCameraPosition = mainCamera.transform.position;

        audioSource.Play();
    }

    void CameraShake()
    {
        float quakeAmt = UnityEngine.Random.value * Mathf.Sin(shakeAmt) * 2 - shakeAmt;
        Vector3 pp = mainCamera.transform.position;
        pp.x += quakeAmt; // can also add to x and/or z
        mainCamera.transform.position = pp;
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

    public void DestroyDatabase()
    {
        InvokeRepeating("BreakDatabase", 0, 0.65f);
        Invoke("SpawnBreachBig", 3f);
        Invoke("GameOver", 5f);
    }

    void BreakDatabase()
    {
        audioSource.PlayOneShot(breakSound);
        GameObject dbBreak = (GameObject)Instantiate(databaseBreak, new Vector2(0f, -5.75f), Quaternion.identity);
    }

    public void SpawnBreachSmall(Vector2 spawnPos)
    {
        audioSource.PlayOneShot(breachSmallSound);
        GameObject breach = (GameObject)Instantiate(databaseBreachSmall, spawnPos, Quaternion.identity);

        shakeAmt = 0.05f;
        InvokeRepeating("CameraShake", 0, .005f);
        Invoke("StopShaking", 0.175f);
    }

    void SpawnBreachBig()
    {
        globalData.CleanUpGameObject("Breach");
        CancelInvoke("BreakDatabase");
        GetComponent<SpriteRenderer>().enabled = false;
        audioSource.PlayOneShot(failureSound);
        GameObject breach = (GameObject)Instantiate(databaseBreachBig, new Vector2(0f, -6f), Quaternion.identity);
    }

    void GameOver()
    {
        sceneChange.ChangeScene();
    }
}