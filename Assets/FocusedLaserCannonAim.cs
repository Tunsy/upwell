using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedLaserCannonAim : MonoBehaviour {

    public GameObject target;
    
    private float rotation;
    public GameObject focusLaser;
	// Use this for initialization
	void Start () {
       
        rotation = Vector2.Angle(gameObject.transform.position, target.gameObject.transform.position);
        Debug.Log(rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
