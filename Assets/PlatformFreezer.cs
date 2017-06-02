using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFreezer : MonoBehaviour {
    public float freeze_time = 3;
    public float slow_factor = 5;
    private bool shootable;

	// Use this for initialization
	void Start () {
        shootable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (shootable && collision.gameObject.tag == "Bullit")
        {
            
            slowMod();
            Invoke("speedMod", freeze_time);
        }
    }

    void speedMod()
    {
        gameObject.GetComponent<MovingPlatform>().speed *= slow_factor;
        shootable = true;
    }
    void slowMod()
    {
        gameObject.GetComponent<MovingPlatform>().speed /= slow_factor;
        shootable = false;
    }

}
