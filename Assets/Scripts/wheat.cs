// Wheat Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheat : MonoBehaviour {

	public playerattack atk;			// A script variable to access variables from the playerattack script
	public playerslam slam;				// A script variable to access variables from the playerslam script
	public GameObject attacktrange;		// The player's attack range
	public GameObject leaff;			// The leaf to use, edit it in the Inspector
	public bool attacked = false;		// Checks if attacked
	
	void Update () {

		// If the wheat was attacked, it will be destroyed and spwn 3 leaves
		if(attacked == true) {
			GameObject leef1 = (GameObject)Instantiate(leaff, new Vector3(transform.position.x + 0.0f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
			GameObject leef2 = (GameObject)Instantiate(leaff, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z), transform.rotation);
			GameObject leef3 = (GameObject)Instantiate(leaff, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z), transform.rotation);

			//leaff.gameObject.GetComponent<leaf>.cango = true;
			
			leaf leff1 = leef1.GetComponent<leaf>();
			leaf leff2 = leef2.GetComponent<leaf>();
			leaf leff3 = leef3.GetComponent<leaf>();
			leff1.cango = true;
			leff2.cango = true;
			leff3.cango = true;
			leff2.makeplatform = true;
			Destroy(this.gameObject);
		}
	}

	// If the wheat is shot by a projectile, attacked or slammed, then the wheat was attacked
	void OnTriggerEnter2D(Collider2D col) {
		if(col.transform.gameObject == attacktrange && atk.attacking == true || col.gameObject.tag == "Prj" || (col.gameObject.tag == "Plyr" && slam.slamming == true)) {
			attacked = true;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.transform.gameObject == attacktrange && atk.attacking == true || col.gameObject.tag == "Prj" || (col.gameObject.tag == "Plyr" && slam.slamming == true)) {
			attacked = true;
		}
	}
}
