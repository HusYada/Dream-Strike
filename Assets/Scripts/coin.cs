// Coin Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public abtscreen abt;				// A script variable to access variables from the abtscreen script
	public float amount = 0.5f;			// How much the coin is worth
	public float bigmultiplier = 1;		// How much the amount is multiplied by depending on its size
	public bool big = false;			// Checks if the coin is big
	public bool good = true;			// Checks if the coin is good

	void Start() {

		// If the coin is big, it will be worth 5 instead of 1
		if(big == true) {
			bigmultiplier = 5;
		}

		if(big == false) {
			bigmultiplier = 1;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		// When the player touches a coin, they will gain gold and destroy the coin
		if(col.gameObject.tag == "Plyr" && abt.eqpdwallet == true) {

			if(good == true) {
				plyr.gold = plyr.gold + amount * bigmultiplier;
				Destroy(this.gameObject);
			}

			if(good == false) {
				plyr.gold = plyr.gold - amount * bigmultiplier;
				Destroy(this.gameObject);
			}
		}
	}
}
