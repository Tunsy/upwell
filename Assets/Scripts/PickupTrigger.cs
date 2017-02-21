using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour {
    private string tag = "Player";
    public int value = 5;
    // Use this for initialization
    void onStart()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag(tag).transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tag)
        {
            GameManager.instance.updatePickupScore(value);
            Debug.Log(GameManager.instance.getPlayerScore());
        }
        Destroy(gameObject);
    }

    
}
