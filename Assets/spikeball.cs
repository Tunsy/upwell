using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeball : MonoBehaviour {

    public float speed;
    bool stun = false;

    void Start ()
    {
        switchfunction();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Player")
        {
            switchfunction();
        }
    }


    void switchfunction()
    {
        int n = Random.Range(0, 5);
        switch (n)
        {
            case 0:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5).normalized * speed;
                break;
            case 1:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5).normalized * speed;
                break;
            case 2:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -7).normalized * speed;
                break;
            case 3:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 5).normalized * speed;
                break;
            case 4:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 9).normalized * speed;
                break;
            case 5:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, -3).normalized * speed;
                break;
        }
    }
}
