// Checkpoint Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	public player plyr;						// A script variable to access variables from the player script
	public int whichcheck;					// Which checkpoint is this?

	// The checkpoints
	public GameObject checkpoint0;
	public GameObject checkpoint1;
	public GameObject checkpoint2;
	public GameObject checkpoint3;
	public GameObject checkpoint4;
	public GameObject checkpoint5;
	public GameObject checkpoint6;
	//public GameObject checkpoint7;
	//public GameObject checkpoint8;
	//public GameObject checkpoint9;

	// The checkpoint the player is on
	public Vector3 check00r;
	public Vector3 check01r;
	public Vector3 check02r;
	public Vector3 check03r;
	public Vector3 check04r;
	public Vector3 check05r;
	public Vector3 check06r;
	//public Vector3 check07r;
	//public Vector3 check08r;
	//public Vector3 check09r;

	// The sprite renderer for each checkpoint
	private SpriteRenderer sr0;
	private SpriteRenderer sr1;
	private SpriteRenderer sr2;
	private SpriteRenderer sr3;
	private SpriteRenderer sr4;
	private SpriteRenderer sr5;
	private SpriteRenderer sr6;
	//private SpriteRenderer sr7;
	//private SpriteRenderer sr8;
	//private SpriteRenderer sr9;

	// Sprites for checked and unchecked sprites
	public Sprite ischecked;
	public Sprite notchecked;

	// Spriterenderers assigned to their respective checkpoint
	void Start () {
		sr0 = checkpoint1.GetComponent<SpriteRenderer>();
		sr1 = checkpoint1.GetComponent<SpriteRenderer>();
		sr2 = checkpoint2.GetComponent<SpriteRenderer>();
		sr3 = checkpoint3.GetComponent<SpriteRenderer>();
		sr4 = checkpoint4.GetComponent<SpriteRenderer>();
		sr5 = checkpoint5.GetComponent<SpriteRenderer>();
		sr6 = checkpoint6.GetComponent<SpriteRenderer>();
		//sr7 = checkpoint7.GetComponent<SpriteRenderer>();
		//sr8 = checkpoint8.GetComponent<SpriteRenderer>();
		//sr9 = checkpoint9.GetComponent<SpriteRenderer>();
	}
	
	void Update () {

		// Change sprite of checkpoints depending on which on the player is on

		if(plyr.check00 == true) {
			sr0.sprite = ischecked;
		} else if(plyr.check00 == false) {
			sr0.sprite = notchecked;
		}
		if(plyr.check01 == true) {
			sr1.sprite = ischecked;
		} else if(plyr.check01 == false) {
			sr1.sprite = notchecked;
		}
		if(plyr.check02 == true) {
			sr2.sprite = ischecked;
		} else if(plyr.check02 == false) {
			sr2.sprite = notchecked;
		}
		if(plyr.check03 == true) {
			sr3.sprite = ischecked;
		} else if(plyr.check03 == false) {
			sr3.sprite = notchecked;
		}
		if(plyr.check04 == true) {
			sr4.sprite = ischecked;
		} else if(plyr.check04 == false) {
			sr4.sprite = notchecked;
		}
		if(plyr.check05 == true) {
			sr5.sprite = ischecked;
		} else if(plyr.check05 == false) {
			sr5.sprite = notchecked;
		}
		if(plyr.check06 == true) {
			sr6.sprite = ischecked;
		} else if(plyr.check06 == false) {
			sr6.sprite = notchecked;
		}
		/*if(plyr.check07 == true) {
			sr7.sprite = ischecked;
		} else if(plyr.check07 == false) {
			sr7.sprite = notchecked;
		}
		if(plyr.check08 == true) {
			sr8.sprite = ischecked;
		} else if(plyr.check08 == false) {
			sr8.sprite = notchecked;
		}
		if(plyr.check09 == true) {
			sr9.sprite = ischecked;
		} else if(plyr.check09 == false) {
			sr9.sprite = notchecked;
		}*/

		// If the player runs out of HP, the player will go the checkpoint they were last at
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
			/*if(plyr.check07 == true) {
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
			}*/
		}	
	}

	void OnTriggerEnter2D(Collider2D col) {

		// The checkpoint the player passes last is the one they will respawn at when they run out of HP

		if(col.gameObject.tag == "Plyr" && whichcheck == 0) {
			plyr.check00 = true;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 1) {
			plyr.check00 = false;
			plyr.check01 = true;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 2) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = true;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 3) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = true;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 4) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = true;
			plyr.check05 = false;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 5) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = true;
			plyr.check06 = false;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		if(col.gameObject.tag == "Plyr" && whichcheck == 6) {
			plyr.check00 = false;
			plyr.check01 = false;
			plyr.check02 = false;
			plyr.check03 = false;
			plyr.check04 = false;
			plyr.check05 = false;
			plyr.check06 = true;
			/*plyr.check07 = false;
			plyr.check08 = false;
			plyr.check09 = false;*/
		}

		/*if(col.gameObject.tag == "Plyr" && whichcheck == 7) {
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
		}*/
	}
}
