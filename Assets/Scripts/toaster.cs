// Toaster Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toaster : MonoBehaviour {

	// The target the toaster is going to shoot at, edit it in the Inspector
	public Transform player;

	// The toast the toaster is going to use, edit it in the Inspector
	public Transform toast;

	// The distance the toaster can see the player before attacking, edit it in the Inspector
 	public float distance;

 	// The time it will take for the next projectile to be shot out, edit it in the Inspector
 	//public float reloadtoast;

 	// The time it will take for the projectile to be destroyed after being shot out, edit it in the Inspector
 	public float destroytoast;

 	// Toasty Toaster Timing Timers
 	public int toaster_cooldowntime;
    public int toaster_cooldowncounter;
 	public int attack_cooldowntime;
    public int attack_cooldowncounter;

    // Checks if shootingleft, attacking, shooting or in range
    public bool shootingleft = true;
 	public bool attacking = false;
 	public bool shooting = false;
	private bool range = false;

	// Animator for the toaster
 	private Animator anim;
  

 	void Start() {
		anim = this.GetComponent<Animator>();
    }

 	void Update() {

 		// The range is set to be less than the distance it can see
		range = Vector3.Distance (transform.position, player.position) < distance;

		// The toaster will act when the player is in it's range
 		if (range == true) {

 			// If it's not attacking, it's cooling down
 			if(attacking == false) {
 				toaster_cooldowncounter++;
 				anim.SetBool("Shooting", false);
 			}

 			// When the cooldown is up, the toast will start attacking
 			if(toaster_cooldowncounter > toaster_cooldowntime) {
 				attacking = true;
 			}

 			// When attacking, the toast attack cooldown will start
 			if(attacking == true) {
 				attack_cooldowncounter++;
 				toaster_cooldowncounter = 0;
 				anim.SetBool("Shooting", true);
 				//shooting = true;
 			}

 			// If the attack is finished, the toaster will shoot
 			if(attack_cooldowncounter > attack_cooldowntime) {
 				shooting = true;
 			}

 			// When shooting, the toaster will shoot a toast
 			if(shooting == true) {

 				shooting = false;
 				attacking = false;
 				attack_cooldowncounter = 0;

 				// If the toaster is shooting left, the the toast will be shot left
 				if(shootingleft == true) {
 					// If the player is in the toaster's range, it will instantiate an exsisting bullet to it's current position				
					Transform toastt = (Transform)Instantiate(toast, new Vector3(transform.position.x + -1.3f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
 					//Transform toastt = (Transform)Instantiate(toast, transform.position, transform.rotation);

 					// Destroy the instantiated bullet after it's launch depending on the 'destroyprojectile' variable
					Destroy (toastt.gameObject, destroytoast);
				}

				// If the toaster isn't shooting left, the the toast will be shot right
				if(shootingleft == false) {
 					// If the player is in the toaster's range, it will instantiate an exsisting bullet to it's current position				
					Transform toasti = (Transform)Instantiate(toast, new Vector3(transform.position.x + 1.3f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
 					//Transform toastt = (Transform)Instantiate(toast, transform.position, transform.rotation);

 					// Destroy the instantiated bullet after it's launch depending on the 'destroyprojectile' variable
					Destroy (toasti.gameObject, destroytoast);
				}
			}
        }
 	}
}
