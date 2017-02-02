using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {

    public float upSpeed;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
            transform.position = new Vector2(transform.position.x, transform.position.y + (upSpeed * Time.deltaTime));
	}
}
