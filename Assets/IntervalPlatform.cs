using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalPlatform : MonoBehaviour {
    public int timeInvisible;
    public int timePhysical;
    private Collider2D player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        InvokeRepeating("setInvisible",timePhysical, timeInvisible + timePhysical);
        InvokeRepeating("setPhysical", 0, timeInvisible + timePhysical);
    }
	
	// Update is called once per frame
	void Update () {
      
        
	}

    void setPhysical()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void setInvisible()
    {

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
