using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour {

	public player plyr;
	public Vector3 gohere;
	public bool startorfinishbonus; // true = start
	private bool teleported = false;
	private int shootcurrentframe = 0;	// The number of the frames that's passed for the shoot animation
	private int shoottime = 4;			// The time it takes to finish the shoot

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(teleported == true) {
			shootcurrentframe++;
		}

		if(shootcurrentframe > shoottime/2) {
			if(startorfinishbonus == true) {
				plyr.isbonus = true;
				plyr.bonuscomplete = false;
			} else if(startorfinishbonus == false) {
				plyr.isbonus = false;
				plyr.bonuscomplete = true;
			}
		}

		if(shootcurrentframe > shoottime) {
			teleported = false;
			shootcurrentframe = 0;
			plyr.isbonus = false;
			plyr.bonuscomplete = false;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr") {
			plyr.transform.position = gohere;
			teleported = true;
		}
	}
}

//there needs to be a cooldown after u exit, a super quick cooldown that sets bonus complete to false and then destroys, also add equip stuff