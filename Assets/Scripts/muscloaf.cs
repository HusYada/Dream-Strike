using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muscloaf : MonoBehaviour {

	public GameObject muscloaff;

	public bool muscloaf_iscooldown;
    public int muscloaf_cooldowntime;
    public int muscloaf_cooldowncounter;

    //public bool attack_iscooldown;
    public int attack_cooldowntime;
    public int attack_cooldowncounter;

    public GameObject rock;			// The block to use, edit it in the Inspector

   	// The target the enemy is going to shoot at, edit it in the Inspector
	public Transform player;

	// The projectile the enemy is going to use, edit it in the Inspector
	//public Transform projectile;

	// The distance the enemy can see the player before attacking, edit it in the Inspector
 	public float distance;
 	public bool attacking = false;
 	public bool punching = false;

 	// The time it will take for the next projectile to be shot out, edit it in the Inspector
 	//public float reloadprojectile;

 	// The time it will take for the projectile to be destroyed after being shot out, edit it in the Inspector
 	//public float destroyprojectile;

 	// Checks if the player is in the range of the enemy
	//private bool range = false;

	public Animator anim;
  
	void Start() {

		// Shoots a single projectile repeatedly depending on the 'reloadprojectile' variable
    	//InvokeRepeating("Pound", 1.0f, reloadprojectile);
    	anim = muscloaff.GetComponent<Animator>();
    }

 	void Update() {

 		/*if (!GetComponent<enemy>().dead && muscloaf_iscooldown == false) {
 			// If the player is in the enemy's range, it will instantiate an exsisting bullet to it's current position
 			//Transform bullet = (Transform)Instantiate(projectile, transform.position, transform.rotation);

 			GameObject rock1 = (GameObject)Instantiate(rock, new Vector3(transform.position.x - 5, transform.position.y + 4, transform.position.z), transform.rotation);
 			GameObject rock2 = (GameObject)Instantiate(rock, new Vector3(transform.position.x - 7, transform.position.y + 4, transform.position.z), transform.rotation);
 			GameObject rock3 = (GameObject)Instantiate(rock, new Vector3(transform.position.x - 9, transform.position.y + 4, transform.position.z), transform.rotation);
 			muscloaf_iscooldown = true;

 			// Destroy the instantiated bullet after it's launch depending on the 'destroyprojectile' variable
			Destroy (rock1.gameObject, 13.0f);
			Destroy (rock2.gameObject, 13.0f);
			Destroy (rock3.gameObject, 13.0f);
        }*/

        if(muscloaf_iscooldown == false) {
        	attacking = true;
        	anim.SetBool("Attacking", true);
        }

        if (muscloaf_iscooldown == true) {
           	muscloaf_cooldowncounter++;
           	attacking = false;
           	anim.SetBool("Attacking", false);
       	}

       	// If the menu counter is equal to its time, the menu screen can be changed again
	  	if (muscloaf_cooldowncounter >= muscloaf_cooldowntime) {
            muscloaf_iscooldown = false;
           	muscloaf_cooldowncounter = 0;
        }

        if (attacking == true) {
           attack_cooldowncounter++;
       	}

       	if (attack_cooldowncounter >= attack_cooldowntime / 1.25 && attack_cooldowncounter <= attack_cooldowntime / 1.025) {
       	//if (attack_cooldowncounter > 27 && attack_cooldowncounter < 29) {
       		punching = true;
       	}

       	// If the menu counter is equal to its time, the menu screen can be changed again
	  	if (attack_cooldowncounter >= attack_cooldowntime) {
	  		muscloaf_iscooldown = true;
            attacking = false;
            punching = false;
           	attack_cooldowncounter = 0;
        }
 	}

 	void OnTriggerEnter2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's punching, the enemy will take damage
		if(col.gameObject.tag == "Plyr" && punching == true && col.gameObject.GetComponent<player>().invincible == false) {
			col.gameObject.GetComponent<player>().currenthp -= 1;
			col.gameObject.GetComponent<player>().invincible = true;
			col.transform.Translate (new Vector3 (-0.5f, 0.0f, 0.0f) * 13 * 30 * Time.deltaTime);
		}
	}

 	void OnTriggerStay2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's punching, the enemy will take damage
		if(col.gameObject.tag == "Plyr" && punching == true && col.gameObject.GetComponent<player>().invincible == false) {
			col.gameObject.GetComponent<player>().currenthp -= 1;
			col.gameObject.GetComponent<player>().invincible = true;
			col.transform.Translate (new Vector3 (-0.5f, 0.0f, 0.0f) * 13 * 30 * Time.deltaTime);
		}
	}
}