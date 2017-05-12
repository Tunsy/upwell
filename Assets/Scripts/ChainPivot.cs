using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPivot : MonoBehaviour {

    public int segments;
    public GameObject seg;
    public float radialSpeed;
    public float length;

 
    // Use this for initialization
	void Start () {

        
		for(double i = 0; i < 360; i += 360/ segments)
        {
            GameObject segment = GameObject.Instantiate(seg);
            segment.transform.localScale = new Vector3(seg.transform.localScale.x, length, 0);
            
            //Debug.Log(seg.transform.localScale.x);
            
            //segment.transform.position = new Vector2(this.transform.position.x,  this.transform.position.y-segment.transform.localScale.y);
            //segment.transform.position = new Vector2(transform.position.x, transform.position.y -  );
            //segment.transform.position = new Vector2(transform.position.x, transform.position.y - segment.transform.position.y - segment.transform.localScale.y/2);
            
            segment.transform.SetParent(this.transform);
         
            float y =segment.GetComponent<CapsuleCollider2D>().bounds.extents.y;
            segment.transform.localPosition = new Vector2(0, -y);
            segment.transform.RotateAround(this.transform.position, Vector3.forward, (float)i);


        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * radialSpeed);
	}
}
