using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getability : MonoBehaviour {

	public player plyr;
	public menu menuu;
	public abtscreen abt;				// A script variable to access variables from the abtscreen script
	public bool gotone = false;			// Checks if the player got an ability
	public Texture2D gotability;		// 
	private bool canclose = false;		// Checks if you can close the window
	private bool closed = false;			// Checks if a window is closed
	private int gotonecurrentframe = 0;	// The number of the frames that's passed for the gotone animation
	private int gotonetime = 30;		// The time it takes to finish the gotone

	// Checks which ability can be obtained
	public bool getap = false;
	public bool getcyberslam = false;
	public bool getpeashoot = false;
    public bool getmayonaise = false;
    public bool getgravitycap = false;

    void Update() {

    	// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
    	bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");
		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

    	if(gotone == true) {

    		if(gotonetime < 50) {
    			gotonecurrentframe++;
    		}
    		
    		Time.timeScale = 0;
    	}

    	if(gotonecurrentframe > gotonetime) {
    		canclose = true;
    	}

    	if(closed == true) {
    		Destroy(this.gameObject);
    		Time.timeScale = 1;
    	}

    	if(canclose == true && (Input.GetKeyDown(KeyCode.Return) ||  Input.GetKeyDown("z") || xboxp1_start == true || xboxp1_a)) {
    		gotone = false;
    		canclose = false;
    		closed = true;
    		menuu.canpause = true;
    	}
    }

    void OnGUI() {

    	// If the player gets an ability, a window will show up
    	if(gotone == true) {
    		GUI.DrawTexture(new Rect(Screen.width/5, Screen.height/5f, Screen.width/2f, Screen.height/8f), gotability, ScaleMode.StretchToFill);
    		if(getap == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "AP increased! You now have up to " + plyr.apmax.ToString() + " ability points", abt.abtscreen_font);
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f + Screen.height/15f, Screen.width/2f, Screen.height/16f), "Press A to continue", abt.abtscreen_font);
    		}
    		if(getcyberslam == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Cyber Slam!", abt.abtscreen_font);
    		}
    		if(getpeashoot == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Pea Shoot!", abt.abtscreen_font);
    		}
    		if(getmayonaise == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Mayonaise!", abt.abtscreen_font);
    		}
    		if(getgravitycap == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Gravity Cap! -- not ready yet :(", abt.abtscreen_font);
    		}
    		if(getap == false) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f + Screen.height/15f, Screen.width/2f, Screen.height/16f), "Equip it in the Menu by pressing Start", abt.abtscreen_font);
    		}
    	}
    }

	void OnTriggerEnter2D(Collider2D col) {

		if(col.gameObject.tag == "Plyr") {

			menuu.canpause = false;

			if(getap == true) {
				plyr.apmax = plyr.apmax + 0.5f;
				gotone = true;
			}

			if(getcyberslam == true) {
				abt.hascyberslam = true;
				gotone = true;
			}

			if(getpeashoot == true) {
				abt.haspeashoot = true;
				gotone = true;
			}

			if(getmayonaise == true) {
				abt.hasmayonaise = true;
				gotone = true;
			}

			if(getgravitycap == true) {
				gotone = true;
			}
		}
	}
}
