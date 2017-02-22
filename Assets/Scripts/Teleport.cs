using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject door2;
    //public GameObject destroyer;
    private Transform spawnPoint;

	// Use this for initialization
	void Start () 
    {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = door2.transform.position;
            other.gameObject.transform.rotation = door2.transform.rotation;
        }
    }
}
