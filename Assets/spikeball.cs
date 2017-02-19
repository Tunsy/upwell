using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeball : MonoBehaviour {

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
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
                break;
            case 1:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5);
                break;
            case 2:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -7);
                break;
            case 3:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 5);
                break;
            case 4:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 9);
                break;
            case 5:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, -3);
                break;
        }
    }
}
