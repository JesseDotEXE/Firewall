//using UnityEngine;
//using System.Collections;

//public class OLD_PatternManager : MonoBehaviour 
//{
//    ArrayList patterns = new ArrayList();    

//	// Use this for initialization
//	void Awake () 
//    {
//        FillPatterns();
//        Debug.Log(ToString());
//	}

//    void Start()
//    {

//    }
	
//	// Update is called once per frame
//	void Update () 
//    {
//	    //Nothing
//	}

//    void FillPatterns()
//    {
//        //Patterns will be in "XXX" format.
//        //"D" = Data, "V" = Virus, "B" = Bomb, "X" = Blank

//        patterns.Add("XXXX");
//        patterns.Add("XXXV");
//        patterns.Add("XXXD");
//        patterns.Add("XXVX");
//        patterns.Add("XXVV");
//        patterns.Add("XXVD");
//        patterns.Add("XXDX");
//        patterns.Add("XXDV");
//        patterns.Add("XXDD");
//        patterns.Add("XVXX");
//        patterns.Add("XVXV");
//        patterns.Add("XVXD");
//        patterns.Add("XVVX");
//        patterns.Add("XVVV");
//        patterns.Add("XVVD");
//        patterns.Add("XVDX");
//        patterns.Add("XVDV");
//        patterns.Add("XVDD");
//        patterns.Add("XDXX");
//        patterns.Add("XDXV");
//        patterns.Add("XDXD");
//        patterns.Add("XDVX");
//        patterns.Add("XDVV");
//        patterns.Add("XDVD");
//        patterns.Add("XDDX");
//        patterns.Add("XDDV");
//        patterns.Add("XDDD");
//        patterns.Add("VXXX");
//        patterns.Add("VXXV");
//        patterns.Add("VXXD");
//        patterns.Add("VXVX");
//        patterns.Add("VXVV");
//        patterns.Add("VXVD");
//        patterns.Add("VXDX");
//        patterns.Add("VXDV");
//        patterns.Add("VXDD");
//        patterns.Add("VVXX");
//        patterns.Add("VVXV");
//        patterns.Add("VVXD");
//        patterns.Add("VVVX");
//        patterns.Add("VVVV");
//        patterns.Add("VVVD");
//        patterns.Add("VVDX");
//        patterns.Add("VVDV");
//        patterns.Add("VVDD");
//        patterns.Add("VDXX");
//        patterns.Add("VDXV");
//        patterns.Add("VDXD");
//        patterns.Add("VDVX");
//        patterns.Add("VDVV");
//        patterns.Add("VDVD");
//        patterns.Add("VDDX");
//        patterns.Add("VDDV");
//        patterns.Add("VDDD");
//        patterns.Add("DXXX");
//        patterns.Add("DXXV");
//        patterns.Add("DXXD");
//        patterns.Add("DXVX");
//        patterns.Add("DXVV");
//        patterns.Add("DXVD");
//        patterns.Add("DXDX");
//        patterns.Add("DXDV");
//        patterns.Add("DXDD");
//        patterns.Add("DVXX");
//        patterns.Add("DVXV");
//        patterns.Add("DVXD");
//        patterns.Add("DVVX");
//        patterns.Add("DVVV");
//        patterns.Add("DVVD");
//        patterns.Add("DVDX");
//        patterns.Add("DVDV");
//        patterns.Add("DVDD");
//        patterns.Add("DDXX");
//        patterns.Add("DDXV");
//        patterns.Add("DDXD");
//        patterns.Add("DDVX");
//        patterns.Add("DDVV");
//        patterns.Add("DDVD");
//        patterns.Add("DDDX");
//        patterns.Add("DDDV");
//        patterns.Add("DDDD");

//        Debug.Log(patterns.Count + " patterns have been made.");

//        //For quick filling.
//        //for(int i = 0; i < 30; i++)
//        //{
//        //    patterns.Add("VVV");
//        //}
//    }

//    public string GetPattern(int num) 
//    {
//        //Debug.Log("Patterns length: " + patterns.Count);
//        //Debug.Log("Patterns Man, selected: " + patterns[num]);
//        return (string)patterns[num];
//    }

//    private string ToString()
//    {
//        string stuff = "";
//        for(int i = 0; i < patterns.Count; i++)
//        {
//            stuff += patterns[i];
//        }
//        return stuff;
//    }
//}
