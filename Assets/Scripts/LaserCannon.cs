using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour 
{
    public GameObject laser;
    private GameObject shot;
    private float timer = 0;
    public float shootInterval;

	void Start() 
    {
        //Generate();
	}
	
	void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootInterval)
        {
            Generate();
            timer = 0;
        }
	}

    void Generate()
    {
        shot = (GameObject)Instantiate(laser, new Vector2(transform.position.x + 1.75f, transform.position.y), transform.rotation);
    }
}
