//Author: Jesus Villagomez - JesseDotEXE
//References: N/A


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour 
{
 //   private Image fadeScreen;
 //   public float fadeSpeed = 2f;
 //   private float currentAlpha;
 //   private bool sceneStarting = true;
 //   public string sceneToLoad;

 //   // Use this for initialization
 //   void Start () 
 //   {
 //       fadeScreen = GetComponent<Image>();
 //       currentAlpha = 0f;
	//}
	
	//// Update is called once per frame
	//void Update () 
 //   {
	    
	//}

 //   void FadeToClear() 
 //   {
 //       fadeScreen.color = Color.Lerp(fadeScreen.color, Color.clear, fadeSpeed * Time.deltaTime);
 //   }

 //   void FadeToBlack()
 //   {
 //       fadeScreen.color = Color.Lerp(fadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
 //   }

 //   //void StartScene()
 //   //{
 //   //    // Fade the texture to clear.
 //   //    FadeToClear();

 //   //    // If the texture is almost clear...
 //   //    if (fadeScreen.color.a <= 0.05f)
 //   //    {
 //   //        // ... set the colour to clear and disable the GUITexture.
 //   //        fadeScreen.color = Color.clear;
 //   //        fadeScreen.enabled = false;

 //   //        // The scene is no longer starting.
 //   //        sceneStarting = false;
 //   //    }
 //   //}


 //   public void EndScene()
 //   {
 //       // Start fading towards black.
 //       FadeToBlack();

 //       // If the screen is almost black...
 //       if (fadeScreen.color.a >= 0.95f)
 //           SceneManager.LoadScene(sceneToLoad);
 //   }
}
