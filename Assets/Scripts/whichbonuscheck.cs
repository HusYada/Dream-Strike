// Which Bonus Check Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whichbonuscheck : MonoBehaviour {

	// The bonuschecks in the level
	public GameObject bnschek1;
	public GameObject bnschek2;
	public GameObject bnschek3;
	//public GameObject bnschek4;
	//public GameObject bnschek5;

	// Which bonus check this is
	public int whichbns;
	
	void OnTriggerEnter2D(Collider2D col) {

	// When the player enters a bonus, this will check the corrosponding bonus check for the bonus stage
	if(col.gameObject.tag == "Plyr") {

		if(whichbns == 1) {
				bnschek1.SetActive(true);
				bnschek2.SetActive(false);
				bnschek3.SetActive(false);
				//bnschek4.SetActive(false);
				//bnschek5.SetActive(false);
			}

			if(whichbns == 2) {
				bnschek1.SetActive(false);
				bnschek2.SetActive(true);
				bnschek3.SetActive(false);
				//bnschek4.SetActive(false);
				//bnschek5.SetActive(false);
			}

			if(whichbns == 3) {
				bnschek1.SetActive(false);
				bnschek2.SetActive(false);
				bnschek3.SetActive(true);
				//bnschek4.SetActive(false);
				//bnschek5.SetActive(false);
			}

			/*if(whichbns == 4) {
				bnschek1.SetActive(false);
				bnschek2.SetActive(false);
				bnschek3.SetActive(false);
				bnschek4.SetActive(true);
				//bnschek5.SetActive(false);
			}*/

			/*if(whichbns == 5) {
				bnschek1.SetActive(false);
				bnschek2.SetActive(false);
				bnschek3.SetActive(false);
				bnschek4.SetActive(false);
				bnschek5.SetActive(true);
			}*/
		}
	}
}
