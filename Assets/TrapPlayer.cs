using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayer : MonoBehaviour
{
    private Collider2D trap;
    //private GameObject player;
    float timeLeft = 10.0f;

    void Start()
    {
        trap = GetComponent<Collider2D>();
        //player = GetComponent<GameObject>();
    }

    void Update()
    {
        //if (trap.IsTouching(player.GetComponent<Collider2D>()))
        //{
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //modSpeed(player.GetComponent<PlayerController>(), 14f);
                //modJump(player.GetComponent<PlayerController>(), 14f);
            }
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            modSpeed(other.GetComponent<PlayerController>(), 0);
            modJump(other.GetComponent<PlayerController>(), 0); 
        }
    }

    void modSpeed(PlayerController player, float newSpeed)
    {
        player.speed = newSpeed;
    }

    void modJump(PlayerController player, float newJump)
    {
        player.jump = newJump;
    }
}
