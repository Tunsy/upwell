using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPivot : MonoBehaviour {

    public int segments;
    public GameObject seg;
    public float radialSpeed;

 
    // Use this for initialization
	void Start () {
        
		for(double i = 0; i < 360; i += 360/ segments)
        {
            GameObject segment = GameObject.Instantiate(seg);
            segment.transform.position = new Vector2(this.transform.position.x,  this.transform.position.y-segment.transform.localScale.y);
            Debug.Log(seg.transform.localScale.y);
            segment.transform.RotateAround(this.transform.position, Vector3.forward, (float)i );
            segment.transform.SetParent(this.transform);
            Debug.Log(seg.transform.localScale.y);
            

        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * radialSpeed);
	}
}
