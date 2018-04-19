// Player Script for Dream Strike

// Using unity's engine and system collections
using System;
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Public Script Variables	
	public playermovement move;							// A script variable to access variables from the playermovement script
	public playerjump jump;								// A script variable to access variables from the playerjump script
	public playerattack attack;							// A script variable to access variables from the playerattack script
	public playerslam slam;								// A script variable to access variables from the playerslam script
	public playerblock block;							// A script variable to access variables from the playerblock script
	public abtscreen gotornot;							// A script variable to access variables from the abtscreen script
	public menu menuu;									// A script variable to access variables from the menu script
	public GameObject mayo;								// A variable to access components from the mayo gameobject
	// End of Public Script Variables

	// Public Variables	
	public int currenthp = 5;							// The current HP for the player
	public int hpmax = 5;								// The maximum amount of HP the player has
	public float apcurrent = 18;						// The current AP for the player
	public float apmax = 20;							// The maximum amount of AP the player has
	public float gold = 0;								// The current amount of gold the player has
	public int invincible_cooldowntime; 				// The cooldown on the player's invincibility when hurt
    public int invincible_cooldowncounter; 				// The counter for the invincibility cooldown
	public float speed = 13f;       					// The speed the player moves at
	public bool locked = false;							// Checks if the player is locked
	public bool invincible = false; 					// Checks if the player is invincible
	public bool grounded = true;						// Checks if the player is on the ground
	public bool falling = false;						// Checks if the player is falling
	public bool idle = false;							// Checks if the player is idle
	public bool bigjump = false;						// Checks if the player has the "Big Jump" ability
	public Vector3 leftvector = new Vector3(0, 180); 	// A vector that looks left
   	public Vector3 rightvector = new Vector3(0, 0); 	// A vector that looks right

   	//Which Checkpoint?
   	public bool check00 = false;
	public bool check01 = false;
	public bool check02 = false;
	public bool check03 = false;
	public bool check04 = false;
	public bool check05 = false;
	public bool check06 = false;
	public bool check07 = false;
	public bool check08 = false;
	public bool check09 = false;

	// End of Public Variables

	// Private Variables
	private float red = 1f;
	private float gre = 1f;
	private float blu = 1f;
	private float alp = 1f;
	private SpriteRenderer sr;							// The sprite renderer for the player
	private Rigidbody2D rb;								// The rigidbody for the player
	private BoxCollider2D bx;							// The box collider for the player
	private Animator anim;								// The animator for the player
   	// End of Private Variables
		
	void Start() {

		// Getting the components
		sr   = this.GetComponent<SpriteRenderer>();
		rb   = this.GetComponent<Rigidbody2D>();
		bx   = this.GetComponent<BoxCollider2D>();
		anim = this.GetComponent<Animator>();

		//invincible = false;
        //invincible_cooldowncounter = 0;
	}
		
	void Update() {

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// The colour of the player
		sr.color = new Color(red,gre,blu,alp);

		// If the game can't be paused or is paused via the menu, the player is locked from doing anything
		if(menuu.canpause == false || menuu.paused == true) {
			locked = true;
		} else if (menuu.canpause == true) {
			locked = false;
		}

		gold = Mathf.Round(gold);

		// If the player isn't jumping, attacking nor grounded, then the falling animation should play
		if (attack.attacking == false && grounded == false && jump.jumping == false && jump.djumpcurrentframe == 0) {
			anim.SetBool("Falling", true);
			jump.jumping = false;
			falling = true;
			block.mayoair = true;

			// If the player double jumped, the double jump cooldown will start
			if(jump.djumped == false){
				jump.candjumpcurrentframe++;
			}

		} else {
			falling = false;
		}
			
		// If the player is idle, the idle animation will play
		if (idle == true) {
			anim.SetFloat("Horizontal", 0);
			// So the player doesn't slide around due to add force
			velocitystop.x = 0.0f;
			rb.velocity = velocitystop;
		}

		// If the you are invicible, an invincible counter will start
		if (invincible == true) {
			//anim.SetBool("Hurt", true);
			//move.canwalkleft = false;
			//move.canwalkright = false;
			locked = true;
           	invincible_cooldowncounter++;
           	alp = Mathf.PingPong(Time.time * 32, 0.75f);
        }

        // Hurt animation will play if the invincibility counter is below 1/4 of the total invincibilty cooldown time
        if(invincible_cooldowncounter < invincible_cooldowntime / 4 && invincible == true) {
        	//anim.Play("plyr_hurt");
        	anim.SetBool("Hurt", true);
        	//grounded = false;
        	//idle = false;
			//falling = false;
        }

         // Hurt animation will stop if the invincibility counter goes over 1/4 of the total invincibilty cooldown time
        if(invincible_cooldowncounter >= invincible_cooldowntime / 4 && invincible == true) {
        	anim.SetBool("Hurt", false);
        	//move.canwalkleft = true;
			//move.canwalkright = true;
			locked = false;
        }

        // Stop flickering when invincibility is almost false
        if(invincible_cooldowncounter > invincible_cooldowntime - 2) {
        	alp = 1f;
        }

        // If the invincible counter reaches the cooldown time, the enemy is no longer invincible and the counter is reset
        if (invincible_cooldowncounter > invincible_cooldowntime) {
        	anim.SetBool("Hurt", false);
           	invincible = false;
           	invincible_cooldowncounter = 0;
        }
	}

	// Limit for the player so it doesn't break the sound barrier
	void FixedUpdate() {
		if(GetComponent<Rigidbody2D>().velocity.magnitude > 6.0f && jump.jumping == true) {
			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 6.0f;
		}
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        /*if (Physics.Raycast(transform.position, leftvector, 10)) {
            print("There is something in front of the object!");
        }*/
	}

	void OnGUI(){
		// A variable for the fontsize that changes depending on the screen size
        int fontscale = Convert.ToInt32(40.0f * Screen.width/1920.0f);

        // Setting the font size to the new interger
        gotornot.abtscreen_font.fontSize = fontscale;
		
		// Health "bar"

		if(gotornot.eqpdhealthbar == true) {
			GUI.Label(new Rect(Screen.width/20f, Screen.height/1.1f, Screen.width/2f, Screen.height/8f), currenthp.ToString() + " / " + hpmax.ToString(), gotornot.abtscreen_font);
		}

		if(gotornot.eqpdwallet == true) {
			GUI.Label(new Rect(Screen.width/20f, Screen.height/1.05f, Screen.width/2f, Screen.height/8f), gold.ToString(), gotornot.abtscreen_font);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		
	// Checks if player is on the ground, if so then the player is grounded, can jump again, cannot double jump and animations are changed
		/*if(col.gameObject.tag == "Gnd" && falling == false) {
			grounded = true;
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

		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
			slam.slamming = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
		}

		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			currenthp -= 1;
			invincible = true;
			//anim.SetBool("Hurt", true);
			transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
		}

		if(col.gameObject.tag == "Zip") {
			bx.enabled = false;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		// If the player is on the ground, then they are still grounded
		/*if(col.gameObject.tag == "Gnd") {
			grounded = true;
			block.mayoair = false;
			//falling = false;
			anim.SetBool("Falling", false);
		}*/

		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
		}

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
		}

		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			currenthp -= 1;
			invincible = true;
			//anim.SetBool("Hurt", true);
			transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);

			/*if(this.transform.eulerAngles == rightvector) {
				transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			} else if(this.transform.eulerAngles == leftvector) {
				transform.Translate (new Vector3 (-0.5f, -0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			}*/
		}

		if(col.gameObject.tag == "Zip") {
			bx.enabled = false;
		}
	}

	void OnCollisionExit2D(Collision2D col) {

		// If the player is no longer colliding with the ground, then the player is not grounded
		/*if(col.gameObject.tag == "Gnd") {
			grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
		}*/

		if(col.gameObject.tag == "Lwl") {
			//move.canwalkleft = true;
		}

		if(col.gameObject.tag == "Rwl") {
			//move.canwalkright = true;
		}

		if(col.gameObject.tag == "Zip") {
			bx.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			currenthp -= 1;
			invincible = true;
			//anim.SetBool("Hurt", true);
			transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
		}

		if(col.gameObject.tag == "PfmGnd") {
        	grounded = true;
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

        /*if(col.gameObject.tag == "Mayo") {
			//block.mayoair = true;
		}*/

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
		}

		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
			slam.slamming = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			currenthp -= 1;
			invincible = true;
			//anim.SetBool("Hurt", true);
			transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
		}

		if(col.gameObject.tag == "PfmGnd") {
        	grounded = true;
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

        /*if(col.gameObject.tag == "Mayo") {
			//block.mayoair = true;
		}*/

		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "PfmGnd") {
			grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
        	transform.parent = null;
        }

        if(col.gameObject.tag == "Lwl") {
			//move.canwalkleft = true;
		}

		if(col.gameObject.tag == "Rwl") {
			//move.canwalkright = true;
		}
	}
}