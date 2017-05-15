using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

    bool stun = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector2 Enemy = collision.contacts[0].point;
        Vector2 Player = collider.bounds.center;
        var playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        float Width = this.GetComponent<Collider2D>().bounds.size.x;
        float Height = this.GetComponent<Collider2D>().bounds.size.y;

        if (collider.name == "Player")
        {
            if (Player.y >= Enemy.y && Player.x < Enemy.x + Width / 2 && Player.x > Enemy.x - Width / 2)
            {   // If above a spike
                if(Player.x > Enemy.x)
                {
                    Debug.Log("Above right");
                    playerrb.AddForce(Vector2.right * 800);
                    playerrb.velocity = Vector2.down * 10;
                }
                else
                {
                    Debug.Log("Above Left");
                    playerrb.AddForce(Vector2.right * -800);
                    playerrb.velocity = Vector2.down * 10;
                }
                stunned();
            }
            /*else if (Player.y < Enemy.y && Player.x < Enemy.x + Width / 2 && Player.x > Enemy.x - Width / 2)
            {   // If below a spike
                Debug.Log("Below");
                playerrb.velocity = Vector2.down * 10;
                stunned();
            }*/
            else if (Player.x > Enemy.x && Player.y < Enemy.y + Height / 2)
            {   //If on the right of a spike
                Debug.Log("Right");
                playerrb.AddForce(Vector2.right * 600);
                playerrb.velocity = Vector2.down * 10;
                stunned();
            }
            else if (Player.x < Enemy.x && Player.y < Enemy.y + Height / 2)
            {   //If on left of a spike
                Debug.Log("Left");
                playerrb.AddForce(Vector2.right * -600);
                playerrb.velocity = Vector2.down * 10;
                stunned();
            }

        }
    }

    void stunned()
    {
        if (stun == false)
        {
            stun = true;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            Invoke("timer", 3f);
        }
    }
}
