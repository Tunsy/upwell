using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidPlatform : Spawnable, PlatformInterface {

	public void Initialize()
    {
        int leftOrRight = Random.Range(0, 2);   //Will choose either 0 or 1
        leftOrRight = leftOrRight == 0 ? -1 : 1;    //Convert 0 to -1. Remains the same if 1
        this.transform.Translate(new Vector3(leftOrRight * 2.5f, 0, 0));    //Move the platform left or right accordingly
    }
}
