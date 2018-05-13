// Get Ability Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getability : MonoBehaviour {

	public player plyr;                 // A script variable to access variables from the player script
	public menu menuu;                  // A script variable to access variables from the menu script
	public abtscreen abt;				// A script variable to access variables from the abtscreen script
	public bool gotone = false;			// Checks if the player got an ability
	public Texture2D gotability;		// Texture for the textbox that appears when getting an ability
	private bool canclose = false;		// Checks if you can close the window
	private bool closed = false;		// Checks if a window is closed
	private int gotonecurrentframe = 0;	// The number of the frames that's passed for the gotone animation
	private int gotonetime = 30;		// The time it takes to finish the gotone

	// Checks which ability is be obtained
	public bool getap = false;
	public bool getcyberslam = false;
	public bool getpeashoot = false;
    public bool getmayonaise = false;
    public bool getsoap = false;

    public AudioClip abilitygetSFX;     //Sound clip that plays when the player gains an ability

    void Update() {

    	// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
    	bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");
        // A variable set to the Xbox 360/Xbox One controller's START button to see if it's been pressed
		bool xboxp1_start = Input.GetButtonDown("XBOXP1_START");

        // If the player gets an ability, the game is paused
    	if(gotone == true) {

    		if(gotonetime < 50) {
    			gotonecurrentframe++;
    		}
    		
    		Time.timeScale = 0;
    	}

        // Cooldown for when the player can close the window
    	if(gotonecurrentframe > gotonetime) {
    		canclose = true;
    	}

        // If the window is closed, this object is destroyed and time will flow normally
    	if(closed == true) {
    		Destroy(this.gameObject);
    		Time.timeScale = 1;
    	}

        // Press the Enter key/Z key/Start button/A button is pressed when the window can be closed, the window will close
    	if(canclose == true && (Input.GetKeyDown(KeyCode.Return) ||  Input.GetKeyDown("z") || xboxp1_start == true || xboxp1_a)) {
    		gotone = false;
    		canclose = false;
    		closed = true;
    		menuu.canpause = true;
    	}
    }

    void OnGUI() {

    	// If the player gets an ability, a window will show up with contents depending on what was gained
    	if(gotone == true) {
    		GUI.DrawTexture(new Rect(Screen.width/12, 0, Screen.width/1.35f, Screen.height/1.9f), gotability, ScaleMode.ScaleToFit);
    		if(getap == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "AP increased! You now have up to " + plyr.apmax.ToString() + " ability points", plyr.hud_fontoffsetbr);
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f + Screen.height/15f, Screen.width/2f, Screen.height/16f), "Press A to continue", plyr.hud_fontoffsetbr);
    		}
    		if(getcyberslam == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Cyber Slam!", plyr.hud_fontoffsetbr);
    		}
    		if(getpeashoot == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Pea Shoot!", plyr.hud_fontoffsetbr);
    		}
    		if(getmayonaise == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Mayonaise!", plyr.hud_fontoffsetbr);
    		}
    		if(getsoap == true) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f, Screen.width/2f, Screen.height/16f), "You got Soap!", plyr.hud_fontoffsetbr);
    		}
    		if(getap == false) {
    			GUI.Label(new Rect(Screen.width/5f, Screen.height/5f + Screen.height/15f, Screen.width/2f, Screen.height/16f), "Equip it in the Menu by pressing Start", plyr.hud_fontoffsetbr);
    		}
    	}
    }

	void OnTriggerEnter2D(Collider2D col) {

        // If the player touches this, they will gain something and a window will show up
		if(col.gameObject.tag == "Plyr") {

			menuu.canpause = false;
			GetComponent<AudioSource>().PlayOneShot(abilitygetSFX, 0.5f); //the ability get sound effect is played 

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

			if(getsoap == true) {
				abt.hassoap = true;
				gotone = true;
			}
		}
	}
}
