// Bound Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour {

	public playermovement move;	// A script variable to access variables from the playermovement script
	public bool isleftwall;		// Checks if it's a leftwall
	public bool isrightwall;	// Checks if it's a rightwall


	// If the player is colliding with a wall, they will not be able to move in teh direction of the wall

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Plyr" && isleftwall == true) {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Plyr" && isrightwall == true) {
			move.canwalkright = false;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.tag == "Plyr" && isleftwall == true) {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Plyr" && isrightwall == true) {
			move.canwalkright = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Plyr" && isleftwall == true) {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Plyr" && isrightwall == true) {
			move.canwalkright = false;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.gameObject.tag == "Plyr" && isleftwall == true) {
			move.canwalkleft = false;
		}

		if(col.gameObject.tag == "Plyr" && isrightwall == true) {
			move.canwalkright = false;
		}
	}
}
