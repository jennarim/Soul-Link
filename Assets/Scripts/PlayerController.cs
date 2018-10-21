using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Movement Variables
	public float maxSpeed;

	// Jumping Variables
	//bool grounded = false;
	//float groundCheckRadius = 0.2f;
	//public LayerMask groundLayer;
	//public Transform groundCheck;
	//public float jumpHeight;



	Rigidbody2D playerRB;	// ref to player's rigidbody component
	Animator playerAnim;	// ref to player's animator component

	bool facingRight;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();

		facingRight = true;
	}

	//void Update() {
	//	if (grounded && Input.GetAxis ("Jump") > 0) {
	//		grounded = false;
	//		playerAnim.SetBool("isGrounded", grounded);
	//		playerRB.AddForce(new Vector2(0, jumpHeight));
	//	}
	//}

	// Update is called once per frame
	void FixedUpdate () {
		// check if we are grounded. if no, then we are falling
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		//playerAnim.SetBool ("isGrounded", grounded);

		//playerAnim.SetFloat ("verticalSpeed", playerRB.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		playerAnim.SetFloat ("speed", Mathf.Abs(move));
		playerRB.velocity = new Vector2 (move * maxSpeed, playerRB.velocity.y);

		if (move > 0 && !facingRight) { 		// if player is moving right but is facing left
			flip ();
		} else if (move < 0 && facingRight) { 	// if player is moving left but is facing right
			flip();
		}
	}

	void flip() {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		facingRight = !facingRight;
		sr.flipX = !sr.flipX;
	}

}
