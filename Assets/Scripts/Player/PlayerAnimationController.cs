using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private GroundState gs;
    private PlayerController pc;
    private Animator anim;
    private bool isWall;
    private bool isGround;
    private bool isMoving;
    private bool isKnockedback;

    // Use this for initialization
    void Start()
    {
        gs = GetComponent<GroundState>();
        pc = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWall = gs.IsWallClinging();
        isGround = gs.IsGround();
        isMoving = !(pc.rb.velocity.x == 0 && pc.rb.velocity.y == 0);
        isKnockedback = pc.isKnockedback;

        anim.SetBool("IsWall", isWall);
        anim.SetBool("IsGround", isGround);
        anim.SetBool("IsMoving", isMoving);
        anim.SetBool("IsKnockedback", isKnockedback);
    }

    public void JumpTrigger()
    {
        anim.SetTrigger("WallJump");
    }
}
