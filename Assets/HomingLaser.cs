using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : MonoBehaviour {
    private GameObject target;
    public float speed;
    public GameObject explosionParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        /*Quaternion rotation;
        Vector2 diff = -transform.position + target.transform.position;

        float ang = Vector2.Angle(new Vector2(1, 0), diff);
        if (diff.y < 0)
        {
            ang *= -1;
        }

        rotation = Quaternion.Euler(0, 0, ang);

        transform.rotation = rotation;
        rb.rotation = ang;
        rb.velocity = new Vector2((target.transform.position.x - transform.position.x) * speed, (target.transform.position.y - transform.position.y) * speed);
        */
        transform.position = (Vector2)Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
