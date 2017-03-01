using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDetection : DealDamageToPlayer {
    public float radius;
    public float delay;
	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius *= radius;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Knockback(this);
        }

       


    }

    void selfDestruct()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Invoke("selfDestruct", delay);
    }


}
