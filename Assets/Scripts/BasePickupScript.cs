using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickupScript : pickupSuperclass {


        public BasePickupScript()
        {
            pickupscore = base.pickupscore;
            pickupSound = base.pickupSound;
        }

        

        

    
        public override void collisionSettings()
    {
        GameManager.instance.updatePickupScore(pickupscore);
    }


}
