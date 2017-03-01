using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDamage : DealDamageToPlayer {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Knockback(this);
        }

        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }


    }
}
