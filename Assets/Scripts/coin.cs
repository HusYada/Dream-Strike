using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	public player plyr;
	public abtscreen abt;
	public float amount = 0.5f; 

	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr" && abt.eqpdwallet == true) {

			plyr.gold = plyr.gold + amount;
			Destroy(this.gameObject);
		}
	}
}
