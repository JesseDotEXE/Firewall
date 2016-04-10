using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButtonLogic : MonoBehaviour 
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        DestroyAllGameObjects();
        Debug.Log("Back button clicked!");
        SceneManager.UnloadScene("ColorPrototype");
        SceneManager.LoadScene("DebugMenu");
    }

    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }
}
