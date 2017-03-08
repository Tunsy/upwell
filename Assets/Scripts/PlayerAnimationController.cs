using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    public GroundState gs;
    public PlayerController pc;
    public bool isWall;
    public bool isJumping;
    public bool isMoving;
    public bool isKnockedback;

	// Use this for initialization
	void Start () {
        gs = GetComponent<GroundState>();
        pc = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        isWall = gs.IsWall();

	}
}
