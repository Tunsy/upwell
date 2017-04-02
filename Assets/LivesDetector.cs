using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDetector : MonoBehaviour {

    private int lives;
    public GameObject retrybutton;

	void Update ()
    {

		if(lives == 0 || lives < 0)
        {
            retrybutton.SetActive(false);
        }
	}
}
