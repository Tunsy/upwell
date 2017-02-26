using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMoveUp : MonoBehaviour
{
    private PlayerController player;
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
        upSpeed *= GameManager.instance.currentLevel();
        //if(GameManager.instance.isAlive())
        //{
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
        //}
    }
}
