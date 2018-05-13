// Player Script for Dream Strike by Huseyin Geyik

// Using unity's engine and system collections
using System;
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Public Script Variables  
	public playermovement move;                         // A script variable to access variables from the playermovement script
	public playerjump jump;                             // A script variable to access variables from the playerjump script
	public playerattack attack;                         // A script variable to access variables from the playerattack script
	public playerslam slam;                             // A script variable to access variables from the playerslam script
	public playerblock block;                           // A script variable to access variables from the playerblock script
	public abtscreen gotornot;                          // A script variable to access variables from the abtscreen script
	public menu menuu;                                  // A script variable to access variables from the menu script
	public GameObject mayo;                             // A variable to access components from the mayo gameobject
	// End of Public Script Variables

	// Public Variables 
	public int currenthp = 5;                           // The current HP for the player
	public int hpmax = 5;                               // The maximum amount of HP the player has
	public float apcurrent = 18;                        // The current DP (dream points) for the player
	public float apmax = 20;                            // The maximum amount of DP the player has
	public float gold = 0;                              // The current amount of gold the player has
	public int invincible_cooldowntime;                 // The cooldown on the player's invincibility when hurt
	public int invincible_cooldowncounter;              // The counter for the invincibility cooldown
	public float speed = 13f;                           // The speed the player moves at
	public bool locked = false;                         // Checks if the player is locked
	public bool lookingleft;							// Checks if the player is looking left
	public bool lookingright;							// Checks if the player is looking right
	public bool invincible = false;                     // Checks if the player is invincible
	public bool grounded = true;                        // Checks if the player is on the ground
	public bool falling = false;                        // Checks if the player is falling
	public bool gravityflip = false;					// Checks if the player is flipped in gravity mode
	public bool soaped = false;							// Checks if the player is soaped
	public bool cansoap = false;						// Checks if the player can soap jump off of walls
	public bool idle = false;                           // Checks if the player is idle
	public bool inbonus = false;						// Checks if the player is in a bonus
	public bool isbonus = false;						// Checks if the player has entered a bonus
	public bool bonuscomplete = false;					// Checks if the player has completed a bonus
	public bool bigjump = false;                        // Checks if the player has the "Big Jump" ability
	public Vector3 leftvector = new Vector3(0, 180);    // A vector that looks left
	public Vector3 rightvector = new Vector3(0, 0);     // A vector that looks right
	public Vector3 gleftvector = new Vector3(180, 180); // A vector that looks gleft
	public Vector3 grightvector = new Vector3(180, 0);  // A vector that looks gright
	public Vector3 upvector = new Vector3(0, 0);    	// A vector that looks up
	public Vector3 downvector = new Vector3(180, 0);    // A vector that looks down

	//Which Checkpoint? The checkpoint the player is at
	public bool check00 = false;
	public bool check01 = false;
	public bool check02 = false;
	public bool check03 = false;
	public bool check04 = false;
	public bool check05 = false;
	public bool check06 = false;
	/*public bool check07 = false;
	public bool check08 = false;
	public bool check09 = false;*/

	// Font styles for the heads-up display (HUD), the other four fonts serve as a psuedo-outline for hud_font
	public GUIStyle hud_font;
	public GUIStyle hud_fontoffsettl;
	public GUIStyle hud_fontoffsettr;
	public GUIStyle hud_fontoffsetbl;
	public GUIStyle hud_fontoffsetbr;

	// Wallet Icon on the HUD
	public Texture2D wallet;

	// Sound Effects
    public AudioClip hurtSFX; //Sound clip that plays when the player is hurt
    public AudioClip coinSFX; //Sound clip that plays when the player gains a coin
	// End of Public Variables

	// Private Variables
	// The colour variables for the player
	private float red = 1f;
	private float gre = 1f;
	private float blu = 1f;
	private float alp = 1f;
	private SpriteRenderer sr;                          // The sprite renderer for the player
	private Rigidbody2D rb;                             // The rigidbody for the player
	private BoxCollider2D bx;                           // The box collider for the player
	private Animator anim;                              // The animator for the player
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

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");

		/*if(Input.GetKeyDown("t")) {
			Debug.Log("Your rotation is" + this.transform.rotation);
			Debug.Log("Your euler angles are" + this.transform.eulerAngles);
		}*/

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// If the player has equipped the "Soap" ability, then the player is soaped
		if(gotornot.eqpdsoap == true) {
			soaped = true;
		}

		// If the player has not equipped the "Soap" ability, then the player is not soaped
		if(gotornot.eqpdsoap == false) {
			soaped = false;
		}

		// The colour of the player
		sr.color = new Color(red,gre,blu,alp);

		// If the game can't be paused or is paused via the menu, the player is locked from doing anything
		if(menuu.canpause == false || menuu.paused == true && gotornot.eqpdpause == true) {
			locked = true;
		} else if (menuu.canpause == true || gotornot.eqpdpause == false) {
			locked = false;
		}

		// Coins earned are rounded to the nearset interger
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
			//velocitystop.x = 0.0f;
			//rb.velocity = velocitystop;
		}

		// If left is pressed, the player will face left
		if((Input.GetKey("left") || hmove < -0.1f) && locked == false) {
			this.transform.eulerAngles = leftvector;
		}

		// If right is pressed, the player will face right
		if((Input.GetKey("right") || hmove > 0.1f) && locked == false) {
			this.transform.eulerAngles = rightvector;
		}

		// If the Rollerskates ability is equipped, the player will move in the facing direction
		if(gotornot.eqpdrollerskates == true) {
			transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * speed * Time.deltaTime);
			idle = false;
			if(this.transform.eulerAngles == leftvector && grounded == true) {
				anim.SetFloat("Horizontal", -1);
			}
			if(this.transform.eulerAngles == rightvector && grounded == true) {
				anim.SetFloat("Horizontal", 1);
			}
		}

		// If the you are invicible, an invincible counter will start and the player will flicker to indicate this
		if (invincible == true) {
			//anim.SetBool("Hurt", true);
			//move.canwalkleft = false;
			//move.canwalkright = false;
			//locked = true;
			invincible_cooldowncounter++;
			alp = Mathf.PingPong(Time.time * 32, 0.75f);
		}

		// When invincible, the hurt sound effect will play
		if(invincible_cooldowncounter == (invincible_cooldowntime - (invincible_cooldowntime - 1)) && invincible == true) {
			GetComponent<AudioSource>().PlayOneShot(hurtSFX, 0.35f); //the hurt sound effect is played 
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
			//locked = false;
		}

		// Stop flickering when invincibility is almost false
		if(invincible_cooldowncounter > invincible_cooldowntime - 2) {
			alp = 1f;
			this.GetComponent<ConstantForce2D>().force = new Vector3 (0.0F, 0.0F, 0);
		}

		// If the invincible counter reaches the cooldown time, the enemy is no longer invincible and the counter is reset
		if (invincible_cooldowncounter > invincible_cooldowntime) {
			anim.SetBool("Hurt", false);
			invincible = false;
			invincible_cooldowncounter = 0;
		}
	}

	// Limit for the player so they won't break the sound barrier
	void FixedUpdate() {
		if(GetComponent<Rigidbody2D>().velocity.magnitude > 6.0f && jump.jumping == true && soaped == false
			|| GetComponent<Rigidbody2D>().velocity.magnitude > 6.0f && jump.jumping == true && soaped == true && gotornot.eqpdgoodgrip == true) {
			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 6.0f;
		}
	}

	void OnGUI(){
		// A variable for the fontsize that changes depending on the screen size
		int fontsizee = Convert.ToInt32(40.0f * Screen.width/1920.0f);

		// Setting the font size to the new interger
		hud_font.fontSize = fontsizee;
		hud_fontoffsettl.fontSize = fontsizee;
		hud_fontoffsettr.fontSize = fontsizee;
		hud_fontoffsetbl.fontSize = fontsizee;
		hud_fontoffsetbr.fontSize = fontsizee;

		// If the Wallet ability is equipped, the player will see the number of coins they have on the HUD
		if(gotornot.eqpdwallet == true) {
			GUI.DrawTexture(new Rect(Screen.width/250f, Screen.height/1.3f, Screen.width/12f, Screen.height/12f), wallet, ScaleMode.ScaleToFit);
			GUI.Label(new Rect(Screen.width/12f, Screen.height/1.25f, Screen.width/2f, Screen.height/8f), gold.ToString(), hud_fontoffsettl);
			GUI.Label(new Rect(Screen.width/12f, Screen.height/1.25f, Screen.width/2f, Screen.height/8f), gold.ToString(), hud_fontoffsettr);
			GUI.Label(new Rect(Screen.width/12f, Screen.height/1.25f, Screen.width/2f, Screen.height/8f), gold.ToString(), hud_fontoffsetbl);
			GUI.Label(new Rect(Screen.width/12f, Screen.height/1.25f, Screen.width/2f, Screen.height/8f), gold.ToString(), hud_fontoffsetbr);
			GUI.Label(new Rect(Screen.width/12f, Screen.height/1.25f, Screen.width/2f, Screen.height/8f), gold.ToString(), hud_font);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");
		
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

		// If the player collides with a wall, then they can jump off of walls if the Soap ability is equipped
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
			slam.slamming = false;
			cansoap = true;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			if((Input.GetKeyDown("z") || xboxp1_a == true) && soaped == true) {
				rb.velocity = new Vector2(0, 0);
				jump.jumping = true;
			}
		}

		// If the player collides with a wall on there left, then they can't move left
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			cansoap = true;
		}

		// If the player collides with a wall on there right, then they can't move right
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			cansoap = true;
		}
 
		/*if(col.gameObject.tag == "Gnd" && gotornot.eqpdgravity == true && gravityflip == true) {
			//sr.flipY = true;
			transform.eulerAngles = upvector;
			//Physics.gravity = new Vector3(0, 1.0F, 0);
			rb.gravityScale = 1f;
			grounded = true;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", false);
			anim.SetBool("Hurt", false);
		}

		if(col.gameObject.tag == "Cln" && gotornot.eqpdgravity == true && gravityflip == false) {
			//sr.flipY = true;
			transform.eulerAngles = downvector;
			//Physics.gravity = new Vector3(0, -1.0F, 0);
			rb.gravityScale = -1f;
			grounded = true;
			anim.SetBool("Jumping", false);
			anim.SetBool("Double Jumping", false);
			anim.SetBool("Falling", false);
			anim.SetBool("Hurt", false);
		}*/

		// If the player collides with an enemy, they will take damage, how much damage taken depends if the Health Bar ability is equipped
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			if(gotornot.eqpdhealthbar == true) {
				currenthp -= 1;
				invincible = true;
			} else {
				currenthp -= 5;
				invincible = true;
			}
			//anim.SetBool("Hurt", true);
			//transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			//velocitystop.x = 0.0f;
			//rb.velocity = velocitystop;
			//rb.AddForce(new Vector3 (2.5f, 0.25f, 0.0f) * (speed*50));
		}

		// If the player goes through a wall somehow, the box collider will be disabled so they can escape
		if(col.gameObject.tag == "Zip") {
			bx.enabled = false;
		}
	}

	void OnCollisionStay2D(Collision2D col) {

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");

		// If the player is on the ground, then they are still grounded
		/*if(col.gameObject.tag == "Gnd") {
			grounded = true;
			block.mayoair = false;
			//falling = false;
			anim.SetBool("Falling", false);
		}*/

		/*if(col.gameObject.tag == "Gnd" && gotornot.eqpdgravity == true && gravityflip == true) {
			//sr.flipY = true;
			transform.eulerAngles = upvector;
			//Physics.gravity = new Vector3(0, 1.0F, 0);
			rb.gravityScale = 1f;
		}

		if(col.gameObject.tag == "Cln" && gotornot.eqpdgravity == true && gravityflip == false) {
			//sr.flipY = true;
			transform.eulerAngles = downvector;
			//Physics.gravity = new Vector3(0, -1.0F, 0);
			rb.gravityScale = -1f;
		}*/

		// If the player collides with a wall, then they can jump off of walls if the Soap ability is equipped
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
			cansoap = true;
			if((Input.GetKeyDown("z") || xboxp1_a == true) && soaped == true) {
				rb.velocity = new Vector2(0, 0);
				jump.jumping = true;
			}
		}

		// If the player collides with a wall on there left, then they can't move left
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			cansoap = true;
		}

		// If the player collides with a wall on there right, then they can't move right
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			cansoap = true;
		}

		// If the player collides with an enemy, they will take damage, how much damage taken depends if the Health Bar ability is equipped
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			if(gotornot.eqpdhealthbar == true) {
				currenthp -= 1;
				invincible = true;
			} else {
				currenthp -= 5;
				invincible = true;
			}
			//anim.SetBool("Hurt", true);
			//transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			//velocitystop.x = 0.0f;
			//rb.velocity = velocitystop;
			//rb.AddForce(new Vector3 (2.5f, 0.25f, 0.0f) * (speed*50));

			/*if(this.transform.eulerAngles == rightvector) {
				transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			} else if(this.transform.eulerAngles == leftvector) {
				transform.Translate (new Vector3 (-0.5f, -0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			}*/
		}

		// If the player goes through a wall somehow, the box collider will be disabled so they can escape
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

		// If the player stops colliding with a wall, then they can't jump off of it
		if(col.gameObject.tag == "Lwl") {
			//move.canwalkleft = true;
			cansoap = false;
		}

		// If the player stops colliding with a wall, then they can't jump off of it
		if(col.gameObject.tag == "Rwl") {
			//move.canwalkright = true;
			cansoap = false;
		}

		// If the player stops going through a wall, the box collider will be enabled again
		if(col.gameObject.tag == "Zip") {
			bx.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");

		if(col.gameObject.tag == "Coin") {
			GetComponent<AudioSource>().PlayOneShot(coinSFX, 0.5f); //the coin sound effect is played 
		}

		// If the player collides with an enemy, they will take damage, how much damage taken depends if the Health Bar ability is equipped
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			if(gotornot.eqpdhealthbar == true) {
				currenthp -= 1;
				invincible = true;
			} else {
				currenthp -= 5;
				invincible = true;
			}
			//anim.SetBool("Hurt", true);
			//transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			//velocitystop.x = 0.0f;
			//rb.velocity = velocitystop;
			//rb.AddForce(new Vector3 (2.5f, 0.25f, 0.0f) * (speed*50));
		}

		// If the player collides with a bread platform, it has similar properties to colliding with the ground but noteably make the player stick to the platform while it moves
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

		// If the player collides with a wall on there left, then they can't move left
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			cansoap = true;
		}

		// If the player collides with a wall on there right, then they can't move right
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			cansoap = true;
		}

		// If the player collides with a wall, then they can jump off of walls if the Soap ability is equipped
		if((col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") && falling == true) {
			grounded = false;
			slam.slamming = false;
			cansoap = true;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			if((Input.GetKeyDown("z") || xboxp1_a == true) && soaped == true) {
				rb.velocity = new Vector2(0, 0);
				jump.jumping = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col) {

		// A variable that is set to the player's rigidbody's velocity
		Vector2 velocitystop = rb.velocity;

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");

		// If the player collides with an enemy, they will take damage, how much damage taken depends if the Health Bar ability is equipped
		if(col.gameObject.tag == "Enm" && invincible == false && slam.slamming == false) {
			grounded = true;
			if(gotornot.eqpdhealthbar == true) {
				currenthp -= 1;
				invincible = true;
			} else {
				currenthp -= 5;
				invincible = true;
			}
			//anim.SetBool("Hurt", true);
			//transform.Translate (new Vector3 (-0.5f, 0.25f, 0.0f) * speed * 10 * Time.deltaTime);
			//velocitystop.x = 0.0f;
			//rb.velocity = velocitystop;
			//rb.AddForce(new Vector3 (2.5f, 0.25f, 0.0f) * (speed*50));
		}

		// If the player collides with a bread platform, it has similar properties to colliding with the ground but noteably make the player stick to the platform while it moves
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

		// If the player collides with a wall on there left, then they can't move left
		if(col.gameObject.tag == "Lwl") {
			move.canwalkleft = false;
			cansoap = true;
			if((Input.GetKeyDown("z") || xboxp1_a == true) && soaped == true) {
				rb.velocity = new Vector2(0, 0);
				jump.jumping = true;
			}
		}

		// If the player collides with a wall on there right, then they can't move right
		if(col.gameObject.tag == "Rwl") {
			move.canwalkright = false;
			cansoap = true;
			if(Input.GetKeyDown("z") && soaped == true) {
				rb.velocity = new Vector2(0, 0);
				jump.jumping = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		// If the player is no longer colliding with a platform, it will no longer be attached to it
		if(col.gameObject.tag == "PfmGnd") {
			grounded = false;
			jump.candoublejump = false;
			anim.SetBool("Falling", true);
			transform.parent = null;
		}

		// If the player stops colliding with a wall, then they can't jump off of it
		if(col.gameObject.tag == "Lwl") {
			//move.canwalkleft = true;
			cansoap = false;
		}

		// If the player stops colliding with a wall, then they can't jump off of it
		if(col.gameObject.tag == "Rwl") {
			//move.canwalkright = true;
			cansoap = false;
		}
	}
}