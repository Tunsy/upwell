using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //other.SendMessage("here");
        if(other.gameObject.tag != "Wall")
        {
            Destroy(other.gameObject);
        }
    }
}
