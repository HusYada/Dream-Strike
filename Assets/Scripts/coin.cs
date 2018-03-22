using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	public player plyr;
	public float amount = 0.5f; 

	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr") {

			plyr.gold = plyr.gold + amount;
			Destroy(this.gameObject);
		}
	}
}
