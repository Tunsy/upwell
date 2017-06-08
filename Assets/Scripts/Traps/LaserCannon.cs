using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    public GameObject laser;
    public float shootSpeed;
    private Transform spawnPoint;
    private GameObject shot;
    private Transform player;

    private float timer = 0;
    public float shootInterval;
    public float startOffset;


    public AudioClip shootSound;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        spawnPoint = transform.GetChild(0);
        timer -= startOffset;
    }

    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > shootInterval)
        {
            Generate();
            timer = 0;
        }
    }

    void Generate()
    {
        if (GameManager.instance.isAlive())
        {
            GameObject shot = (GameObject)Instantiate(laser, spawnPoint.position, transform.rotation);
            //Debug.Log("Shoot!");
            ShootSound();
            // Convert the angle of the player to the velocity of the bullet and shoot it forward
            Vector2 angle = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.up;
            //Debug.Log("Angle" + angle + "speed" + shot.GetComponent<Projectile>().speed);
            if(shootSpeed == 0)
            {
                shot.GetComponent<Rigidbody2D>().velocity = angle * shot.GetComponent<Projectile>().speed;
            }else
            {
                shot.GetComponent<Rigidbody2D>().velocity = angle * shootSpeed;
            }

        }
    }

    void ShootSound()
    {
        if ((player.position - transform.position).magnitude <= 40)
        {
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, .25f);
            }

        }
    }
}