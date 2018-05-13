// Ground Check Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour {

	public player plyr;				// A script variable to access variables from the player script
	public playerjump jump;			// A script variable to access variables from the playerjump script
	public playermovement move;		// A script variable to access variables from the playermovement script
	public playerslam slam;			// A script variable to access variables from the playerslam script
	public playerblock block;		// A script variable to access variables from the playerblock script
	private Rigidbody2D rb;			// The rigidbody for the player
	private BoxCollider2D bx;		// The box collider for the player
	private Animator anim;			// The animator for the player

	void Start () {

		// Getting components
		rb   = plyr.GetComponent<Rigidbody2D>();
		bx   = plyr.GetComponent<BoxCollider2D>();
		anim = plyr.GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D col) {
		
	// Checks if player is on the ground, if so then the player is grounded, can jump again, cannot double jump and animations are changed
		if(col.gameObject.tag == "Gnd" && plyr.falling == false) {
			plyr.grounded = true;
			jump.candoublejump = false;
			jump.jumpcurrentframe = 0;
			jump.candjumpcurrentframe = 0;
			jump.djumpcurrentframe = 0;
			jump.djumped = false;
			block.mayoair = false;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", false);
			anim.SetBool("Hurt", false);
		}

		/*if(col.gameObject.tag == "Cln" && plyr.falling == false && plyr.gravityflip == true) {
			plyr.grounded = true;
			jump.candoublejump = false;
			jump.jumpcurrentframe = 0;
			jump.candjumpcurrentframe = 0;
			jump.djumpcurrentframe = 0;
			jump.djumped = false;
			block.mayoair = false;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", false);
			anim.SetBool("Hurt", false);
		}*/

		// If the player collides with a wall while falling, then they are not grounded, slamming or rotating
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && plyr.falling == true) {
			plyr.grounded = false;
			slam.slamming = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		// If the player collides with a wall on there left, then they cannot move in that direction
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			if(col.gameObject.tag == "Gnd" && plyr.soaped == false) {
				rb.velocity = new Vector2(0, 0);
			}
		}

		// If the player collides with a wall on there right, then they cannot move in that direction
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			if(col.gameObject.tag == "Gnd" && plyr.soaped == false) {
				rb.velocity = new Vector2(0, 0);
			}
		}

		// If the player goes through a wall somehow, the box collider will be disabled so they can escape
		if(col.gameObject.tag == "Zip") {
			bx.enabled = false;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		// If the player is on the ground, then they are still grounded
		if(col.gameObject.tag == "Gnd" && plyr.gravityflip == false) {
			plyr.grounded = true;
			block.mayoair = false;
			//falling = false;
			anim.SetBool("Falling", false);
		}

		/*if(col.gameObject.tag == "Cln" && plyr.gravityflip == true) {
			plyr.grounded = true;
			block.mayoair = false;
			//falling = false;
			anim.SetBool("Falling", false);
		}*/

		// If the player collides with a wall while falling, then they are not grounded
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && plyr.falling == true) {
			plyr.grounded = false;
		}

		// If the player collides with a wall on there left, then they cannot move in that direction
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			if(col.gameObject.tag == "Gnd" && plyr.soaped == false) {
				rb.velocity = new Vector2(0, 0);
			}
		}

		// If the player collides with a wall on there right, then they cannot move in that direction
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			if(col.gameObject.tag == "Gnd" && plyr.soaped == false) {
				rb.velocity = new Vector2(0, 0);
			}
		}

		// If the player goes through a wall somehow, the box collider will be disabled so they can escape
		if(col.gameObject.tag == "Zip") {
			bx.enabled = false;
		}
	}

	void OnCollisionExit2D(Collision2D col) {

		// If the player is no longer colliding with the ground, then the player is not grounded
		if(col.gameObject.tag == "Gnd" && plyr.gravityflip == false) {
			plyr.grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
		}

		/*if(col.gameObject.tag == "Cln" && plyr.gravityflip == true) {
			plyr.grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
		}*/

		// If the player stops going through a wall, the box collider will be enabled again 
		if(col.gameObject.tag == "Zip") {
			bx.enabled = true;
		}
	}
}
