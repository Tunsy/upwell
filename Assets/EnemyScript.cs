using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector2 Enemy = collision.contacts[0].point;
        Vector2 Player = collider.bounds.center;
        float Width = this.GetComponent<Collider2D>().bounds.size.x;
        
        if (Player.y > Enemy.y && Player.x < Enemy.x + Width / 2 && Player.x > Enemy.x - Width / 2)
        {
            Debug.Log("Hit");
            GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up*15000);
        }
        else
        {

        }
    }
}
