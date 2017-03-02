﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int x;
    float offset;
    float initial;

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, x), transform.position.y);

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
            {
                offset = GameObject.Find("Player").transform.position.x - transform.position.x;
                other.transform.parent = null;
                other.transform.position = new Vector3(transform.position.x + offset, other.transform.position.y);
                
            }
            else
            {
                other.transform.parent = this.transform;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
