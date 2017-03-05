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
    private bool isInverted = false;
    private bool isFlying = false;
    private float verticalFlySpeed = 5;
    public bool isKnockedback;

    public AudioClip jumpSound;
    public AudioClip laserJump;
    public AudioClip hurtSound;
    public AudioSource audio;

    private GroundState groundState;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    void Start()
    {
        //Create an object to check if player is grounded or touching wall
        rb = GetComponent<Rigidbody2D>();
        groundState = GetComponent<GroundState>();
        audio = GetComponent<AudioSource>();
        holdingJumpCheck = false;
        isKnockedback = false;
    }

    private Vector2 input;

    void Update()
    {
        // Handle input
        if (!isInverted)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                input.x = Input.GetAxis("Horizontal");
                sprite.flipX = true;
                groundState.facing = -1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                input.x = Input.GetAxis("Horizontal");
                sprite.flipX = false;
                groundState.facing = 1;
            }
            else
                input.x = 0;
        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                input.x = -1 * Input.GetAxis("Horizontal");
                sprite.flipX = true;
                groundState.facing = -1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                input.x = -1 * Input.GetAxis("Horizontal");
                sprite.flipX = false;
                groundState.facing = 1;
            }
            else
                input.x = 0;
        }

        // HandleSprint()
        if (Input.GetKey(KeyCode.Space))
            input.y = 1;
        else
            input.y = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdingJumpCheck = true;
            rb.velocity = new Vector2((input.x == 0 && groundState.IsGround()) ? 0 : rb.velocity.x, (holdingJumpCheck && (groundState.IsTouching() || groundState.IsJumpField())) ? jump : rb.velocity.y); //Stop player if input.x is 0 (and grounded), jump if input.y is 1
        }
        else
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

    public void SetInvert(bool setting)
    {
        isInverted = setting;
    }

    public void Knockback(DealDamageToPlayer enemy)
    {
        if (isKnockedback == false)
        {
            if (hurtSound != null)
            {
                audio.PlayOneShot(hurtSound);
            }
            isKnockedback = true;
            int direction = -1 * groundState.WallDirection();
            direction = direction == 0f ? -1 * groundState.facing : direction;
            StartCoroutine(HandleKnockback(enemy.knockDuration, enemy.horizontalKnockPower, enemy.verticalKnockPower, direction));
        }
    }

    public IEnumerator HandleKnockback(float duration, float horizontalPower, float verticalPower, float direction)
    {
        float timer = 0;
        rb.velocity = new Vector2(direction * horizontalPower, verticalPower);
        yield return new WaitForSeconds(0.03f);

        while (isKnockedback)
        {
            timer += Time.deltaTime;

            if (rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(0, 0);
            }

            if ((timer > duration) && groundState.IsGround())
            {
                isKnockedback = false;
            }
            yield return null;
        }
    }

    
    void FixedUpdate()
    {
        if (isFlying)
        {
            rb.velocity = new Vector2(input.x, verticalFlySpeed);
        }
        // Player physics
        if (!isKnockedback )
        {
            rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x) * (groundState.IsGround() ? accel : airAccel), 0)); // Accelerate the player.
            //rb.velocity = new Vector2((input.x == 0 && groundState.IsGround()) ? 0 : rb.velocity.x, (holdingJumpCheck && (groundState.IsTouching() || groundState.IsJumpField())) ? jump : rb.velocity.y); //Stop player if input.x is 0 (and grounded), jump if input.y is 1

            if (holdingJumpCheck && (groundState.IsTouching() || groundState.IsJumpField()))
            {
                if (groundState.IsTouching() && jumpSound != null)
                {
                    audio.PlayOneShot(jumpSound);
                }
                else if (groundState.WallFieldJump())
                {
                    audio.PlayOneShot(laserJump);
                }
            }

            // Wall jumping
            if (groundState.IsWall() && !groundState.IsGround() && holdingJumpCheck)
            {
                if (jumpSound != null)
                {
                    audio.PlayOneShot(jumpSound);
                }
                rb.velocity = new Vector2(-1 * groundState.WallDirection() * speed * 0.75f, rb.velocity.y); //Add force negative to wall direction (with speed reduction)
            }

            // Variable jump height
            //if (input.y == 0)
            //{
            //    if (rb.velocity.y > shortJump)
            //    {
            //        rb.velocity = new Vector2(rb.velocity.x, shortJump);
            //    }
            //}
        }
    }

    private void OnDestroy()
    {
        //GameObject Manager = GameObject.Find("GameManagerLoader").GetComponent<GameManagerLoader>().gameManager;
        //Manager.GetComponent<GameManager>().killPlayer();
        GameManager.instance.killPlayer();
    }

    void removeFlyPower()
    {
       
        isFlying = false;
    }
    public void giveFlyPower(float duration)
    {
        
        isFlying = true;
      
        Invoke("removeFlyPower", duration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer.ToString());
        if(isFlying && collision.gameObject.layer.ToString() != "9")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
