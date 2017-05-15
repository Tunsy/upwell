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
    public int facing;
    private float skinWidth;
    public LayerMask walls;
    public LayerMask ground;

    public void Start()
    {
        player = GetComponent<PlayerController>();
        width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
        length = 0.03f;
        skinWidth = 0.25f;
    }

    // Returns whether or not player is touching wall.
    public bool IsWall()
    {
        //TODO: IMPLEMENT A BETTER SOLUTION
        bool leftMid = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length, walls);
        bool leftTop = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y + height - skinWidth), -Vector2.right, length, walls);
        bool leftBottom = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y - height + skinWidth), -Vector2.right, length, walls);

        bool rightMid = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length, walls);
        bool rightTop = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y + height - skinWidth), Vector2.right, length, walls);
        bool rightBottom = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y - height + skinWidth), Vector2.right, length, walls);

        if (leftMid || leftTop || leftBottom || rightMid || rightTop || rightBottom)
            return true;
        else
            return false;
    }

    public bool IsWallClinging()
    {
        return (IsWall() && !IsGround()); 
    }

    // Returns whether or not player is touching ground.
    public bool IsGround()
    {
        bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length, ground);
        bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length, ground);
        bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length, ground);
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
        bool leftMid = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length, walls);
        bool leftTop = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y + height), -Vector2.right, length, walls);
        bool leftBottom = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y - height), -Vector2.right, length, walls);

        bool rightMid = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length, walls);
        bool rightTop = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y + height), Vector2.right, length, walls);
        bool rightBottom = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y - height), Vector2.right, length, walls);

        if (leftMid || leftTop || leftBottom)
            return -1;
        else if (rightMid || rightTop || rightBottom)
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

    public bool IsJumpField()
    {
        return enableJumpField;
    }

    public bool WallFieldJump()
    {
        if (enableJumpField)
        {
            enableJumpField = false;
            return true;
        }

        return false;
    }

}
