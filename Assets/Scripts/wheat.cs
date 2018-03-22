using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheat : MonoBehaviour {

	public playerattack atk;
	public GameObject attacktrange;
	public GameObject leaff;	// The leaf to use, edit it in the Inspector
	public bool attacked = false;	
	
	// Update is called once per frame
	void Update () {
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

	void OnTriggerEnter2D(Collider2D col) {
		if(col.transform.gameObject == attacktrange && atk.attacking == true || col.gameObject.tag == "Prj") {
			attacked = true;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.transform.gameObject == attacktrange && atk.attacking == true || col.gameObject.tag == "Prj") {
			attacked = true;
		}
	}
}
