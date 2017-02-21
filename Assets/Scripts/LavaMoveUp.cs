using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMoveUp : MonoBehaviour
{
    public GameObject player;
    //private Rigidbody2D rb;
    public float upSpeed;
    public float maxDistance;
    public float catchUp; //speed to use if player and destroyer are too far apart

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); //might use this later for smoother destroyer accel/decel
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 destroyerPos = transform.position;
        Vector2 playerPos = player.transform.position;
        if ((destroyerPos - playerPos).magnitude > maxDistance)
        {
            Debug.Log("catch up");
            transform.position = new Vector2(transform.position.x, transform.position.y + (catchUp * Time.deltaTime));
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (upSpeed * Time.deltaTime));
        }
    }
}
