using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {
    private Collider2D hitbox;
    public AudioClip destroySound;

    void Start()
    {
        //hitbox = FindObjectOfType<DestroyerHitBox>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(destroySound != null)
            {
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            }

            Destroy(other.gameObject);
            GameManager.instance.killPlayer();
        }
    }
}
