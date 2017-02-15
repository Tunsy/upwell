using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour {
    private string tag = "Player";
    public int value = 5;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tag)
        {
            GameManager.instance.updatePickupScore(value);
        }
        Destroy(this);
    }

    
}
