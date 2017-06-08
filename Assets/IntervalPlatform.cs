using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalPlatform : MonoBehaviour {
    public float timeInvisible;
    public float timePhysical;
    private Collider2D player;
    public AudioClip intervalSound;

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
        if ((player.transform.position - transform.position).magnitude <= 40)
            //AudioSource.PlayClipAtPoint(intervalSound, Camera.main.transform.position);

        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void setInvisible()
    {
        if ((player.transform.position - transform.position).magnitude <= 40)
            //AudioSource.PlayClipAtPoint(intervalSound, Camera.main.transform.position);

        AudioSource.PlayClipAtPoint(intervalSound, Camera.main.transform.position);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
