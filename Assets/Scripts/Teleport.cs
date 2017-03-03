using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject destination;
    private SpriteRenderer playerSprite;
    private PlayerController player;
    public bool onEnterInvert; //always set BOTH the entrance door AND the destination door to true when inverting physics.
    private Transform spawnPoint;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = destination.transform.position;
            other.gameObject.transform.rotation = destination.transform.rotation;
            if (onEnterInvert)
            {
                playerSprite.flipY = true;
                player.GetComponent<PlayerController>().SetInvert(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!onEnterInvert)
            {
                playerSprite.flipY = false;
                player.GetComponent<PlayerController>().SetInvert(false);
            }
        }
    }
}
