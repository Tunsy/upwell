using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public class GroundState
    {
        private GameObject player;
        private float width;
        private float height;
        private float length;

        // GroundState constructor.  Sets offsets for raycasting.
        public GroundState(GameObject playerRef)
        {
            player = playerRef;
            width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
            length = 0.05f;
        }

        // Returns whether or not player is touching wall.
        public bool isWall()
        {
            bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
            bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);

            if (left || right)
                return true;
            else
                return false;
        }

        // Returns whether or not player is touching ground.
        public bool isGround()
        {
            bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
            bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            if (bottom1 || bottom2 || bottom3)
                return true;
            else
                return false;
        }

        // Returns whether or not player is touching wall or ground.
        public bool isTouching()
        {
            if (isGround() || isWall())
                return true;
            else
                return false;
        }

        // Returns direction of wall.
        public int wallDirection()
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
    }

    
    public float speed = 14f;
    public float accel = 6f;
    public float airAccel = 3f;
    public float jump = 14f;
    public float shortJump = 5;

    private GroundState groundState;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    void Start()
    {
        //Create an object to check if player is grounded or touching wall
        groundState = new GroundState(transform.gameObject);
        rb = GetComponent<Rigidbody2D>();
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

        //Debug.Log(Input.GetAxis("Jump"));

        if (Input.GetKey(KeyCode.Space))
            input.y = 1;
        else
            input.y = 0;

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
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x) * (groundState.isGround() ? accel : airAccel), 0)); // Accelerate the player.
        rb.velocity = new Vector2((input.x == 0 && groundState.isGround()) ? 0 : rb.velocity.x, (input.y == 1 && groundState.isTouching()) ? jump : rb.velocity.y); //Stop player if input.x is 0 (and grounded), jump if input.y is 1

        // Wall jumping
        if (groundState.isWall() && !groundState.isGround() && input.y == 1) 
            rb.velocity = new Vector2(-1 * groundState.wallDirection() * speed * 0.75f, rb.velocity.y); //Add force negative to wall direction (with speed reduction)

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
        GameObject Manager = GameObject.Find("GameManagerLoader").GetComponent<GameManagerLoader>().gameManager;
        Manager.GetComponent<GameManager>().killPlayer();
    }
}
