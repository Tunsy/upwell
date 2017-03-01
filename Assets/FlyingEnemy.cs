using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    Vector3 start;
    Vector3 End;
    public int x;
    public int y;

    void Start()
    {
        start = transform.position;
        End = new Vector3(start.x + x, start.y + y, 0);
    }
    void Update()
    {
        if (transform.position == start)
        {
            transform.Translate(End);
        }
        else if(transform.position == End)
        {
            transform.Translate(start.x, start.y, 0);
        }
    }
}
