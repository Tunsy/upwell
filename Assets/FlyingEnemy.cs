using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    public int x;
    public int y;

    void Update()
    {
        if (x == 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, y));
        }
        else if(y == 0)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time, x), transform.position.y);
        }
        else
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time, x), Mathf.PingPong(Time.time, y));
        }
    }
}
