using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {
    public float speed;
    public float interval;
    private float timer;
    public SpriteRenderer sprite;

    private Rigidbody2D rb;

    void Start()
    {
        switchfunction();
        timer = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Player")
        {
            
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            switchfunction();
            timer = 0;
        }
    }

    void switchfunction()
    {
        int n = Random.Range(0, 5);
        switch (n)
        {
            case 0:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0).normalized * speed;
                sprite.flipX = false;
                break;
            case 1:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0).normalized * speed;
                sprite.flipX = false;
                break;
            case 2:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0).normalized * speed;
                sprite.flipX = true;
                break;
            case 3:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0).normalized * speed;
                sprite.flipX = true;
                break;
        }
    }
}
