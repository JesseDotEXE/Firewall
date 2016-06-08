using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour 
{
    //Scrolling speed
    public Vector2 speed = new Vector2(0.0f, 0.05f);
    public Vector2 direction = new Vector2(0, -1);

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        if (gameObject.transform.position.y <= -15f)
        {
                var bgPos = gameObject.transform.position;
                bgPos.y += 30f;
                gameObject.transform.position = bgPos;

        }
        // Movement
        var movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
    
}
