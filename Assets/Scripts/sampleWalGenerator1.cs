using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleWalGenerator1 : MonoBehaviour {

    public int wallNum;
	// Use this for initialization
	void Start () {
        GameObject wall = GameObject.Find("Wall");
		for(float i = 0; i < wallNum; i++)
        {
            GameObject leftWall = GameObject.Instantiate(wall);
            GameObject rightWall = GameObject.Instantiate(wall);
            float y = (float) (6.51 + 10.0 * i - 5.0);
            leftWall.transform.position = new Vector3((float)-8.4, y, 0);
            rightWall.transform.position = new Vector3((float)8.5, y, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
