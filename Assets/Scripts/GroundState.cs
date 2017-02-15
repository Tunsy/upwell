using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : MonoBehaviour
{

    private PlayerController player;
    private float width;
    private float height;
    private float length;
    private bool enableJumpField;
    public LayerMask platforms;

    public void Start()
    {
        player = GetComponent<PlayerController>();
        width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
        length = 0.05f;
        //platforms = LayerMask.NameToLayer("Wall");
    }

    // Returns whether or not player is touching wall.
    public bool IsWall()
    {
        bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length, platforms);
        bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length, platforms);

        if (left || right)
            return true;
        else
            return false;
    }

    // Returns whether or not player is touching ground.
    public bool IsGround()
    {
        bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length, platforms);
        bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length, platforms);
        bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length, platforms);
        if (bottom1 || bottom2 || bottom3)
            return true;
        else
            return false;
    }

    // Returns whether or not player is touching wall or ground.
    public bool IsTouching()
    {
        if (IsGround() || IsWall())
            return true;
        else
            return false;
    }

    // Returns direction of wall.
    public int WallDirection()
    {
        bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
        bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);

        if (left)
            return -1;
        else if (right)
            return 1;
        else
            return 0;
    }


    public void EnterJumpField()
    {
        enableJumpField = true;
    }

    public void ExitJumpField()
    {
        enableJumpField = false;
    }

    public bool CanWallFieldJump()
    {
        if (enableJumpField)
        {
            enableJumpField = false;
            return true;
        }

        return false;
    }

}
