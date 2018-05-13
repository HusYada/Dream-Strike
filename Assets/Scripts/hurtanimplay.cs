// Hurt Anim Play Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtanimplay : MonoBehaviour {

	public player plyr;				// A script variable to access variables from the player script
	private bool boihurt = false;	// Checks if the player is hurt
	
	void Update () {

		// If the player is hurt they will be invincible
		if(boihurt == true) {
			//anim.Play("plyr_hurt");
			//anim.SetBool("Hurt", true);
			//plyr.GetComponent<AudioSource>().PlayOneShot(plyr.hurtSFX, 0.35f); //the hurt sound effect is played
			plyr.invincible = true;
			boihurt = false;
		}
	}

	// If the player touches this they will be hurt
	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr") {
			boihurt = true;
		}
	}

	void OnTriggerStay2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr") {
			boihurt = true;
		}
	}
}
