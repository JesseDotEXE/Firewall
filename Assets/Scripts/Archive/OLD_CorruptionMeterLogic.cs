//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class OLD_CorruptionMeterLogic : MonoBehaviour 
//{
//    public GameObject scoreGameObject;

//    private ScoreManager scoreManager;
//    private Text corruptionText;
//    private int corruptionMeter;

//    // Use this for initialization
//    void Start () 
//    {
//        scoreManager = scoreGameObject.GetComponent<ScoreManager>();
//        corruptionText = gameObject.GetComponent<Text>();
//        corruptionMeter = 0;
//    }
	
//	// Update is called once per frame
//	void Update () 
//    {
//        corruptionMeter = scoreManager.GetCorruption();
//        corruptionText.text = "Corruption: " + corruptionMeter;
//	}
//}
