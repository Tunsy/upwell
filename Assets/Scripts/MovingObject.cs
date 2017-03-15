using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public GameObject movingobject;
    public float speed;
    public Transform Point;
    public Transform[] points;
    public int pointSelection;

    void Start()
    {
        Point = points[pointSelection];
    }

    void Update()
    {
        //transform.position = new Vector3(Mathf.PingPong(Time.time, x), transform.position.y);
        movingobject.transform.position = Vector3.MoveTowards(movingobject.transform.position, Point.transform.position, Time.deltaTime * speed);
        if (movingobject.transform.position == Point.position)
        {
            pointSelection++;
            if (pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            Point = points[pointSelection];
        }
    }
}
