using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    void FixedUpdate()
    {
        Vector2 Player = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, Player, .05f);
        //transform.rotation = Quaternion.LookRotation(Player);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
