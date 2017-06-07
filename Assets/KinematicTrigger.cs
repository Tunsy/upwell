using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicTrigger : MonoBehaviour {
    public GameObject spawn;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 )
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            Destroy(gameObject);
            
        }


    }

    private void OnDestroy()
    {
        Instantiate(spawn, transform.position, Quaternion.identity);
    }
}
