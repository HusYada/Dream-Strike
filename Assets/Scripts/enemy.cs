	// Enemy Script for Dream Strike by Huseyin Geyik

	using UnityEngine;
	using System.Collections;
	
	public class enemy : MonoBehaviour {

	//public abtscreen bigjumpornah;			// Checks if the "Big Jump" ability is unlocked

    public int health; 						            // The number of hits an enemy can take
    public int invincible_cooldowntime; 	    // The cooldown on the enemy's invincibility when hurt
    public int invincible_cooldowncounter; 	  // The counter for the invincibility cooldown
    public int dead_cooldowntime; 			      // The amount of time the enemy stays on the screen when dead
    public int dead_cooldowncounter;		      // The counter for the enemy's death
    public Transform coinn;                   // The coin that will be dropped, edit it in the Inspector

    public bool dead; 						            // Checks if the enemy is dead
    public bool invincible; 			            // Checks if the enemy is invincible
    public bool dropcoin;                     // Checks if the enemy drops a coin
    public bool issparroti;                   // Checks if the enemy is sparroti
    public bool ismuscloaf;                    // Checks if the enemy is muscloaf

    // Death sound effects depending on enemy
    public AudioClip sparrotiSFX;
    public AudioClip muscloafdeathSFX;

    // Colour variables of the enemy
    private float red = 1f;
    private float gre = 1f;
    private float blu = 1f;
    private float alp = 1f;
    private SpriteRenderer sr;                          // The sprite renderer for the enemy
    private BoxCollider2D bx;                           // The box collider for the enemy

	void Start () {

        // Getting the components
        //rb   = this.GetComponent<Rigidbody2D>();
        bx   = this.GetComponent<BoxCollider2D>();
        sr   = this.GetComponent<SpriteRenderer>();

        // Sets the invinsibility and death counters to 0
       	invincible = false;
       	invincible_cooldowncounter = 0;
       	dead_cooldowncounter = 0;
	}
		
	void FixedUpdate() {

        //Vector2 velocitystop = rb.velocity * -1f;

        // The colour of the enemy
        sr.color = new Color(red,gre,blu,alp);

        /*if(dontgothere == true) {
            velocitystop.x = 0.0f;
            rb.velocity = velocitystop;
        }*/

		// If the enemy is invicible, an invincible counter will start
		if (invincible == true) {
           	invincible_cooldowncounter++;
            alp = Mathf.PingPong(Time.time * 32, 0.75f);
       	}

       	// If the invincible counter reaches the cooldown time, the enemy is no longer invincible and the counter is reset
       	if (invincible_cooldowncounter >= invincible_cooldowntime) {
           	invincible = false;
           	invincible_cooldowncounter = 0;
            alp = 1.0f;
       	}

       	// If the enemy's health is equal or less than 0, the enemy is dead
       	if (health <= 0) {
           	dead = true;
       	}

       	// If the enemy is dead, a death counter will start and the player will gain the "Big Jump" ability
       	if (dead == true) {
           	dead_cooldowncounter++;
          	//bigjumpornah.hasbigjump = true;
            sr.enabled = false;
            bx.enabled = false;
       	}

        if(dead == true && dead_cooldowncounter < 5) {
            if(issparroti == true) {
                GetComponent<AudioSource>().PlayOneShot(sparrotiSFX, 0.5f);
            }
            if(ismuscloaf == true) {
                GetComponent<AudioSource>().PlayOneShot(muscloafdeathSFX, 0.5f);
            }
        }

       	// When the death counter is finished, the gameobject is destroyed 
       	if (dead_cooldowncounter >= dead_cooldowntime) {
            if(dropcoin == true) {
                Transform.Instantiate(coinn, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
           	Destroy(gameObject);
       	}
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Ebnd") {
           //dontgothere = true;
        }
    }

     void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Ebnd") {
          // dontgothere = false;
        }
    }
}