using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 14f;
    public float accel = 6f;
    public float airAccel = 3f;
    public float jump = 14f;
    public float shortJump = 5;
    private bool holdingJumpCheck;

    private GroundState groundState;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    void Start()
    {
        //Create an object to check if player is grounded or touching wall
        rb = GetComponent<Rigidbody2D>();
        groundState = GetComponent<GroundState>();
        holdingJumpCheck = false;
    }

    private Vector2 input;

    void Update()
    {
        // Handle input
        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input.x = 1;
            sprite.flipX = false;
        }
        else
            input.x = 0;

        // HandleSprint()
        if (Input.GetKey(KeyCode.Space))
            input.y = 1;
        else
            input.y = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdingJumpCheck = true;
        }else
        {
            holdingJumpCheck = false;
        }

        // Reverse player if going different direction
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (input.x == 0) ? transform.localEulerAngles.y : (input.x + 1) * 90, transform.localEulerAngles.z);
    }

    // Sprint functionality
    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 40f;
            jump = 18f;
            airAccel = 6f;
            accel = 12f;
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            speed = 40f;
            jump = 18f;
            airAccel = 6f;
            accel = 12f;
        }
    }


    void FixedUpdate()
    {
        // Player physics
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x) * (groundState.IsGround() ? accel : airAccel), 0)); // Accelerate the player.
        rb.velocity = new Vector2((input.x == 0 && groundState.IsGround()) ? 0 : rb.velocity.x, (holdingJumpCheck && (groundState.IsTouching() || groundState.CanWallFieldJump())) ? jump : rb.velocity.y); //Stop player if input.x is 0 (and grounded), jump if input.y is 1

        // Wall jumping
        if (groundState.IsWall() && !groundState.IsGround() && holdingJumpCheck)
        {
            rb.velocity = new Vector2(-1 * groundState.WallDirection() * speed * 0.75f, rb.velocity.y); //Add force negative to wall direction (with speed reduction)
        }

        // Variable jump height
        if(input.y == 0)
        {
            if(rb.velocity.y > shortJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, shortJump);
            }
        }
    }




    private void OnDestroy()
    {
        //GameObject Manager = GameObject.Find("GameManagerLoader").GetComponent<GameManagerLoader>().gameManager;
        //Manager.GetComponent<GameManager>().killPlayer();
        GameManager.instance.killPlayer();
    }
}
