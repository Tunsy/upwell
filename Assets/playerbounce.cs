using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbounce : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector2 Player = collision.contacts[0].point;
        Vector2 Enemy = collider.bounds.center;
        float Width = this.GetComponent<Collider2D>().bounds.size.x;
        if (collision.gameObject.name == "Enemy")
        {
            if (Player.y > Enemy.y && Player.x < Enemy.x + Width / 2 && Player.x > Enemy.x - Width / 2)
            {
                Debug.Log("Hit");
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15000);
            }
            else
            {

            }
        }
    }
}
