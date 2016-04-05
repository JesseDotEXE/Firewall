using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedInputLogic : MonoBehaviour 
{
    private GlobalData globalData;
    private InputField speedInput;

    // Use this for initialization
    void Start()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        speedInput = gameObject.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValueChanged()
    {
        globalData.objMoveSpeed = float.Parse(speedInput.text);
    }
}
