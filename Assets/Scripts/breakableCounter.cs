using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableCounter : MonoBehaviour {
    public int durability;


    private void Start()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            durability -= 1;
            if (durability == 0)
            {
                Destroy(gameObject);
            }
        }
    }
   

    
}
