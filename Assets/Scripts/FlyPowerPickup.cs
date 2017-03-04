﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPowerPickup : pickupSuperclass
{

    public float flyTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.pickupTrigger(collision);
        GameObject.Find("Player").GetComponent<PlayerController>().giveFlyPower(flyTime);
        Destroy(gameObject);
    }

    
}
