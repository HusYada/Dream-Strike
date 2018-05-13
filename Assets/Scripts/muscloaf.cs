// Muscloaf Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muscloaf : MonoBehaviour {

  // A script variable to access variables from the abtscreen script
  public abtscreen abt;                     

  // The muscloaf itself
	public GameObject muscloaff;

  // Cooldowns for muscloaf's attacks
	public bool muscloaf_iscooldown = true;
  public int muscloaf_cooldowntime;
  public int muscloaf_cooldowncounter;
  //public bool attack_iscooldown;
  public int attack_cooldowntime;
  public int attack_cooldowncounter;
  public int attack_cooldowntime2;
  public int attack_cooldowncounter2;
  public int attack_cooldowntime3;
  public int attack_cooldowncounter3;

  // The hot cross bun to use, edit it in the Inspector
  public Transform rock;

  // The target the enemy is going to shoot at, edit it in the Inspector
	public Transform player;

	// The projectile the enemy is going to use, edit it in the Inspector
	//public Transform projectile;

	// The distance the enemy can see the player before attacking, edit it in the Inspector
 	public float distance;

  // Attack checks
  public bool pickatk = false;
 	public bool attacking = false;
 	public bool punching = false;
  public bool attacking2 = false;
  public bool slamming = false;
  public bool attacking3 = false;

  // Sound effects
  public AudioClip punchSFX;
  public AudioClip punchprepSFX;
  public AudioClip shotputSFX;

 	// The time it will take for the next projectile to be shot out, edit it in the Inspector
 	//public float reloadprojectile;

 	// The time it will take for the projectile to be destroyed after being shot out, edit it in the Inspector
 	public float destroyprojectile;

 	// Checks if the player is in the range of the enemy
	private bool range = false;

  // The box collider for the player
  private BoxCollider2D bx;

  // The animator for the player
	public Animator anim;
  
	void Start() {

		  // Getting components
    	bx = this.GetComponent<BoxCollider2D>();
      anim = muscloaff.GetComponent<Animator>();
    }

 	void Update() {

    // The range is set to be less than the distance
    range = Vector3.Distance (transform.position, player.position) < distance;

        /*if(pickatk == false && punching == false && attacking == false) {
          pickatk == true;
        }*/

        // If the player is in range, muscloaf will attack
        if(range == true && muscloaff.GetComponent<enemy>().health > 0) {

        // Pick an attack
        int numbah = Random.Range(0, 100);

        // Shotput
        if(pickatk == true && numbah < 26) {
          pickatk = false;
          //Debug.Log("<color=red>Shotput: Your random number is 25 or lower = </color>" + numbah);
          attacking3 = true;
          anim.SetBool("Shotputting", true);
          bx.size = new Vector2(3f, 3f);
          bx.offset = new Vector2(-1.5f, -0.5f);
        }

        // Punch
        if(pickatk == true && numbah > 25 && numbah < 75) {
          pickatk = false;
          //Debug.Log("<color=green>Punch: Your random number is between 26 to 74 = </color>" + numbah);
          attacking = true;
          anim.SetBool("Attacking", true);
          bx.size = new Vector2(3f, 3f);
          bx.offset = new Vector2(-1.5f, -0.5f);
        }

        // Uppercut
        if(pickatk == true && numbah > 74) {
          pickatk = false;
          //Debug.Log("<color=blue>Upper: Your random number is 75 or higher = </color>" + numbah);
          attacking2 = true;
          anim.SetBool("Attacking", true);
          bx.size = new Vector2(4f, 5f);
          bx.offset = new Vector2(-2f, -0.5f);
        }

        /*if(Input.GetKey("h")) {
          int numbah = Random.Range(0, 100);
          Debug.Log("Ur randumb numbugh iz " + numbah);
        }*/

        /*if(Input.GetKey("r")) {
          bx.size = new Vector2(4f, 5f);
          bx.offset = new Vector2(-2f, -0.5f);
        }*/

        //if(muscloaf_iscooldown == false) {
        	//attacking = true;
        	//anim.SetBool("Attacking", true);
          //pickatk = true;
        //}

        // Cooldown after doing an attack
        if (muscloaf_iscooldown == true) {
           	muscloaf_cooldowncounter++;
           	attacking = false;
            attacking2 = false;
            attacking3 = false;
           	anim.SetBool("Attacking", false);
            
       	}

       	// If the muscloaf counter is equal to its time, the muscloaf will pick another attack
	  	if (muscloaf_cooldowncounter >= muscloaf_cooldowntime) {
            muscloaf_iscooldown = false;
           	muscloaf_cooldowncounter = 0;
            pickatk = true;
        }

        // Punch Attack
        if (attacking == true) {
           attack_cooldowncounter++;
       	}

        if(attacking == true && attack_cooldowncounter < 5 && punching == false) {
          //GetComponent<AudioSource>().PlayOneShot(punchprepSFX, 0.35f);
        }

        if (attack_cooldowncounter2 >= attack_cooldowntime2 / 1.25 && attack_cooldowncounter2 < ((attack_cooldowntime2 / 1.25) + 4)) {
          GetComponent<AudioSource>().PlayOneShot(punchSFX, 0.15f);
        }

       	if (attack_cooldowncounter >= attack_cooldowntime / 1.25 && attack_cooldowncounter <= attack_cooldowntime / 1.025) {
       	//if (attack_cooldowncounter > 27 && attack_cooldowncounter < 29) {
       		punching = true;
       	}

       	// If the muscloaf counter is equal to its time, the muscloaf will cooldown
	  	  if (attack_cooldowncounter >= attack_cooldowntime) {
	  	      muscloaf_iscooldown = true;
            attacking = false;
            punching = false;
           	attack_cooldowncounter = 0;
        }

        // Slam Attack
        if (attacking2 == true) {
           attack_cooldowncounter2++;
        }

        if(attacking2 == true && attack_cooldowncounter2 < 5 && slamming == false) {
          //GetComponent<AudioSource>().PlayOneShot(punchprepSFX, 0.35f);
        }

        if (attack_cooldowncounter2 >= attack_cooldowntime2 / 1.25 && attack_cooldowncounter2 < ((attack_cooldowntime2 / 1.25) + 4)) {
          GetComponent<AudioSource>().PlayOneShot(punchSFX, 0.15f);
        }

        if (attack_cooldowncounter2 >= attack_cooldowntime2 / 1.25 && attack_cooldowncounter2 <= attack_cooldowntime2 / 1.025) {
        //if (attack_cooldowncounter > 27 && attack_cooldowncounter < 29) {
          slamming = true;
        }

        if (attack_cooldowncounter2 >= attack_cooldowntime2) {
            muscloaf_iscooldown = true;
            attacking2 = false;
            slamming = false;
            attack_cooldowncounter2 = 0;
        }

        // Shotput
        if(attacking3 == true) {
          attack_cooldowncounter3++;
        }

        if (attack_cooldowncounter3 >= attack_cooldowntime3 / 2 && attack_cooldowncounter3 < ((attack_cooldowntime3 / 2) + 1)) {
        //if (attack_cooldowncounter > 27 && attack_cooldowncounter < 29) {

          Transform rockk = (Transform)Instantiate(rock, new Vector3(transform.position.x + -1.3f, transform.position.y, transform.position.z), transform.rotation);
          Destroy (rockk.gameObject, destroyprojectile);
          GetComponent<AudioSource>().PlayOneShot(shotputSFX, 0.35f);
          anim.SetBool("Shotputting", false);
        }

        if (attack_cooldowncounter3 >= attack_cooldowntime3) {
            muscloaf_iscooldown = true;
            attacking3 = false;
            attack_cooldowncounter3 = 0;
        }
      }
 	}

 	void OnTriggerEnter2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's punching, the enemy will take damage
		if(col.gameObject.tag == "Plyr" && punching == true && col.gameObject.GetComponent<player>().invincible == false) {
			if(abt.eqpdhealthbar == true) {
        col.gameObject.GetComponent<player>().currenthp -= 1;
        col.gameObject.GetComponent<player>().invincible = true;
      } else {
        col.gameObject.GetComponent<player>().currenthp -= 5;
        col.gameObject.GetComponent<player>().invincible = true;
      }
			//col.transform.Translate (new Vector3 (-0.5f, 0.0f, 0.0f) * 13 * 30 * Time.deltaTime);
      col.gameObject.GetComponent<ConstantForce2D>().force = new Vector3 (-20.0F, 0.0F, 0);
		}

    if(col.gameObject.tag == "Plyr" && slamming == true && col.gameObject.GetComponent<player>().invincible == false) {
      if(abt.eqpdhealthbar == true) {
        col.gameObject.GetComponent<player>().currenthp -= 1;
        col.gameObject.GetComponent<player>().invincible = true;
      } else {
        col.gameObject.GetComponent<player>().currenthp -= 5;
        col.gameObject.GetComponent<player>().invincible = true;
      }
      col.transform.Translate (new Vector3 (0.0f, 0.5f, 0.0f) * 13 * 30 * Time.deltaTime);
    }
	}

 	void OnTriggerStay2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's punching, the enemy will take damage
		if(col.gameObject.tag == "Plyr" && punching == true && col.gameObject.GetComponent<player>().invincible == false) {
			if(abt.eqpdhealthbar == true) {
        col.gameObject.GetComponent<player>().currenthp -= 1;
        col.gameObject.GetComponent<player>().invincible = true;
      } else {
        col.gameObject.GetComponent<player>().currenthp -= 5;
        col.gameObject.GetComponent<player>().invincible = true;
      }
			//col.transform.Translate (new Vector3 (-0.5f, 0.0f, 0.0f) * 13 * 30 * Time.deltaTime);
      //col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-60, col.gameObject.GetComponent<Rigidbody2D>().velocity.x);
      col.gameObject.GetComponent<ConstantForce2D>().force = new Vector3 (-20.0F, 0.0F, 0);
		}

    if(col.gameObject.tag == "Plyr" && slamming == true && col.gameObject.GetComponent<player>().invincible == false) {
      if(abt.eqpdhealthbar == true) {
        col.gameObject.GetComponent<player>().currenthp -= 1;
        col.gameObject.GetComponent<player>().invincible = true;
      } else {
        col.gameObject.GetComponent<player>().currenthp -= 5;
        col.gameObject.GetComponent<player>().invincible = true;
      }
      col.transform.Translate (new Vector3 (0.0f, 0.5f, 0.0f) * 13 * 30 * Time.deltaTime);
    }
	}

  void OnTriggerExit2D(Collider2D col) {
    if(col.gameObject.tag == "Plyr" && punching == true && col.gameObject.GetComponent<player>().invincible == false) {
      col.gameObject.GetComponent<ConstantForce2D>().force = new Vector3 (0.0F, 0.0F, 0);
    }
  }
}