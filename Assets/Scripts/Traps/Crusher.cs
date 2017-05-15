using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour 
{
    public float speed;
    private CrusherGS groundState;
    private Rigidbody2D rb;
    private Collider2D coll;
    private Vector3 spawnPosition;
    private float width;
    private float height;
    

    void Awake()
    {
        spawnPosition = transform.position;
    }

	void Start() 
    {
        groundState = GetComponent<CrusherGS>();
        coll = GetComponent<Collider2D>();	
        rb = GetComponent<Rigidbody2D>();
        width = coll.bounds.size.x;
        height = coll.bounds.size.y;
	}

    void FixedUpdate() 
    {
		if (groundState.IsGround())
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (transform.position == spawnPosition)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * speed);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Crush and kill the player
            PlayerController player = GetComponent<PlayerController>();
            Vector2 playerBounds = collision.bounds.center;
            Vector2 crusherBounds = coll.bounds.center;

            if (playerBounds.y <= crusherBounds.y && playerBounds.x < crusherBounds.x + width / 2 && playerBounds.x > crusherBounds.x - width / 2)
            {
                //Destroy(collision.gameObject);
                GameManager.instance.killPlayer();
            }
        }
    }
}
