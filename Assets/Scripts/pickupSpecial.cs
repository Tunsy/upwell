using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpecial : pickupSuperclass {
    

	public pickupSpecial()
    {
        pickupscore = 10;
        pickupSound = base.pickupSound;

    }

    private void Start()
    {
        base.onStart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.pickupTrigger(collision);
    }
}
