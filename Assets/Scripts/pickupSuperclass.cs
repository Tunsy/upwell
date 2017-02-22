using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSuperclass : MonoBehaviour {
    public int pickupscore;
    private string tag = "Player";
    public AudioClip pickupSound;
    public pickupSuperclass()
    
    {
        pickupscore = 5;
    }

    public void onStart()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag(tag).transform.position.z);
    }

    public void pickupTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            GameManager.instance.updatePickupScore(pickupscore);
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);

            Debug.Log(GameManager.instance.getPlayerScore());
        }
        Destroy(gameObject);
    }
}

