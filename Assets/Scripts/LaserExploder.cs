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
        
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction;
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

    }

    void onDestory()
    {
        Instantiate(exploder, transform);
    }

    

    
}
