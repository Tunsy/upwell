using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExploder : MonoBehaviour
{
    public float speed;
    public GameObject exploder;
    private Rigidbody2D rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y + speed);
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction;
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != transform.parent.tag)
        {


            Instantiate(exploder, transform);
            Destroy(gameObject);
        }

    }
    
    

    

    
}
