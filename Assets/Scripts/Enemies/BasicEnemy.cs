using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {
    public float speed;
    public float interval;
    private float timer;
    private float pauseTimer;
    private bool isPaused;

    private float width; 
    private float height;

    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Collider2D collider;
    public AudioClip deathSound;
    public int Health = 1;

    void Start()
    {
        SwitchDirection();
        collider = GetComponent<Collider2D>();
        height = collider.bounds.extents.y;
        width = collider.bounds.extents.x;
        timer = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            //Vector3 player = collision.contacts[0].point;
            Vector3 player = collision.transform.position;

            //if (player.y >= transform.position.y + height)
            //{
            if (player.y > transform.position.y + height)
            {
                PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
                pc.rb.velocity = new Vector2(pc.rb.velocity.x, pc.jump);
                Death();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().Knockback(GetComponent<DealDamageToPlayer>());
            }
        }
    }
    
    public void Hit()
    {
        Health -= 1;
        if(Health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (deathSound)
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval && !isPaused)
        {
            StartCoroutine("PauseMovement");
        }
    }

    void SwitchDirection()
    {
        int n = Random.Range(0, 5);
        switch (n)
        {
            case 0:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0).normalized * speed;
                sprite.flipX = true;
                break;
            case 1:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0).normalized * speed;
                sprite.flipX = true;
                break;
            case 2:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0).normalized * speed;
                sprite.flipX = false;
                break;
            case 3:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0).normalized * speed;
                sprite.flipX = false;
                break;
        }
    }

    public IEnumerator PauseMovement()
    {
        isPaused = true;
        float pauseTime = Random.Range(1, 4);
        yield return new WaitForSeconds(pauseTime);
        timer = 0;
        isPaused = false;
        SwitchDirection();
    }
}
