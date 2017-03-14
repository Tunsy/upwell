using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedLaserCannonAim : MonoBehaviour {

    public GameObject target;
    
    private Quaternion rotation = Quaternion.identity;
    private Vector3 midPoint;
    public float chargeTime;
    public GameObject focusLaser;
    public float timer;
    public bool fixedLocation = true;
	// Use this for initialization
	void Start () {
        Vector2 diff = -transform.position  + target.transform.position;

        float ang = Vector2.Angle(new Vector2(1,0), diff);
        if (diff.y < 0)
        {
            ang *= -1;
        }
       
        rotation = Quaternion.Euler(0, 0 , ang);
        midPoint = new Vector3((transform.position.x + target.transform.position.x) / 2, (transform.position.y + target.transform.position.y) / 2, 0);
       
        
    }
    
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= chargeTime)
        {
            timer = 0;
            shootStream();
        }
        
    }

    void shootStream()
    {
        if (!fixedLocation)
        {
            Vector2 diff = -transform.position + target.transform.position;

            float ang = Vector2.Angle(new Vector2(1, 0), target.transform.position - transform.position);
            if (diff.y < 0)
            {
                ang *= -1;
            }
           
            rotation = Quaternion.Euler(0, 0, ang);
            midPoint = new Vector3((transform.position.x + target.transform.position.x) / 2, (transform.position.y + target.transform.position.y) / 2, 0);
        }
        GameObject proj = GameObject.Instantiate(focusLaser, midPoint, rotation);
        float scale = (float)1;
        //Debug.Log(Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2) + Mathf.Pow(transform.position.y - target.transform.position.y, 2)));
        proj.transform.localScale += new Vector3( Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2) + Mathf.Pow(transform.position.y - target.transform.position.y, 2)) * scale, 0, 0);
        //proj.transform.position = midPoint;
       // proj.transform.rotation = rotation;
    }
}
