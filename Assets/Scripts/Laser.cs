﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;


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

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
