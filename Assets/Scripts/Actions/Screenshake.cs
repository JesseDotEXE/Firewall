using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Frome: http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/

public class Screenshake : MonoBehaviour
{

    Vector3 originalCameraPosition;

    public GameObject redScreen;
    private RedFlash flashFX;

    float shakeAmt = 0;

    public Camera mainCamera;

    void Start()
    {
        flashFX = redScreen.GetComponent<RedFlash>();   
        originalCameraPosition = mainCamera.transform.position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("FallingObject"))
        {
            //redScreen.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.25f);
            //shakeAmt = 0.025f;
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
        //redScreen.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0f);
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

}