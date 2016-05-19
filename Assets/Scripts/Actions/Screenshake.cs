using UnityEngine;
using System.Collections;

//Frome: http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/

public class Screenshake : MonoBehaviour
{

    Vector3 originalCameraPosition;

    float shakeAmt = 0;

    public Camera mainCamera;

    void Start()
    {
        originalCameraPosition = mainCamera.transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("FallingObject"))
        {
            shakeAmt = 0.0025f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
        }

    }

    void CameraShake()
    {
        float shakeMod = 0f;
        if (Random.value >= 0.5f)
        {
            shakeMod = 1f;
        }
        else 
        {
            shakeMod = -1f;
        }
        float quakeAmt = shakeAmt * shakeMod;
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