using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour {

	public player plyr;
	public playerjump jump;
	public playermovement move;
	public playerslam slam;
	public playerblock block;
	private Rigidbody2D rb;
	private BoxCollider2D bx;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb   = plyr.GetComponent<Rigidbody2D>();
		bx   = plyr.GetComponent<BoxCollider2D>();
		anim = plyr.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
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

		if(col.gameObject.tag == "Cln" && plyr.falling == false && plyr.gravityflip == true) {
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

		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && plyr.falling == true) {
			plyr.grounded = false;
			slam.slamming = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			if(col.gameObject.tag == "Gnd") {
				rb.velocity = new Vector2(0, 0);
			}
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			if(col.gameObject.tag == "Gnd") {
				rb.velocity = new Vector2(0, 0);
			}
		}

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

		if(col.gameObject.tag == "Cln" && plyr.gravityflip == true) {
			plyr.grounded = true;
			block.mayoair = false;
			//falling = false;
			anim.SetBool("Falling", false);
		}

		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && plyr.falling == true) {
			plyr.grounded = false;
		}

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			if(col.gameObject.tag == "Gnd") {
				rb.velocity = new Vector2(0, 0);
			}
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			if(col.gameObject.tag == "Gnd") {
				rb.velocity = new Vector2(0, 0);
			}
		}

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

		if(col.gameObject.tag == "Cln" && plyr.gravityflip == true) {
			plyr.grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
		}

		if(col.gameObject.tag == "Zip") {
			bx.enabled = true;
		}
	}

	/*void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "PfmGnd") {
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
			transform.parent = col.transform;
        }
	}

	void OnTriggerStay2D(Collider2D col) {

		if(col.gameObject.tag == "PfmGnd") {
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
			transform.parent = col.transform;
        }
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "PfmGnd") {
			plyr.grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
        	transform.parent = null;
        }
	}*/
}
