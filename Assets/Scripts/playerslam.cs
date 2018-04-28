// Player Slam Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerslam : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen abt;				// A script variable to access variables from the player script
	public bool canslam = true;		// Checks if the player can slam
	public bool slamming = false;		// Checks if the player is slamming
	private float slamspeed = 19.5f;	// Slam speed
	public int slamcurrentframe = 0;	// The number of the frames that's passed for the slam animation
	public AudioClip slamSFX; //sound clip played when slamming
	private int slamtime = 42;			// The time it takes to finish the slam
	private Rigidbody2D rb;				// The rigidbody for the player
	private Animator anim;				// The animator for the player

	void Start () {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's X button to see if it's been pressed
		bool xboxp1_x = Input.GetButtonDown("XBOXP1_X");
		
		// A variable that is set to the player's rigidbody's velocity
		Vector3 velocitystop = rb.velocity;

		// If c/X button is pressed and the player is facing right and the player isn't slamming and the "Cyber Slam" ability is equipped, the player will slam to the right
		if(plyr.locked == false && (Input.GetKeyDown("c") || xboxp1_x == true) && slamming == false && abt.eqpdcyberslam == true && canslam == true) { //&& this.transform.eulerAngles == plyr.rightvector
			canslam = false;
			slamming = true;
			GetComponent<AudioSource>().PlayOneShot(slamSFX, 0.5f); //the slam sound effect is played 
		}

		// If the player can't slam, the slam timer will start
		if(canslam == false) {
			slamcurrentframe++;
		}

		// If the player is slamming, the slam timer will start too
		if(canslam == false && slamming == true) {
			anim.SetBool("Slamming", true);
			anim.SetBool("Falling", true);
			//plyr.invincible = true;

			if(slamcurrentframe <= slamtime / 2) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * slamspeed * Time.deltaTime);
				rb.constraints = RigidbodyConstraints2D.FreezePositionY;
			}
		}

		// When the counter for the slam is greater than one third of the attack time, the slam animation will finish
		if(slamcurrentframe > slamtime / 2) {
			anim.SetBool("Slamming", false);
			slamming = false;
			//plyr.invincible = true;
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

			if(plyr.grounded == true){
				anim.SetFloat("Horizontal", 0);
				anim.SetBool("Falling", false);
			} else {
				anim.SetBool("Falling", true);
			}
		}

		// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
		if(slamcurrentframe > slamtime) {
			slamcurrentframe = 0;
			canslam = true;
			//plyr.invincible = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {

		// Checks if player's hitbox is inside an enemy while it's slamming, the enemy will take damage
		if(col.gameObject.tag == "Enm" && slamming == true && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 2;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}

		// If colliding into a wall while slamming, the slam will stop
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && slamming == true) {
			anim.SetBool("Slamming", false);
			slamming = false;
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
			//transform.Translate (new Vector3 (0.0f, 0.0f, 0.0f) * Time.deltaTime);

			if(slamcurrentframe <= slamtime / 2) {
				slamcurrentframe = (slamtime / 2) + 1;
			}
		}

		if(col.gameObject.tag == "Lwl" && this.transform.eulerAngles == plyr.leftvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}

		if(col.gameObject.tag == "Rwl" && this.transform.eulerAngles == plyr.rightvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {

		// Checks if player's hitbox is inside an enemy while it's slamming, the enemy will take damage
		if(col.gameObject.tag == "Enm" && slamming == true && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 2;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}

		// If colliding into a wall while slamming, the slam will stop
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && slamming == true) {
			anim.SetBool("Slamming", false);
			slamming = false;
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
			//transform.Translate (new Vector3 (0.0f, 0.0f, 0.0f) * Time.deltaTime);

			if(slamcurrentframe <= slamtime / 2) {
				slamcurrentframe = (slamtime / 2) + 1;
			}
		}

		if(col.gameObject.tag == "Lwl" && this.transform.eulerAngles == plyr.leftvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}

		if(col.gameObject.tag == "Rwl" && this.transform.eulerAngles == plyr.rightvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}
	}

	void OnCollisionStay2D (Collision2D col) {

		if(col.gameObject.tag == "Lwl" && this.transform.eulerAngles == plyr.leftvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}

		if(col.gameObject.tag == "Rwl" && this.transform.eulerAngles == plyr.rightvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}
	}

	void OnTriggerStay2D (Collider2D col) {

		if(col.gameObject.tag == "Lwl" && this.transform.eulerAngles == plyr.leftvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}

		if(col.gameObject.tag == "Rwl" && this.transform.eulerAngles == plyr.rightvector) {
			canslam = false;
			slamcurrentframe = (slamtime / 2) + 1;
		}
	}
}
