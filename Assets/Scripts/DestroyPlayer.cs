using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    private Collider2D hitbox;

    void Start()
    {
        //hitbox = FindObjectOfType<DestroyerHitBox>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameManager.instance.killPlayer();
        }
    }
}
