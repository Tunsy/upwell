using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStream : Projectile {

	// Use this for initialization
	void Start () {
        speed = 0;
        Invoke("DestroySelf", (float) 0.3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void  DestroySelf()
    {
        Destroy(gameObject);
    }

    public override void  OnTriggerEnter2D(Collider2D collision)
    {

    }
}
