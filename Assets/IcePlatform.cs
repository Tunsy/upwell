using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour {
    public float increasedSpeed;
    public float increasedAccel;
    private float originalSpeed;
    private float originalAccel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            originalSpeed = player.speed;
            originalAccel = player.accel;
            modSpeed(player, increasedSpeed);
            modAccel(player, increasedAccel);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            modSpeed(other.GetComponent<PlayerController>(), originalSpeed);
            modAccel(other.GetComponent<PlayerController>(), originalAccel);
        }
    }

    void modSpeed(PlayerController player, float newSpeed)
    {
        player.speed = newSpeed;
    }

    void modAccel(PlayerController player, float newAccel)
    {
        player.accel = newAccel;
    }
}
