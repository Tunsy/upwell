using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesMover : MonoBehaviour {


    public GameObject gameobject;
    int x = 0;
    int limit = 9;

    void Update()
    {
        Lives lives = gameobject.GetComponent<Lives>();
        x = lives.score;
        if (x > limit)
        {
            transform.position = new Vector3(transform.position.x - 8, transform.position.y);
            limit *= 10;
            limit += 9;
        }
    }
}
