using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour 
{
    private CrusherGS groundState;
    private Rigidbody2D rb;
    private Vector3 spawnPosition;

    void Awake()
    {
        spawnPosition = transform.position;
    }

	void Start() 
    {
        groundState = GetComponent<CrusherGS>();		
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate() 
    {
		if (groundState.IsGround())
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }
        else if (transform.position == spawnPosition)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
