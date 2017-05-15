using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pickupSuperclass : MonoBehaviour {
    public int pickupscore;
    private string tag = "Player";
    public AudioClip pickupSound;
   public pickupSuperclass()
    
    {
        pickupscore = 5;
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == tag)
        {

            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);


            collisionSettings();
        }
        

        Destroy(gameObject);
    }

    
    

     abstract public void collisionSettings();
    

    
}

