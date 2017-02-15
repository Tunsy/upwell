using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherGS : MonoBehaviour
{
    private Crusher player;
    private float width;
    private float height;
    private float length;
    private bool isAPlayer = false;

    public void Start()
    {
        player = GetComponent<Crusher>();
        width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = player.GetComponent<Collider2D>().bounds.extents.y + 0.1f;
        length = 0f;
    }

    public bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
        if (hit.collider != null && hit.collider.gameObject.tag != "Platform")
            isAPlayer = true;

        bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
        bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
        bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
        if ((bottom1 || bottom2 || bottom3) && !isAPlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTouching()
    {
        if (IsGround())
            return true;
        else
            return false;
    }
}
