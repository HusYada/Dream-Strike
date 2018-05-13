// Baguette Script for Dream Strike

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baguette : MonoBehaviour {

	// The starting y position of the enemy
	private float startposy;

	// The speed the enemy will move at, edit it in the Inspector
	public float speed;

	// The height the enemy will travel before turning around, edit it in the Inspector
 	public float height;

 	// Checks if the baguette is going up or not
 	private bool goingup = true;

 	// Animator for the baguette
 	private Animator anim;

	void Start () {
		// Setting the starting y position to it's current y position
    	startposy = transform.position.y;

    	// Getting component
    	anim = this.GetComponent<Animator>();
	}

	void Update () {
		// If the enemy is going up and travels the height, it will turn around
		// If the enemy is going down and travels past it's intial starting y position, it will turn around
    	if ((goingup == true && transform.position.y > startposy + height) || (goingup == false && transform.position.y < startposy)) {

        	//speed *= -1;
        	goingup = !goingup;
        }

        // Speed depending on what way the baguette is going
        if(goingup == true) {
        	transform.Translate (new Vector3 (0.0f, 5.0f, 0.0f) * speed * Time.deltaTime);
        	anim.SetBool("Goingup", true);
    	}
    	if(goingup == false) {
    		transform.Translate (new Vector3 (0.0f, -3.0f, 0.0f) * speed * Time.deltaTime);
    		anim.SetBool("Goingup", false);
    	}
	}

	// Baguette kills enemies
	void OnTriggerEnter2D(Collider2D col) {
		/*if(col.gameObject.tag == "Plyr") {
			col.gameObject.GetComponent<player>().currenthp -= 1;
      		col.gameObject.GetComponent<player>().invincible = true;
		}*/

		if(col.gameObject.tag == "Enm") {
			col.gameObject.GetComponent<enemy>().health -= 100;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.gameObject.tag == "Enm") {
			col.gameObject.GetComponent<enemy>().health -= 100;
		}
	}
}
