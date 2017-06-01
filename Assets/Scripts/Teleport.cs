using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject destination;
    private SpriteRenderer playerSprite;
    private SpriteRenderer sr;
    private PlayerController player;
    public bool onEnterInvert; //always set BOTH the entrance door AND the destination door to true when inverting physics.
    private Transform spawnPoint;
    public bool isCheckPoint = false; //set true on the teleporter that teleports to next area, NOT the exiting teleporter
    public Sprite reverseSprite;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();

        if (onEnterInvert)
        {
            sr.sprite = reverseSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isCheckPoint)
            {
                GameManager.instance.updateCurrentLevel();
            }
            if (destination != null)
            {
                other.gameObject.transform.position = destination.transform.position;
                other.gameObject.transform.rotation = destination.transform.rotation;
            }
            if (onEnterInvert)
            {
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
                player.GetComponent<PlayerController>().SetInvert(false);
            }
        }
    }
}
