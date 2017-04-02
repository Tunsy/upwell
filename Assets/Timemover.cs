using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemover : MonoBehaviour {

    public GameObject gameobject;
    int x = 0;
    int limit = 9;

    void Update()
    {
        TimeScript timescript = gameobject.GetComponent<TimeScript>();
        x = timescript.score;
        if (x > limit)
        {
            this.transform.position = new Vector3(transform.position.x - 8, transform.position.y);
            limit *= 10;
            limit += 9;
        }
    }
}
