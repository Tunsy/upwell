using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject destination;
    private SpriteRenderer playerSprite;
    private PlayerController player;
    public bool onEnterInvert; //always set BOTH the entrance door AND the destination door to true when inverting physics.
    private Transform spawnPoint;
    public bool isCheckPoint = false; //set true on the teleporter that teleports to next area, NOT the exiting teleporter

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isCheckPoint)
            {
                GameManager.instance.updateCurrentLevel();
            }
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
