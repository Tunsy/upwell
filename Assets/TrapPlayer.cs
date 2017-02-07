using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayer : MonoBehaviour
{
    private Collider2D trap;
    float timeLeft = 1.0f;
    bool timerCheck = false;

    void Start()
    {
        trap = GetComponent<Collider2D>();
        Debug.Log("trap");
    }

    void Update()
    {
        //if (trap.IsTouching(GetComponent<Collider2D>()))
        //{
        if (timerCheck) 
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0)
        {
            Debug.Log("out of time");
            //modSpeed(GetComponent<PlayerController>(), 14f);
            //modJump(GetComponent<PlayerController>(), 14f);
            timerCheck = false;
        }
        //}
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            modSpeed(coll.GetComponent<PlayerController>(), 0);
            modJump(coll.GetComponent<PlayerController>(), 0);
            timeLeft = 1.0f;
            timerCheck = true;
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
