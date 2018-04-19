// Player Movement Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen abt;				// A script variable to access variables from the abtscreen script
	public playerslam slm;				// A script variable to access variables from the playerslam script
	public bool canwalkleft = true;		// Checks if the player can walk left
	public bool canwalkright = true;	// Checks if the player can walk right
	private bool start_move_cooldownleft = false;
	private bool start_move_cooldownright = false;
	private int move_cooldowntime = 2; 							// The cooldown on the player's invincibility when hurt
    private int moveleft_cooldowncounter = 0; 				// The counter for the invincibility cooldown
    private int moveright_cooldowncounter = 0;
	private Rigidbody2D rb;
	private Animator anim;				// The animator for the player

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
		if ((Input.GetKey("left") || hmove < -0.1f)) {

			//rb.AddForce(Vector2.left * speed);
			//rb.MovePosition(transform.position + transform.right * -speed * Time.deltaTime);

			// If the "Walk Left" ability is equipped, then the player can perform the action
			if(plyr.locked == false && abt.eqpdwalkleft == true && canwalkleft == true && ((plyr.invincible_cooldowncounter > plyr.invincible_cooldowntime / 4 && plyr.invincible == true) || plyr.invincible == false) && slm.slamming == false) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				//rb.velocity = new Vector2(-6, rb.velocity.y);
				plyr.idle = false;

				if (plyr.grounded == true) {
					anim.SetFloat("Horizontal", -1);
				}

				if(Input.GetKey("z") && plyr.grounded == true) {
					rb.velocity = new Vector2(0,0);
				}
			}

			// Using the left vector to rotate the player to the left direction
			if(plyr.locked == false) {
				transform.eulerAngles = plyr.leftvector;
			}

		// Or if right is pressed/control stick is pushed right, the player will move right
		} else if ((Input.GetKey("right") || hmove > 0.1f)) {

			//rb.AddForce(Vector2.right * speed);
			//rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

			// If the "Walk Right" ability is equipped, then the player can perform the action
			if(plyr.locked == false && abt.eqpdwalkright == true && canwalkright == true && ((plyr.invincible_cooldowncounter > plyr.invincible_cooldowntime / 4 && plyr.invincible == true) || plyr.invincible == false) && slm.slamming == false) {
				transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * plyr.speed * Time.deltaTime);
				//rb.velocity = new Vector2(6, rb.velocity.y);
				plyr.idle = false;

				if (plyr.grounded == true){
					anim.SetFloat("Horizontal", 1);
				}
			}

			// Using the right vector to rotate the player to the right direction
			if(plyr.locked == false) {
				transform.eulerAngles = plyr.rightvector;
			}

			// If the player is not moving left or right, then the player is idle
		} else { 
			plyr.idle = true;
		}

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

	// If the player is collides with something on the left of it, it cannot move left, vice versa for moving right
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
