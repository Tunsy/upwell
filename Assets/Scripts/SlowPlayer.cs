using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour {

    public float slowSpeed;
    public float slowJump;
    private float originalSpeed;
    private float originalJump;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            originalSpeed = player.speed;
            originalJump = player.jump;
            modSpeed(player, slowSpeed);
            modJump(player, slowJump);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            modSpeed(other.GetComponent<PlayerController>(), originalSpeed);
            modJump(other.GetComponent<PlayerController>(), originalJump);
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
