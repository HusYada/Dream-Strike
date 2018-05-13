// Player Shoot Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public playermovement move;			// A script variable to access variables from the playermovement script
	public abtscreen gotornot;			// A script variable to access variables from the abtscreen script
	public Transform leftprojectile; 	// The projectile that will be shot left, edit it in the Inspector
	public Transform rightprojectile; 	// The projectile that will be shot right, edit it in the Inspector
	public bool shooting = false;		// Checks if the player is shooting or not
	public AudioClip shootSFX; 			// Sound clip that plays when the player shoots a pea
	public bool shootleft = false;		// Checks if the player is shooting left
	public bool shootright = false;		// Checks if the player is shooting right
	public bool shootpealeft = false;	// Checks if the player shot a pea left
	public bool shootpearight = false;	// Checks if the player shot a pea right
	public int shootcurrentframe = 0;	// The number of the frames that's passed for the shoot animation
	public int shoottime = 48;			// The time it takes to finish the shoot
	private Rigidbody2D rb;				// The rigidbody for the player
	private Animator anim;				// The animator for the player

	void Start () {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}
	
	void Update () {

		// If the "Pea Shoot" ability is equipped, then the player can shoot
		if(gotornot.eqpdpeashoot == true) {

			// A variable set to the Xbox 360/Xbox One controller's Y button to see if it's been pressed
			bool xboxp1_y = Input.GetButtonDown("XBOXP1_Y");

			// The time it will take for the projectile to be destroyed after being shot out
 			float destroyprojectile = 2.5f;

			// If v/Y button is pressed and the player is facing right and the player isn't already shooting, then the player will shoot a projectile to the right
			if(plyr.locked == false && xboxp1_y == true && this.transform.eulerAngles == plyr.rightvector && shooting == false
				|| plyr.locked == false && Input.GetKeyDown("v") && plyr.lookingright == true && shooting == false) {

				shooting = true;
				shootright = true;
				GetComponent<AudioSource>().PlayOneShot(shootSFX, 0.5f); //the shoot sound effect is played 

				// A transform that will instantiate an exsisting bullet to it's current position
 				//Transform rbullet = (Transform)Instantiate(rightprojectile, transform.position, transform.rotation);
 				//Transform rbullet = (Transform)Instantiate(rightprojectile, new Vector3(transform.position.x + 2.3f, transform.position.y, transform.position.z), transform.rotation);

 				// After a while, the projectile will be destroyed
 				//Destroy(rbullet.gameObject, destroyprojectile);

 			// If v/Y button is pressed and the player is facing left and the player isn't already shooting, then the player will shoot a projectile to the left
			} else if (plyr.locked == false && xboxp1_y == true && this.transform.eulerAngles == plyr.leftvector && shooting == false
				|| plyr.locked == false && Input.GetKeyDown("v") && plyr.lookingleft == true && shooting == false) {

				shooting = true;
				shootleft = true;
				GetComponent<AudioSource>().PlayOneShot(shootSFX, 0.5f); //the shoot sound effect is played 

				// A transform that will instantiate an exsisting bullet to it's current position
 				//Transform lbullet = (Transform)Instantiate(leftprojectile, transform.position, transform.rotation);
				//Transform lbullet = (Transform)Instantiate(leftprojectile, new Vector3(transform.position.x + -2.3f, transform.position.y, transform.position.z), transform.rotation);

 				// After a while, the projectile will be destroyed
 				//Destroy(lbullet.gameObject, destroyprojectile);
			}

			// If the player is shooting, the shoot timer will start too
			if(shooting == true){
				shootcurrentframe++;
				anim.SetBool("Shooting", true);
				move.canwalkleft = false;
				move.canwalkright = false;
 				rb.constraints = RigidbodyConstraints2D.FreezePositionY;
 				if(plyr.grounded == true) {
 					//anim.SetBool("Jumping", false);
 					//anim.SetBool("Double Jumping", false);
					//anim.SetBool("Falling", false);
				}
				//rb.velocity = new Vector2(0, 0);
			}

			// When the counter for the shoot is greater than one half of the shoot time, the shoot animation will finish
			if(shootcurrentframe > shoottime / 2) {

				move.canwalkleft = true;
				move.canwalkright = true;
				rb.constraints = ~RigidbodyConstraints2D.FreezePosition;

				anim.SetBool("Shooting", false);

				// Pea will move in the direction it was shot
				if(shootleft == true) {
					shootpealeft = true;
					shootleft = false;
				}

				// Pea will move in the direction it was shot
				if(shootright == true) {
					shootpearight = true;
					shootright = false;
				}

				/*if(plyr.grounded == true){
					//anim.SetFloat("Horizontal", 0);
					//anim.SetBool("Falling", false);
				} else {
					//anim.SetBool("Falling", true);
				}*/
			}

			// When the counter for the slam is greater than the slam time, the slam will finish and slamcurrentframe is reset
			if(shootcurrentframe > shoottime) {
				shootcurrentframe = 0;
				shooting = false;
			}

			// If pea was shot left, the pea will move left
			if(shootpealeft == true) {
				Transform lbullet = (Transform)Instantiate(leftprojectile, new Vector3(transform.position.x + -1.3f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
				Destroy(lbullet.gameObject, destroyprojectile);
				shootpealeft = false;
			}

			// If pea was shot right, the pea will move right
			if(shootpearight == true) {
				Transform rbullet = (Transform)Instantiate(rightprojectile, new Vector3(transform.position.x + 1.3f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
				Destroy(rbullet.gameObject, destroyprojectile);
				shootpearight = false;
			}
		}
	}

	// If the player collides with the ground, they can shoot another pea
	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "Gnd") {
			shootcurrentframe = 0;
			shooting = false;
			shootleft = false;
			shootright = false;
		}
	}
}
