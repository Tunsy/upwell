using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour 
{
    public GameObject laser;
    private Transform spawnPoint;
    private GameObject shot;
    private float timer = 0;
    public float shootInterval;

	void Start() 
    {
        spawnPoint = transform.GetChild(0);
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
        GameObject shot = (GameObject)Instantiate(laser, spawnPoint.position, transform.rotation);

        // Convert the angle of the player to the velocity of the bullet and shoot it forward
        Vector2 angle = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.up;
        shot.GetComponent<Rigidbody2D>().velocity = angle * shot.GetComponent<Laser>().speed;
    }
}
