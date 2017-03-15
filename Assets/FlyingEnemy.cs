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
            Vector3 player = collision.contacts[0].point;

            if (player.y >= transform.position.y + height)
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
