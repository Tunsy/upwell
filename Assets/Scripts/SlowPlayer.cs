using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            modSpeed(other.GetComponent<PlayerController>(), 4f);
            modJump(other.GetComponent<PlayerController>(), 4f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            modSpeed(other.GetComponent<PlayerController>(), 14f);
            modJump(other.GetComponent<PlayerController>(), 14f);
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
