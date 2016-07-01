//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;

public class DownwardMovment : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 pos = this.gameObject.transform.position;
        pos.y -= 10;

        transform.position = Vector3.MoveTowards(transform.position, pos, step);
    }
}
