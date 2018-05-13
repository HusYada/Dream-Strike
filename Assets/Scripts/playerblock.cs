// Player Block Script for Dream Strike by Huseyin Geyik

// Reference for Rigidbody Constraints (Helped me understand how to use rigidbody constraints better) - https://answers.unity.com/questions/238887/can-you-unfreeze-a-rigidbodyconstraint-position-as.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerblock : MonoBehaviour {

	
	public player plyr;						// A script variable to access variables from the player script
	public playerjump jump;					// A script variable to access variables from the playerjump script
	public playermovement move;				// A script variable to access variables from the playermovement script
	public abtscreen abt;					// A script variable to access variables from the abtscreen script
	public GameObject blockblock;			// The block to use, edit it in the Inspector
	public bool mayoshooting = false;		// Checks if the player is shooting mayo or not
	public bool mayoair = false;			// Checks if the player used a mayo block in the air
	public bool makeblock = false;			// Checks if the player can create a mayo block
	private bool blockcheck = false;		// Checks if the player made a mayo block
	private float mayodirection = 2.4f;		// Direction of the mayo block
	public int mayoshootcurrentframe = 0;	// The number of the frames that's passed for the mayo animation
	public int mayoshoottime = 33;			// The time it takes to finish the mayo
	public AudioClip mayoSFX; 				// Sound clip that plays when the player creates a mayo block
	public AudioClip mayoprepSFX; 			// Sound clip that plays when the player prepare a mayo block
	private int mayocooldowno = 200;		// The time it takes to get another mayo
	private Rigidbody2D rb;					// The rigidbody for the player
	private Animator anim;					// The animator for the player

	void Start () {
		// Getting the components
		rb = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	void Update () {

		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");
		
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_a = Input.GetButton("XBOXP1_A");
		
		// The time it will take for the block to be destroyed after being shot out
		float destroyblock = 2.4f;

		// The direction of the mayo block depends on the direction the player is facing
		if(this.transform.eulerAngles == plyr.rightvector) {
			mayodirection = 2.4f;
		}

		// The direction of the mayo block depends on the direction the player is facing
		if(this.transform.eulerAngles == plyr.leftvector) {
			mayodirection = -2.4f;
		}

		// If up/control stick is held up and x/B button is pressed and the player is facing either left or right and the player isn't already shooting and the "Mayonasie" ability is equipped, then the player will create a block on either side
		if(plyr.locked == false && (Input.GetKey("down") || vmove < -0.1f) && (Input.GetKey("z") || xboxp1_a == true) && mayoshooting == false && abt.eqpdmayonaise == true) {
		//if(plyr.locked == false && (Input.GetKey("down") || vmove <= -1.0f) && (Input.GetKey("z") || xboxp1_a == true) && (this.transform.eulerAngles == plyr.rightvector || this.transform.eulerAngles == plyr.leftvector) && mayoshooting == false && abt.eqpdmayonaise == true) {
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
			if(plyr.grounded == true) {
 				//mayoair = false;
 				anim.SetBool("Jumping", false);
 				anim.SetBool("Double Jumping", false);
				anim.SetBool("Falling", false);
 			} else if (plyr.grounded == false) {
 				mayoair = true;
 				anim.SetBool("Falling", true);
 			}
 			mayoshooting = true;
			jump.jumping = false;
			GetComponent<AudioSource>().PlayOneShot(mayoprepSFX, 0.5f); //the mayo prep sound effect is played 
		}

		// If the player is shooting mayo, the shoot timer will start too go down and the anim will play
		if(mayoshooting == true){
			mayoshootcurrentframe++;
			//rb.constraints = RigidbodyConstraints2D.FreezePositionX;
 			/*rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 			move.canwalkleft = false;
			move.canwalkright = false;*/
			//rb.constraints = RigidbodyConstraints2D.FreezePositionY;
			anim.SetBool("Mayo", true);

			//anim.SetBool("Attacking", false);

			//anim.SetBool("Falling", true);
		}

		// Freeze player position depending on the mayoshootcurrentframe
		if(mayoshooting == true && mayoshootcurrentframe < mayoshoottime) {
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 			move.canwalkleft = false;
			move.canwalkright = false;
		}

		if(mayoshooting == true && mayoshootcurrentframe == mayoshoottime) {
			rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
			move.canwalkleft = true;
			move.canwalkright = true;
		}

		// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
		if(mayoshootcurrentframe > mayoshoottime) {
			//mayoshootcurrentframe = 0;
			//mayoshooting = false;
			if(blockcheck == false) {
				makeblock = true;
			}
			//rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
			//rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
			//move.canwalkleft = true;
			//move.canwalkright = true;
			anim.SetBool("Mayo", false);
			if(plyr.grounded == true){
				if(abt.eqpdrollerskates == false) {
					anim.SetFloat("Horizontal", 0);
				}
				anim.SetBool("Falling", false);
			} else {
				anim.SetBool("Falling", true);
			}
		}

		// If the player is making a block, a mayo block will spawn
		if(makeblock == true && mayoshooting == true && blockcheck == false) {
			GetComponent<AudioSource>().PlayOneShot(mayoSFX, 0.5f); //the mayo sound effect is played 
			//mayoshooting = false;
			//makeblock = false;
			blockcheck = true;
			if(mayoair == true) {
				GameObject block2 = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x, transform.position.y + -3.0f, transform.position.z), transform.rotation);
 				Destroy(block2.gameObject, destroyblock);
			} else if(mayoair == false) {
				GameObject block = (GameObject)Instantiate(blockblock, new Vector3(transform.position.x + mayodirection, transform.position.y, transform.position.z), transform.rotation);
 				Destroy(block.gameObject, destroyblock);
			}
		}

		// Reset after cooldown
		if(mayoshootcurrentframe > mayocooldowno) {
			mayoshootcurrentframe = 0;
			mayoshooting = false;
			makeblock = false;
			blockcheck = false;
		}
	}
}
