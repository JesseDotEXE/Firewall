using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DualPortInputLogic : MonoBehaviour 
{
    private GlobalData globalData;
    private InputField dualPortInput;

    // Use this for initialization
    void Start()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        dualPortInput = gameObject.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValueChanged()
    {
        globalData.singlePortPercent = int.Parse(dualPortInput.text);
    }
}
