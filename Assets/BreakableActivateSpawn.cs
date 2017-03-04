using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableActivateSpawn : MonoBehaviour {
    public GameObject other;
    public float xPos;
    public float yPos;
    public float zPos;
    public float xScale = 1;
    public float yScale = 1;
    public float zScale = 1;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject spawn = (GameObject)Instantiate(other, new Vector3(xPos, yPos, zPos), transform.rotation);
            spawn.transform.localScale = new Vector3(xScale, yScale, zScale);
        }
    }
}
