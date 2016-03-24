//using UnityEngine;
//using System.Collections;

//public class FirewallCollision : MonoBehaviour 
//{
//    private GameObject manager;
//    private ScoreManager scoreManger;

//	// Use this for initialization
//	void OLD_Start () 
//    {
//        manager = GameObject.Find("Managers");
//        scoreManger = manager.GetComponent<ScoreManager>();
//	}
	
//	// Update is called once per frame
//	void Update () 
//    {
	
//	}

//    public IEnumerator LockPort(PortOpenClose poc)
//    {        
//        Debug.Log("Locking Port");
//        poc.portIsLocked = true;
//        yield return new WaitForSeconds(2f);
//        poc.portIsLocked = false;
//        //Destroy(gameObject, 10f);
//        Debug.Log("UnLocking Port");
//        Debug.Log("Done with Corouting");
//    }

//    void OnCollisionEnter2D(Collision2D coll)
//    {
//        if (coll.gameObject.layer == LayerMask.NameToLayer("Firewall"))
//        {
//            if (gameObject.tag == "Data")
//            {
//                //Just destroy.
//                scoreManger.ResetCombo();
//                Destroy(gameObject);
//            }

//            if (gameObject.tag == "Virus")
//            {
//                //Destroy and give points.
//                scoreManger.AddPoints();
//                Destroy(gameObject);
//            }
//        }

//        if (coll.gameObject.layer == LayerMask.NameToLayer("PortAccess"))
//        {
//            if (gameObject.tag == "Data")
//            {
//                //Destroy, give points, and fill up data bar.
//                scoreManger.AddPoints();
//                scoreManger.AddConnection();
//                scoreManger.PrintScore();
//                Destroy(gameObject);
//            }

//            if (gameObject.tag == "Virus")
//            {
//                //Destroy and fill up the virus bar.
//                scoreManger.AddCorruption();
//                Destroy(gameObject);
//            }
//        }

//        //scoreManger.PrintScore();
//    }
//}
