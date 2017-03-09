using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableActivateSpawn : MonoBehaviour {
    public GameObject other;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            other.SetActive(true);
        }
    }
}
