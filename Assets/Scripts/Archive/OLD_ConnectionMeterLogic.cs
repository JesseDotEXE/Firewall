//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class OLD_ConnectionMeterLogic : MonoBehaviour 
//{
//    public GameObject scoreGameObject;

//    private ScoreManager scoreManager;
//    private Text connectionText;
//    private int connectionMeter;

//     Use this for initialization
//    void Start()
//    {
//        scoreManager = scoreGameObject.GetComponent<ScoreManager>();
//        connectionText = gameObject.GetComponent<Text>();
//        connectionMeter = 0;
//    }

//     Update is called once per frame
//    void Update()
//    {
//        connectionMeter = scoreManager.GetConnection();
//        connectionText.text = "Connection: " + connectionMeter;
//    }
//}
