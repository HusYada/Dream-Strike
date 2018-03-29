// Player Block Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerblock : MonoBehaviour {

	
	public player plyr;						// A script variable to access variables from the player script
	public playerjump jump;
	public playermovement move;
	public abtscreen abt;					// A script variable to access variables from the abtscreen script
	public GameObject blockblock;			// The block to use, edit it in the Inspector
	public bool mayoshooting = false;		// Checks if the player is shooting or not
	public bool mayoair = false;			// Checks if the player used a mayo block in the air
	public bool makeblock = false;
	private bool cockblock = false;
	private float mayodirection = 2.4f;
	public int mayoshootcurrentframe = 0;	// The number of the frames that's passed for the shoot animation
	public int mayoshoottime = 33;		// The time it takes to finish the mayo
	private int mayocooldowno = 200;	// The time it takes to get another mayo
	private Rigidbody2D rb;					// The
	private Animator anim;					// The animator for the player

	void Start () {
		// Getting the components
		rb = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	
	/*void Update () {

		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");
		
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_b = Input.GetButton("XBOXP1_B");
		
		// The time it will take for the block to be destroyed after being shot out
		float destroyblock = 2.4f;

		if(this.transform.eulerAngles == plyr.rightvector) {
			mayodirection = 2.4f;
		}

		if(this.transform.eulerAngles == plyr.leftvector) {
			mayodirection = -2.4f;
		}

		// If up/control stick is held up and x/B button is pressed and the player is facing either left or right and the player isn't already shooting and the "Mayonasie" ability is equipped, then the player will create a block on either side
		if(plyr.locked == false && (Input.GetKey("up") || vmove >= 1.0f) && (Input.GetKey("x") || xboxp1_b == true) && (this.transform.eulerAngles == plyr.rightvector || this.transform.eulerAngles == plyr.leftvector) && mayoshooting == false && abt.eqpdmayonaise == true) {

			// A transform that will instantiate an exsisting block to it's current position
 			//Transform block = (Transform)Instantiate(blockblock, transform.position, transform.rotation);
 			if(plyr.grounded == true) {
 				mayoshooting = true;
 				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
 				GameObject block = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x + mayodirection, transform.position.y, transform.position.z), transform.rotation);
 				Destroy(block.gameObject, destroyblock);
 			} else if (plyr.grounded == false && mayoair == false) {
 				mayoshooting = true;
 				mayoair = true;
 				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
 				rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 				GameObject block2 = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x, transform.position.y + -3.0f, transform.position.z), transform.rotation);
 				Destroy(block2.gameObject, destroyblock);
 			}
		}

		// If the player is shooting, the shoot timer will start too
		if(mayoshooting == true){
			mayoshootcurrentframe++;
			anim.SetBool("Mayo", true);
			anim.SetBool("Falling", true);
		}

		// When the counter for the shoot is greater than one half of the shoot time, the shoot animation will finish
		if(mayoshootcurrentframe > mayoshoottime / 15) {
			anim.SetBool("Mayo", false);
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

			if(plyr.grounded == true){
				anim.SetFloat("Horizontal", 0);
				anim.SetBool("Falling", false);
			} else {
				anim.SetBool("Falling", true);
			}
		}

		// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
		if(mayoshootcurrentframe > mayoshoottime) {
			mayoshootcurrentframe = 0;
			mayoshooting = false;
		}
	}*/

	void Update () {

		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");
		
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_a = Input.GetButton("XBOXP1_A");
		
		// The time it will take for the block to be destroyed after being shot out
		float destroyblock = 2.4f;

		if(this.transform.eulerAngles == plyr.rightvector) {
			mayodirection = 2.4f;
		}

		if(this.transform.eulerAngles == plyr.leftvector) {
			mayodirection = -2.4f;
		}

		// If up/control stick is held up and x/B button is pressed and the player is facing either left or right and the player isn't already shooting and the "Mayonasie" ability is equipped, then the player will create a block on either side
		if(plyr.locked == false && (Input.GetKey("down") || vmove <= -1.0f) && (Input.GetKey("z") || xboxp1_a == true) && (this.transform.eulerAngles == plyr.rightvector || this.transform.eulerAngles == plyr.leftvector) && mayoshooting == false && abt.eqpdmayonaise == true) {
			mayoshooting = true;
			jump.jumping = false;
			if(plyr.grounded == true) {
 				//mayoair = false;
 				anim.SetBool("Jumping", false);
 				anim.SetBool("Double Jumping", false);
				anim.SetBool("Falling", false);
 			} else if (plyr.grounded == false) {
 				mayoair = true;
 				anim.SetBool("Falling", true);
 			}
		}

		// If the player is shooting mayo, the shoot timer will start too go down and the anim will play
		if(mayoshooting == true){
			mayoshootcurrentframe++;
			//rb.constraints = RigidbodyConstraints2D.FreezePositionX;
 			/*rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 			move.canwalkleft = false;
			move.canwalkright = false;*/
			anim.SetBool("Mayo", true);
			//anim.SetBool("Attacking", false);

			//anim.SetBool("Falling", true);
		}

		if(mayoshooting == true && mayoshootcurrentframe < mayoshoottime) {
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 			move.canwalkleft = false;
			move.canwalkright = false;
		}

		if(mayoshooting == true && mayoshootcurrentframe == mayoshoottime) {
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
			move.canwalkleft = true;
			move.canwalkright = true;
		}

		// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
		if(mayoshootcurrentframe > mayoshoottime) {
			//mayoshootcurrentframe = 0;
			//mayoshooting = false;
			if(cockblock == false) {
				makeblock = true;
			}
			//rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
			//rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
			//move.canwalkleft = true;
			//move.canwalkright = true;
			anim.SetBool("Mayo", false);
			if(plyr.grounded == true){
				anim.SetFloat("Horizontal", 0);
				anim.SetBool("Falling", false);
			} else {
				anim.SetBool("Falling", true);
			}
		}

		if(makeblock == true && mayoshooting == true && cockblock == false) {
			//mayoshooting = false;
			//makeblock = false;
			cockblock = true;
			if(mayoair == true) {
				GameObject block2 = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x, transform.position.y + -3.0f, transform.position.z), transform.rotation);
 				Destroy(block2.gameObject, destroyblock);
			} else if(mayoair == false) {
				GameObject block = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x + mayodirection, transform.position.y, transform.position.z), transform.rotation);
 				Destroy(block.gameObject, destroyblock);
			}
		}

		if(mayoshootcurrentframe > mayocooldowno) {
			mayoshootcurrentframe = 0;
			mayoshooting = false;
			makeblock = false;
			cockblock = false;
		}
	}
}
