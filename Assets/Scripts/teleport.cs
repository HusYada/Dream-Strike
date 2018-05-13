// Teleport Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public player plyr;				// A script variable to access variables from the player script
	public playermovement move;		// A script variable to access variables from the playermovement script
	public bonuscheck bnschk;		// A script variable to access variables from the bonuscheck script
	public Vector3 gohere;			// The position the player will be teleported to


	void OnTriggerEnter2D(Collider2D col) {

		// If the player touches this, they will be teleported, cannot move while teleported
		if(col.gameObject.tag == "Plyr") {
			plyr.transform.position = gohere;
			if(bnschk.bonuswalkleft == true) {
				move.canwalkleft = true;
			}
			if(bnschk.bonuswalkright == true) {
				move.canwalkright = true;
			}
		}
	}
}
