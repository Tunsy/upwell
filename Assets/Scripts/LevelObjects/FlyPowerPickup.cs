using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPowerPickup : pickupSuperclass
{

    public float flyTime;

    public override void collisionSettings()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().giveFlyPower(flyTime);
    }


}
