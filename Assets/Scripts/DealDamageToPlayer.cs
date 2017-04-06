using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour {

    public float knockDuration;
    public float verticalKnockPower;
    public float horizontalKnockPower;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            Debug.Log(this.gameObject.ToString());
            collision.GetComponent<PlayerController>().Knockback(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if(GetComponent<BasicEnemy>() == null)
                collision.gameObject.GetComponent<PlayerController>().Knockback(this);
        }
    }
}
