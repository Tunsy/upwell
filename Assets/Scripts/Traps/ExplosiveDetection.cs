using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDetection:MonoBehaviour {

    public float radius;
    public float despawnTime;

	// Use this for initialization
	void Start ()
    {
        GetComponent<CircleCollider2D>().radius *= radius;
        Invoke("selfDestruct", despawnTime);
    }


    void selfDestruct()
    {
        Destroy(gameObject);
    }

}
