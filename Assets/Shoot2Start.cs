using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2Start : MonoBehaviour {
    public float starting_speed;
    private bool off = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(off && collision.gameObject.tag == "Bullit")
        {
            gameObject.GetComponent<MovingPlatform>().speed = starting_speed;
        }
    }
}
