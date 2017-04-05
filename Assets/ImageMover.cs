using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageMover : MonoBehaviour {

    public GameObject gameobject;
    int x = 0;
    int limit = 9;

	void Update ()
    {
        x = Coins.score;
        if(x > limit)
        {
            transform.position = new Vector3(transform.position.x-8, transform.position.y);
            limit *= 10;
            limit += 9;
        }
    }
}
