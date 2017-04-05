using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMoveUp : MonoBehaviour
{
    private PlayerController player;
    private bool playerReady = false;
    public float upSpeed;
    public float maxDistance;
    public float catchUp; //speed to use if player and destroyer are too far apart

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //maxDistance = 6.7f;
        //catchUp = 6;
    }

    // Update is called once per frame
    void Update()
    {
        //Don't start moving until after the player presses a key
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetKeyDown(KeyCode.Space))
        {
            playerReady = true;
        }
        //if(GameManager.instance.isAlive())
        //{
        if (player != null && playerReady)
        {
            Vector2 destroyerPos = transform.position;
            Vector2 playerPos = player.transform.position;
            //Debug.Log(playerPos.y - destroyerPos.y);
            if ((playerPos.y - destroyerPos.y) > maxDistance)
            {
                //Debug.Log("catch up");
                transform.position = new Vector2(transform.position.x, transform.position.y + (catchUp * Time.deltaTime));
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + (upSpeed * Time.deltaTime));
            }
        }
    }

    
}
