//Author: Jesus Villagomez - JesseDotEXE
//References:
//http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screenshake : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject redScreen;

    private Vector3 originalCameraPosition;
    private float shakeAmt = 0;

    void Start()
    {  
        originalCameraPosition = mainCamera.transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("FallingObject"))
        {
            shakeAmt = 0.05f;
            InvokeRepeating("CameraShake", 0, .005f);
            Invoke("StopShaking", 0.175f);
        }

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

}