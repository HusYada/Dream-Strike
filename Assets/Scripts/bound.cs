using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour {

	public playermovement move;
	public bool isleftwall;
	public bool isrightwall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
