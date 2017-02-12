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
        float Height = this.GetComponent<Collider2D>().bounds.size.y;
        int x = 200;

        if (collider.name == "Player")
        {
            /*if (Player.y >= Enemy.y && Player.x < Enemy.x + Width / 2 && Player.x > Enemy.x - Width / 2)
            {
                GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2000);
                GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.up * 1000;
            }
            else*/ if (Player.x > Enemy.x && Player.y < Enemy.y + Height / 2)
            {
                GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2000);
                while (x > 0)
                new WaitForSeconds(1);
                {
                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Debug.Log(x);
                    x -= 1;
                }
                x = 200;
            }
            else if (Player.x < Enemy.x && Player.y < Enemy.y + Height / 2)
            {
                GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.left * 2000);
                while (x > 0)
                {
                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Debug.Log(x);
                    x -= 1;
                }
                x = 200;
            }
        }
    }
}
