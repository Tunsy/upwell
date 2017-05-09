using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            hit.gameObject.GetComponent<BasicEnemy>().Hit();
            Destroy(this);
        }
    }
}
