﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCtestfriendly : MonoBehaviour
{
    public GameObject laser;
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
        if (timer > shootInterval)
        {
            Generate();
            timer = 0;
        }
    }

    void Generate()
    {
            GameObject shot = (GameObject)Instantiate(laser, spawnPoint.position, transform.rotation);
            ShootSound();
            // Convert the angle of the player to the velocity of the bullet and shoot it forward
            Vector2 angle = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.up;
            Debug.Log("Angle" + angle + "speed" + shot.GetComponent<Projectile>().speed);
            shot.GetComponent<Rigidbody2D>().velocity = angle * shot.GetComponent<Projectile>().speed;
    }

    void ShootSound()
    {
        if ((player.position - transform.position).magnitude <= 30)
        {
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            }

        }
    }
}