using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //other.SendMessage("here");
        Destroy(other.gameObject);
    }
}
