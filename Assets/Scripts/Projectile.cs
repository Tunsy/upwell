using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public float speed;
    protected Rigidbody2D rb;

    public abstract void OnTriggerEnter2D(Collider2D other);
    public abstract void DestroySelf();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", 10.0f);
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction;
        rb.velocity = new Vector2(rb.velocity.x * speed, rb.velocity.y * speed);
    }
}
