using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedLaserCannonAim : MonoBehaviour {

    public GameObject target;
    
    private Quaternion rotation = Quaternion.identity;
    private Vector3 midPoint;
    public GameObject focusLaser;
	// Use this for initialization
	void Start () {
        float ang = Vector2.Angle(gameObject.transform.position, target.gameObject.transform.position);
        rotation = Quaternion.Euler(0, 0 , ang);
        midPoint = new Vector3((transform.position.x + target.transform.position.y) / 2, (transform.position.y + target.transform.position.y) / 2);
        Debug.Log(rotation);
        GameObject proj = GameObject.Instantiate(focusLaser);
        
        //Debug.Log(Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2) + Mathf.Pow(transform.position.y - target.transform.position.y, 2)));
        proj.transform.localScale += new Vector3(1, Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2) + Mathf.Pow(transform.position.y - target.transform.position.y, 2)),  0);
        proj.transform.position = midPoint;
        proj.transform.rotation = rotation;
    }
    
	
	// Update is called once per frame
	void Update () {
        
	}
}
