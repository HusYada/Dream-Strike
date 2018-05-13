// Bonus Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour {

	public player plyr;					// A script variable to access variables from the player script
	public Vector3 doggohere;			// The position this object will go
	public Vector3 gohere;				// The position the player will go
	public bool startorfinishbonus; 	// Checks if the player started or finished the bonus, true = started
	public Camera maincam;				// The main camera in the level
 	public Camera bonuscam;				// The camera in the bonus level
 	private bool entered = false;		// Checks if the player entered a bonus
	private bool teleported = false;	// Checks if the player as been teleported
	private int telcurrentframe = 0;	// The number of the frames that's passed for the teleport animation
	private int teltime = 4;			// The time it takes to finish the teleport
	private int entercurrentframe = 0;	// The number of the frames that's passed for the animation
	private int entertime = 190;		// The time it takes to finish the anim
	private SpriteRenderer sr;          // The sprite renderer for the player
	private Animator anim;				// The animator for the hotdog stand

	void Start () {
		// Getting components
		sr   = plyr.GetComponent<SpriteRenderer>();
		anim = this.GetComponent<Animator>();
	}
	
	void Update () {

		// If the player entered a bonus, they cannot move and the animation will play
		if(entered == true) {
			plyr.locked = true;
			sr.enabled = false;
			anim.SetBool("Entered", true);
			entercurrentframe++;
		}

		// If the player entered a bonus, the hot dog stand will move to a more appropriate position
		if(entered == true && entercurrentframe == 1) {
			this.transform.position = doggohere;
		}

		// When entercurrentframe surpasses it's time, the player will be teleported
		if(entercurrentframe > entertime) {
			entered = false;
			teleported = true;
			plyr.transform.position = gohere;
			sr.enabled = true;
			plyr.locked = false;
			//plyr.invincible = false;
		}

		// The player will be invincible at this point
		if(entercurrentframe == 125) {
			plyr.invincible = true;
		}

		// When teleported, the teleport conuter will start
		if(teleported == true) {
			telcurrentframe++;
		}

		// When the teleport conuter reaches half its time, it will be decided if the player is in a bonus or finished a bonus and the camera will change accordingly
		if(telcurrentframe > teltime/2) {
			if(startorfinishbonus == true) {
				plyr.isbonus = true;
				plyr.bonuscomplete = false;
				 maincam.gameObject.SetActive(false);
				 bonuscam.gameObject.SetActive(true);
			} else if(startorfinishbonus == false) {
				plyr.isbonus = false;
				plyr.bonuscomplete = true;
				maincam.gameObject.SetActive(true);
				bonuscam.gameObject.SetActive(false);
			}
		}

		// When the teleport counter surpasses its time, this object will bedestroyed so the player cannot reenter the bonus stage once beaten
		if(telcurrentframe > teltime) {
			teleported = false;
			telcurrentframe = 0;
			plyr.isbonus = false;
			plyr.bonuscomplete = false;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		// If the player touches this, they have entered a bonus stage
		if(col.gameObject.tag == "Plyr") {
			//plyr.transform.position = gohere;
			//teleported = true;
			entered = true;
		}
	}
}