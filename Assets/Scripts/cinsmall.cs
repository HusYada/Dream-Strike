// Small Cinammon Roll Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinsmall : MonoBehaviour {

	public int actioncounter = 0;	// The counter that determines the roll's action
	public int frontgroundtime;		// The time it takes for the roll to reach the main level
	public int frontalltime;		// The time it takes for the roll to reach the foreground
	public int actionendtime;		// The time it takes for the roll to reset

	private Vector3 position;		// Position of the roll
	private Animator anim;			// The animator for the roll
	private BoxCollider2D bx;		// The box collider for the player

	void Start () {

		// Getting components and position
		anim = this.GetComponent<Animator>();
		bx = this.GetComponent<BoxCollider2D>();
		position = this.transform.position;
	}
	
	void FixedUpdate () {

		// Counter will go
		actioncounter++;
		this.transform.position = position;

		/*if(Input.GetKeyDown("k")) {
			position.z = this.transform.position.z - 1f;
		}
		if(Input.GetKeyDown("l")) {
			position.z = 5f;
		}*/

		/*if(this.transform.position.z == 1f) {
			anim.SetInteger("Plane", 0);
		} else if (this.transform.position.z == -2f) {
			anim.SetInteger("Plane", 1);
		} else if (this.transform.position.z == -5f) {
			anim.SetInteger("Plane", 2);
		}*/

		// background
		if(actioncounter == 0) {
			anim.SetInteger("Plane", 0);
			bx.enabled = false;
			position.z = 1f;
		// main level - hit player here
		} else if(actioncounter == frontgroundtime) {
			anim.SetInteger("Plane", 1);
			bx.enabled = true;
			//position.x = this.transform.position.x + 1.5f;
			position.z = -2f;
		// foreground
		}/* else if(actioncounter == frontalltime) {
			anim.SetInteger("Plane", 2);
			bx.enabled = false;
			position.x = this.transform.position.x + 1.5f;
			position.y = this.transform.position.y - 4.25f;

			position.z = -5f;
			//position = new Vector3(this.transform.position.x + 1.5f, this.transform.position.y - 4.25f, -5f);	
		// reset anim
		} */else if(actioncounter >= actionendtime) {
			anim.SetInteger("Plane", 0);
			bx.enabled = false;
			//position.x = this.transform.position.x - 1.5f;
			//position.y = this.transform.position.y + 4.25f;
			position.z = 1f;
			//position = new Vector3(this.transform.position.x - 1.5f, this.transform.position.y + 4.25f, 1f);
			actioncounter = 0;
		}
	}
}
