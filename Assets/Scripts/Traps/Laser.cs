using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        DestroySelf();
    }

    public override void DestroySelf()
    {
        Destroy(gameObject);
    }
}
