using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour {

    public float knockDuration;
    public float verticalKnockPower;
    public float horizontalKnockPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            collision.GetComponent<PlayerController>().Knockback(this);
        }
    }
}
