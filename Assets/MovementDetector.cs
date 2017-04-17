using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour {

	void Start()
    {
        Time.timeScale = 0;
    }
	void Update ()
    {
		if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            Time.timeScale = 1;
            Destroy(this);
        }
	}
}
