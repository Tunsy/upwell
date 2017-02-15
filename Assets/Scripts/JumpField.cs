using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpField : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GroundState player = collision.GetComponent<GroundState>();
            player.EnterJumpField();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GroundState player = collision.GetComponent<GroundState>();
            player.ExitJumpField();
        }
    }
}
