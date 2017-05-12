﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {
    private float localX;
    public int distance = 1000;
    public int coins = 3;
    public GameObject coin;
	// Use this for initialization
	void Start () {
        localX = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" && (jumpedOn(collision)))
            Destroy(this.gameObject);
            
            
        
    }

    bool jumpedOn(Collision2D c)
    {
        return c.transform.position.y > transform.position.y && c.transform.position.x < localX + transform.position.x && c.transform.position.x > transform.position.x - localX;

    }

    private void OnDestroy()
    {
        for (int i = 0; i < coins; ++i)
        {


            GameObject c = GameObject.Instantiate(coin, transform.position, Quaternion.identity);
            float ang = Random.Range(0, Mathf.PI);
            
            c.GetComponent<Rigidbody2D>().AddForce(distance * new Vector2(Mathf.Cos(ang), Mathf.Sin(ang)));
        }
    }

}