using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaserCannon : MonoBehaviour {
    public float chargeTime;
    public GameObject laser;
    private GameObject player;
    Quaternion rotation;
    float timer = 0;
    Transform spawn;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
        rotation = transform.rotation;
        spawn = transform.GetChild(0);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

        if (Physics2D.Raycast((Vector2)transform.position, (Vector2)(player.transform.position - transform.position)).collider.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= chargeTime)
            {
                timer = 0;
                shoot();
            }

        }
    }

    void shoot()
    {
        GameObject proj = GameObject.Instantiate(laser, spawn.position, rotation);
    }
}
