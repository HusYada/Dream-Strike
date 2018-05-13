// Player Movement Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

	public player plyr;										// A script variable to access variables from the player script
	public abtscreen abt;									// A script variable to access variables from the abtscreen script
	public playerslam slm;									// A script variable to access variables from the playerslam script
	public bool canwalkleft = true;							// Checks if the player can walk left
	public bool canwalkright = true;						// Checks if the player can walk right
	private bool start_move_cooldownleft = false;			// Checks if the player's walk left is cooling down
	private bool start_move_cooldownright = false;			// Checks if the player's walk right is cooling down
	private int move_cooldowntime = 2; 						// The cooldown on the player's invincibility when hurt
    private int moveleft_cooldowncounter = 0; 				// The counter for the walk left cooldown
    private int moveright_cooldowncounter = 0;				// The counter for the walk right cooldown
	private Rigidbody2D rb;									// The rigidbody for the player
	private Animator anim;									// The animator for the player

	void Start () {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	void Update () {

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");
		//float posx = 0.0f;

		//Vector3 momvement = new Vector3(posx, 2, 0);
		//rb.MovePosition(transform.position + posx);

		// If left is pressed/control stick is pushed left, the player will move left
		if ((Input.GetKey("left") || hmove < -0.1f) || abt.eqpdrollerskates == true && this.transform.eulerAngles == plyr.leftvector) {

			//rb.AddForce(Vector2.left * speed);
			//rb.MovePosition(transform.position + transform.right * -speed * Time.deltaTime);

			// If the "Walk Left" ability is equipped, then the player can perform the action
			if(plyr.locked == false && (abt.eqpdwalkleft == true || abt.eqpdrollerskates == true) && canwalkleft == true && ((plyr.invincible_cooldowncounter > plyr.invincible_cooldowntime / 4 && plyr.invincible == true) || plyr.invincible == false) && slm.slamming == false) {
				
				// If the player is soaped, the movement will be more slippery using rigidbody physics
				if(plyr.soaped == false || plyr.soaped == true && abt.eqpdgoodgrip == true) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				}

				// If the player is not soaped, the movement will be normal
				if(plyr.soaped == true && abt.eqpdgoodgrip == false) {
					rb.AddForce(Vector2.left * plyr.speed);
				}
				//rb.velocity = new Vector2(-6, rb.velocity.y);
				plyr.idle = false;

				// If the player is on the ground, the moving left animation will play
				if (plyr.grounded == true) {
					anim.SetFloat("Horizontal", -1);
				}

				/*if(Input.GetKey("z") && plyr.grounded == true && plyr.soaped == false) {
					rb.velocity = new Vector2(0,0);
				}*/
			}

			// Using the left vector to rotate the player to the left direction
			/*if(plyr.locked == false && plyr.gravityflip == false) {
				transform.eulerAngles = plyr.leftvector;
				plyr.lookingleft = true;
				plyr.lookingright = false;
			}

			if(plyr.locked == false && plyr.gravityflip == true) {
				transform.eulerAngles = plyr.grightvector;
			}*/

		// Or if right is pressed/control stick is pushed right, the player will move right
		} else if ((Input.GetKey("right") || hmove > 0.1f) || abt.eqpdrollerskates == true && this.transform.eulerAngles == plyr.rightvector) {

			//rb.AddForce(Vector2.right * speed);
			//rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

			// If the "Walk Right" ability is equipped, then the player can perform the action
			if(plyr.locked == false && (abt.eqpdwalkright == true || abt.eqpdrollerskates == true) && canwalkright == true && ((plyr.invincible_cooldowncounter > plyr.invincible_cooldowntime / 4 && plyr.invincible == true) || plyr.invincible == false) && slm.slamming == false) {
				
				// If the player is soaped, the movement will be more slippery using rigidbody physics
				if(plyr.soaped == false || plyr.soaped == true && abt.eqpdgoodgrip == true) {
					transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				}

				// If the player is not soaped, the movement will be normal
				if(plyr.soaped == true && abt.eqpdgoodgrip == false) {
					rb.AddForce(Vector2.right * plyr.speed);
				}
				//rb.velocity = new Vector2(6, rb.velocity.y);
				plyr.idle = false;

				// If the player is on the ground, the moving right animation will play
				if (plyr.grounded == true){
					anim.SetFloat("Horizontal", 1);
				}
			}

			// Using the right vector to rotate the player to the right direction
			/*if(plyr.locked == false && plyr.gravityflip == false) {
				transform.eulerAngles = plyr.rightvector;
				plyr.lookingleft = false;
				plyr.lookingright = true;
			}

			if(plyr.locked == false && plyr.gravityflip == true) {
				transform.eulerAngles = plyr.grightvector;
			}*/

			// If the player is not moving left or right, then the player is idle
		} else { 
			plyr.idle = true;
		}

		// Cooldowns
		if(start_move_cooldownleft == true) {
			moveleft_cooldowncounter++;
		}

		if(start_move_cooldownright == true) {
			moveright_cooldowncounter++;
		}

		if(moveleft_cooldowncounter > move_cooldowntime) {
			canwalkleft = true;
			start_move_cooldownleft = false;
			moveleft_cooldowncounter = 0;
		}

		if(moveright_cooldowncounter > move_cooldowntime) {
			canwalkright = true;
			start_move_cooldownright = false;
			moveright_cooldowncounter = 0;
		}

		//if(Input.GetKeyUp("left") || hmove == 0.0f || Input.GetKeyUp("right")){
		/*if(hmove == 0.0f){
			plyr.idle = true;
		}*/
	}

	// If the player is colliding with something on the left of it, it cannot move left, vice versa for moving right
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			canwalkright = false;
		}
	}

	// If the player is colliding with something on the left of it, it cannot move left, vice versa for moving right
	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			canwalkright = false;
		}
	}

	// If the player stop colliding with something on the left of it, it can move left, vice versa for moving right
	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.tag == "Lwl") {
			//canwalkleft = true;
			//move_cooldowntime++;
			start_move_cooldownleft = true;
		}

		if(col.gameObject.tag == "Rwl") {
			//canwalkright = true;
			//move_cooldowntime++;
			start_move_cooldownright = true;
		}
	}
}
