// Shotput Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotput : MonoBehaviour {

	public float xdirection;	// The speed the object will travel at along the x axis, edit it in the Inspector
	public float ydirection;	// The speed the object will travel at along the y axis, edit it in the Inspector
	public float zdirection;	// The speed the object will travel at along the z axis, edit it in the Inspector
    public bool badforenemies;  // Checks if the the projectile hurts enemies, edit it in the Inspector
    public bool left;			// Goes left or not
	private Rigidbody2D rb;		// The rigidbody for the projectile
	private BoxCollider2D bx;	// The box collider for the projectile

	void Start() {

		// Getting the components
		rb   = this.GetComponent<Rigidbody2D>();
		bx   = this.GetComponent<BoxCollider2D>();

		// The direction it will go
		if(left == true) {
			rb.AddForce(new Vector2(-0.25f,0.75f) * 200);
		}

		if(left == false) {
			rb.AddForce(new Vector2(0.25f,0.75f) * 200);
		}
	}

	// Same projectile aspects
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
