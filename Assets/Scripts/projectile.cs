// Projectile Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float xdirection;	// The speed the object will travel at along the x axis, edit it in the Inspector
	public float ydirection;	// The speed the object will travel at along the y axis, edit it in the Inspector
	public float zdirection;	// The speed the object will travel at along the z axis, edit it in the Inspector
    public bool badforenemies; // Checks if the the projectile hurts enemies, edit it in the Inspector
	private BoxCollider2D bx;	// The box collider for the projectile

	void Start() {

		// Getting the components
		bx   = this.GetComponent<BoxCollider2D>();
	}
 	
 	void Update() {

    	// By adding speed to the enemy's x position, the enemy will move either left or right
     	transform.position = new Vector3(transform.position.x + xdirection * Time.deltaTime,
     									 transform.position.y + ydirection * Time.deltaTime,
     									 transform.position.z + zdirection * Time.deltaTime); 
    }

    // If the toaster touches the player it's box collider will turn off
    // If it touches a wall, it will be destroyed
    void OnCollisionEnter2D(Collision2D col) {

    	if(col.gameObject.tag == "Plyr") {
    		bx.enabled = false;
    	}

    	if(col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") {
			Destroy(this.gameObject);
		}
    }

    void OnCollisionStay2D(Collision2D col) {

    	if(col.gameObject.tag == "Plyr") {
    		bx.enabled = false;
    	}

    	if(col.gameObject.tag == "Lwl" || col.gameObject.tag == "Rwl") {
			Destroy(this.gameObject);
		}
    }

    void OnCollisionExit2D(Collision2D col) {
    	if(col.gameObject.tag == "Plyr") {
    		bx.enabled = true;
    	}
    }

 	void OnTriggerStay2D(Collider2D col) {
		
		// Checks if player's hitbox is inside an enemy while it's attacking, the enemy will take damage
		if(badforenemies == true && col.gameObject.tag == "Enm" && col.gameObject.GetComponent<enemy>().invincible == false) {
			col.gameObject.GetComponent<enemy>().health -= 1;
			col.gameObject.GetComponent<enemy>().invincible = true;
		}
	}
}
