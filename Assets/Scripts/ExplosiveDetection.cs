using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDetection : DealDamageToPlayer {
    public float radius;
	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius *= radius;
	}

    private void OnCollisionEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Knockback(this);
        }

       


    }


}
