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

 	public int toaster_cooldowntime;
    public int toaster_cooldowncounter;
 	public int attack_cooldowntime;
    public int attack_cooldowncounter;

 	public bool attacking = false;
 	public bool shooting = false;
	private bool range = false;			// Checks if the player is in the range of the toaster

 	private Animator anim;
  
	/*void Start() {

		// Shoots a single projectile repeatedly depending on the 'reloadprojectile' variable
    	InvokeRepeating("Toast", 1.0f, reloadtoast);
    }
 	
 	void Update() {

 		// The range is set to be less than the distance
		range = Vector3.Distance (transform.position, player.position) < distance;
 	}

 	void Toast() {

 		if (range == true) {
 			// If the player is in the toaster's range, it will instantiate an exsisting bullet to it's current position
 			Transform toastt = (Transform)Instantiate(toast, transform.position, transform.rotation);

 			// Destroy the instantiated bullet after it's launch depending on the 'destroyprojectile' variable
			Destroy (toastt.gameObject, destroytoast);
        }
 	}*/

 	void Start() {

		anim = this.GetComponent<Animator>();
    }

 	void Update() {

 		// The range is set to be less than the distance
		range = Vector3.Distance (transform.position, player.position) < distance;

 		if (range == true) {

 			if(attacking == false) {
 				toaster_cooldowncounter++;
 				anim.SetBool("Shooting", false);
 			}

 			if(toaster_cooldowncounter > toaster_cooldowntime) {
 				attacking = true;
 			}

 			if(attacking == true) {
 				attack_cooldowncounter++;
 				toaster_cooldowncounter = 0;
 				anim.SetBool("Shooting", true);
 				//shooting = true;
 			}

 			if(attack_cooldowncounter > attack_cooldowntime) {
 				shooting = true;
 			}

 			if(shooting == true) {

 				shooting = false;
 				attacking = false;
 				attack_cooldowncounter = 0;

 				// If the player is in the toaster's range, it will instantiate an exsisting bullet to it's current position				
				Transform toastt = (Transform)Instantiate(toast, new Vector3(transform.position.x + -1.3f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
 				//Transform toastt = (Transform)Instantiate(toast, transform.position, transform.rotation);

 				// Destroy the instantiated bullet after it's launch depending on the 'destroyprojectile' variable
				Destroy (toastt.gameObject, destroytoast);
			}
        }
 	}
}
