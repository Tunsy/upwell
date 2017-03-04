using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickupScript : pickupSuperclass {


        public BasePickupScript()
        {
            pickupscore = base.pickupscore;
            pickupSound = base.pickupSound;
        }

        private void Start()
        {
            base.onStart();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            base.pickupTrigger(collision);
        Destroy(gameObject);
        }


}
