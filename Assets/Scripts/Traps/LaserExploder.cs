using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExploder : Projectile
{
    public GameObject exploder;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        GameObject expl = GameObject.Instantiate(exploder);
        expl.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        DestroySelf();
    }

    public override void DestroySelf()
    {
        Destroy(gameObject);
    }
}
