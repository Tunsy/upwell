using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableActivateDestroy : MonoBehaviour {
    public GameObject other;
    public int durability;
    private int count = 0;

    private void CollisionExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            if (count == durability)
            {
                Destroy(other);
            }
        }
    }
}
