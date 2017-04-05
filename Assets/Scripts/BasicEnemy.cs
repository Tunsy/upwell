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
            //BEFORE : Because collisions can clip through because frame rate isn't fast enough, the contact point of the collision (the feet of the player)
            //  would be below the height of the enemy, thus the player would also be knocked back. Just compared the centers of the player and the enemy now.
            //Vector3 player = collision.contacts[0].point;
            Vector3 playerLocation = collision.transform.position;

            //Debug.LogFormat("Player Height: {0} | Enemy Height: {1}", playerLocation.y, transform.position.y);

            if (playerLocation.y >= transform.position.y/* + height*/)
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

    void Death()
    {
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
