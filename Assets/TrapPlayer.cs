using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayer : MonoBehaviour
{
    private Collider2D trap;
    private float timeStunned;
    float timeLeft;
    bool isActivated;

    void Start()
    {
        timeStunned = GetComponent<DealDamageToPlayer>().knockDuration;
        trap = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Only start the timer if the player has entered the trap
        if (isActivated)
        {
            timeStunned -= Time.deltaTime;

            if (timeStunned <= 0)
            {
                DestroySelf();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ActivateTrap();
        }
    }

    private void ActivateTrap()
    {
        isActivated = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
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
