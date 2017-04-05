using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    private float width;
    private float height;
    private Collider2D collider;

    void Start()
    {
        height = collider.bounds.extents.y;
        width = collider.bounds.extents.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
}
