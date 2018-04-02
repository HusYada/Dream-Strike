using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	public player plyr;						// A script variable to access variables from the player script
	public int whichcheck;
	public Vector3 check00r;
	public Vector3 check01r;
	public Vector3 check02r;
	public Vector3 check03r;
	public Vector3 check04r;
	public Vector3 check05r;
	public Vector3 check06r;
	public Vector3 check07r;
	public Vector3 check08r;
	public Vector3 check09r;
	
	// Update is called once per frame
	void Update () {

		if(plyr.currenthp <= 0) {
			if(plyr.check00 == true) {
				plyr.transform.position = check00r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check01 == true) {
				plyr.transform.position = check01r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check02 == true) {
				plyr.transform.position = check02r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check03 == true) {
				plyr.transform.position = check03r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check04 == true) {
				plyr.transform.position = check04r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check05 == true) {
				plyr.transform.position = check05r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check06 == true) {
				plyr.transform.position = check06r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check07 == true) {
				plyr.transform.position = check07r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check08 == true) {
				plyr.transform.position = check08r;
				plyr.currenthp = plyr.hpmax;
			}
			if(plyr.check09 == true) {
				plyr.transform.position = check09r;
				plyr.currenthp = plyr.hpmax;
			}
		}	
	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr" && whichcheck == 0) {
			plyr.check00 = true;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 1) {
			plyr.check00 = false;
			plyr.check01 = true;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 2) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = true;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 3) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = true;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 4) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = true;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 5) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = true;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 6) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = true;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 7) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = true;
			plyr.check08 = false;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 8) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = true;
			plyr.check09 = false;
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 9) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = true;
		}
	}
}
