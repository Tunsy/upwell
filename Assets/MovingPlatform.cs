using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int x;
    bool Playertouching = false;
    float offset;

	void Update ()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, x), transform.position.y);
        if(Playertouching == true)
        {
                offset = GameObject.Find("Player").transform.position.x - transform.position.x;
                GameObject.Find("Player").transform.position = new Vector3(transform.position.x + offset, GameObject.Find("Player").transform.position.y);

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
            {
                Playertouching = false;
            }
            else
            {
                Playertouching = true;
            }
        }
    }
}
