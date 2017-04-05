using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    private bool isPhasable = false;
    private float verticalFlySpeed = 5;
    private float powerUpDuration;
    public bool isKnockedback;
    public float wallClingTimer;
    public float wallClingTime;

    public AudioClip jumpSound;
    public AudioClip laserJump;
    public AudioClip hurtSound;
    public AudioSource audio;
    public Image powerupSlider;
    private GroundState groundState;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    private PlayerAnimationController pc;
    private int defaultLayer;

    void Start()
    {
        //Create an object to check if player is grounded or touching wall
        rb = GetComponent<Rigidbody2D>();
        groundState = GetComponent<GroundState>();
        audio = GetComponent<AudioSource>();
        pc = GetComponent<PlayerAnimationController>();
        holdingJumpCheck = false;
        isKnockedback = false;
        wallClingTimer = 0;
        defaultLayer = gameObject.layer;

    }

    private Vector2 input;

    void Update()
    {
        
        if (phasingUp())
        {
            Physics2D.IgnoreLayerCollision(defaultLayer, 8 );
            //gameObject.GetComponent<Collider2D>().isTrigger = true;
            powerupSlider.fillAmount -= Time.deltaTime / powerUpDuration;


        }
        else if(isPhasable)
        {
            Physics2D.IgnoreLayerCollision(defaultLayer, 8, false);
            //gameObject.GetComponent<Collider2D>().isTrigger = false;
            powerupSlider.fillAmount -= Time.deltaTime / powerUpDuration;
        }
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
                input.x = -Input.GetAxis("Horizontal");
                sprite.flipX = false;
                groundState.facing = -1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                input.x = -Input.GetAxis("Horizontal");
                sprite.flipX = true;
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

            // Jump
            Jump();
            
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
        if (isKnockedback == false && !phasingUp())
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

    public void Jump()
    {
        if (!isKnockedback)
        {
            float xVel = (input.x == 0 && groundState.IsGround()) ? 0 : rb.velocity.x;
            float yVel = (holdingJumpCheck && (groundState.IsGround() || groundState.IsJumpField())) ? jump : rb.velocity.y;

            // Wall jumping
            if (groundState.IsWallClinging() && holdingJumpCheck)
            {
                if (jumpSound != null)
                {
                    audio.PlayOneShot(jumpSound);
                }
                xVel = -1 * groundState.WallDirection() * speed * .8f; ; //Add force negative to wall direction (with speed reduction)
                yVel = jump;
            }

            rb.velocity = new Vector2(xVel, yVel);

            if (groundState.IsTouching() && jumpSound != null)
            {
                audio.PlayOneShot(jumpSound);
            }
            else if (groundState.WallFieldJump())
            {
                audio.PlayOneShot(laserJump);
            }
            pc.JumpTrigger();
        }
    }

    
    void FixedUpdate()
    {
        if (isFlying)
        {
            rb.velocity = new Vector2(input.x, verticalFlySpeed);
        }

        // Player physics
        if (!isKnockedback)
        {
            float xVel;

            if (groundState.IsWallClinging())
            {
                wallClingTimer += Time.deltaTime;

                if (wallClingTimer >= wallClingTime)
                    xVel = ((input.x * speed) - rb.velocity.x) * (groundState.IsGround() ? accel : airAccel);
                else
                    xVel = 0;
            }
            else
            {
                xVel = ((input.x * speed) - rb.velocity.x) * (groundState.IsGround() ? accel : airAccel);
                wallClingTimer = 0;
            }

            rb.AddForce(new Vector2(xVel, 0)); // Accelerate the player.

            // Variable jump height
            if (input.y == 0)
            {
                if (rb.velocity.y > shortJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, shortJump);
                }
            }
        }
    }

    //private void OnDestroy()
    //{
    //    //GameObject Manager = GameObject.Find("GameManagerLoader").GetComponent<GameManagerLoader>().gameManager;
    //    //Manager.GetComponent<GameManager>().killPlayer();
    //    GameManager.instance.killPlayer();
    //}

    void removeFlyPower()
    {

        Physics2D.IgnoreLayerCollision(defaultLayer, 10, false);
        Physics2D.IgnoreLayerCollision(defaultLayer, 11, false);
        Physics2D.IgnoreLayerCollision(defaultLayer, 8, false);
        isPhasable = false;
        isFlying = false;
        powerupSlider.fillAmount = 0f;
    }
    public void giveFlyPower(float duration)
    {
        
        isPhasable = true;
        Physics2D.IgnoreLayerCollision(defaultLayer, 10);
        Physics2D.IgnoreLayerCollision(defaultLayer, 11);
        powerupSlider.fillAmount =1f;
        powerUpDuration = duration;
        isFlying = true;
        
        Invoke("removeFlyPower", duration);
    }

    bool phasingUp()
    {
        return isPhasable && !groundState.IsTouching() ;
    }

    void counttest()
    {
        Debug.Log(1);
    }

    private GameObject currentCol = null;
   /* private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.layer.ToString());
        if (phasingUp() && collision.gameObject.layer.ToString() != "9")
        {
            Debug.Log('2');
            gameObject.GetComponent<Collider2D>().enabled = false;
            //Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

        }

        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            //Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
        }
    } */


   
}
