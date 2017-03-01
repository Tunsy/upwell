using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour {

    public float speed;
    private SpriteRenderer msr;

	void Update ()
    {
        transform.Translate(speed, 0, 0);
	}
    void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        speed *= -1;
    }
}
