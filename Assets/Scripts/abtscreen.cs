// Ability Screen Script for Dream Strike by Huseyin Geyik

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abtscreen : MonoBehaviour {

	// Public Script Variables	
	public menu menuu;
	public player plyr;
	public playermovement move;
	public playerjump jumpp;
	public playerattack attackk;
	public playerslam slam;
	public playershoot shoot;
	public playerblock block;
	public player bigjumpornah;
	// End of Public Script Variables	

	// Public Variables
	// Co-ordinates for the inventory screen cursor
	public int abtscreen_indexx = 0;
	public int abtscreen_indexy = 0;

	// Checks if the player has the ability
	public bool haswalkleft = true;
    public bool haswalkright = true;
    public bool hasjump = true;
    public bool hasdoublejump = false;
    public bool hasattack = true;
    public bool hashealthbar = true;
    public bool haswallet = true;
    public bool haspause = true;
	public bool hascyberslam = false;
    public bool haspeashoot = false;
    public bool hastriplepeashot = false;
    public bool hasmayonaise = false;
    public bool hassoap = false;
    public bool hasgoodgrip = false;
    public bool hasrollerskates = false;
	public bool hasbigjump = false;

    //Checks if the player has the ability equipped
    public bool eqpdwalkleft = true;
    public bool eqpdwalkright = true;
    public bool eqpdjump = true;
    public bool eqpddoublejump = false;
    public bool eqpdattack = true;
    public bool eqpdhealthbar = true;
    public bool eqpdwallet = true;
	//public bool eqpddance = false;
	public bool eqpdmap = true;
	public bool eqpdpause = true;
    public bool eqpdbigjump = false;
    public bool eqpdcyberslam = false;
    public bool eqpdpeashoot = false;
    public bool eqpdtriplepeashoot = false;
    public bool eqpdmayonaise = false;
    public bool eqpdgravity = false;
    public bool eqpdsoap = false;
    public bool eqpdgoodgrip = false;
    public bool eqpdrollerskates = false;

    // Textures for ability screen
	public Texture2D abtscreencursor_texture;
	public Texture2D placeholder_texture;
	public Texture2D bigjump;
	public Texture2D bigjumpselected;
	public Texture2D runmore;
	public Texture2D runmoreselected;
	public Texture2D header;
	public Texture2D dpbar;
	public Texture2D lefttab;
	public Texture2D righttab;
	public Texture2D textbox;
	public Texture2D walkleft;
	public Texture2D walkright;
	public Texture2D jump;
	public Texture2D attack;
	public Texture2D healthbar;
	public Texture2D wallet;
	public Texture2D pause;
	public Texture2D map;
	public Texture2D cyberslam;
	public Texture2D peashoot;
	public Texture2D mayonaise;
	public Texture2D soap;
	public Texture2D goodgrip;
	public Texture2D rollerskates;
	public Texture2D notwalkleft;
	public Texture2D notwalkright;
	public Texture2D notjump;
	public Texture2D notattack;
	public Texture2D nothealthbar;
	public Texture2D notwallet;
	public Texture2D notpause;
	//public Texture2D map;
	public Texture2D notcyberslam;
	public Texture2D notpeashoot;
	public Texture2D notmayonaise;
	public Texture2D notsoap;
	public Texture2D notgoodgrip;
	public Texture2D notrollerskates;
	public Texture2D blankicon;
	public Texture2D equip;

	// Font style for the ability screen
	public GUIStyle abtscreen_font; 

	// Sound Effects for the ability screen
	public AudioClip menuyesSFX;
	public AudioClip menunoSFX;
	public AudioClip menucursorSFX;
	// End of Public Variables

	// Private Variables
	private float abtscreen_posx = Screen.width/3.4f;
	private float abtscreen_posy = Screen.height/1.82f;

	// Inventory screen co-ordinates for cursor
	private int abtscreen_minx = 0;
	private int abtscreen_maxx = 9;
	private int abtscreen_miny = 0;
	private int abtscreen_maxy = 3;

	// A counter for the ability screen cursor and the scroll rect
	private bool abtscreen_iscooldown;
	private int abtscreen_cooldowncounter; 
    private int abtscreen_cooldowntime = 20; 

    // Checks if the player has the ability
	//private bool hasdance = false;
	//private bool hasmap = true;
	// End of Private Variables

	
	void Start () {

		// Sets the ability screen's counter
		abtscreen_iscooldown = false;
		//abtscreenscroll_iscooldown = false;
        abtscreen_cooldowncounter = 0;
	}

	void Update () {

		// A variable set to the Xbox 360/Xbox One controller's A button to see if it's been pressed
		bool xboxp1_a = Input.GetButtonDown("XBOXP1_A");
		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		//bool xboxp1_b = Input.GetButtonDown("XBOXP1_B");

	// If the game is paused, the ability screen will check which abilities are equipped depending on if the player has it and the ability cursor is hovering over it, adding or subtracting AP if it's equipped or not
	if(menuu.paused == true) {

		if(haswalkleft == true && abtscreen_indexx == 0 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkleft == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkleft = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkleft == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdwalkleft = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(haswalkright == true && abtscreen_indexx == 1 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkright == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkright = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkright == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdwalkright = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hasjump == true && abtscreen_indexx == 2 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdjump == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdjump = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdjump == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdjump = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);

			}
		}

		if(hasattack == true && abtscreen_indexx == 3 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdattack == false && abtscreen_iscooldown == false && plyr.apcurrent + 2 <= plyr.apmax) {
				plyr.apcurrent += 2;
				eqpdattack = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdattack == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 2;
				eqpdattack = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hashealthbar == true && abtscreen_indexx == 4 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdhealthbar == false && abtscreen_iscooldown == false && plyr.apcurrent + 5 <= plyr.apmax) {
				plyr.apcurrent += 5;
				eqpdhealthbar = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdhealthbar == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 5;
				eqpdhealthbar = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(haswallet == true && abtscreen_indexx == 5 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwallet == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdwallet = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwallet == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdwallet = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(haspause == true && abtscreen_indexx == 6 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpause == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpause = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpause == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdpause = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		/*if(hasmap == true && abtscreen_indexx == 7 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmap == false && abtscreen_iscooldown == false && plyr.apcurrent + 0 <= plyr.apmax) {
				plyr.apcurrent += 0;
				eqpdmap = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmap == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 0;
				eqpdmap = false;
				abtscreen_iscooldown = true;
			}
		}*/

		if(hascyberslam == true && abtscreen_indexx == 7 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdcyberslam == false && abtscreen_iscooldown == false && plyr.apcurrent + 2 <= plyr.apmax) {
				plyr.apcurrent += 2;
				eqpdcyberslam = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdcyberslam == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 2;
				eqpdcyberslam = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(haspeashoot == true && abtscreen_indexx == 8 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpeashoot == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpeashoot = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpeashoot == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdpeashoot = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hasmayonaise == true && abtscreen_indexx == 9 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmayonaise == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdmayonaise = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmayonaise == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdmayonaise = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hassoap == true && abtscreen_indexx == 6 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdsoap == false && abtscreen_iscooldown == false && plyr.apcurrent + 8 <= plyr.apmax) {
				plyr.apcurrent += 8;
				eqpdsoap = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdsoap == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 8;
				eqpdsoap = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hasgoodgrip == true && abtscreen_indexx == 0 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdgoodgrip == false && abtscreen_iscooldown == false && plyr.apcurrent + 2 <= plyr.apmax) {
				plyr.apcurrent += 2;
				eqpdgoodgrip = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdgoodgrip == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 2;
				eqpdgoodgrip = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}

		if(hasrollerskates == true && abtscreen_indexx == 7 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdrollerskates == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdrollerskates = true;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menuyesSFX, 0.15f);
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdrollerskates == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdrollerskates = false;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menunoSFX, 0.15f);
			}
		}
	  }				
	}

	// REMINDER - GUI Elements are ordered with the lowest in front and vice versa
	void OnGUI () {

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");
		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");

		// If the menu is on the ability screen and the game is paused, the cursor on the ability screen can be moved
		if(menuu.abtscreen == true && menuu.paused == true){

			// Movement for the cursor on ability list
			if ((Input.GetKey("left") || hmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexx > abtscreen_minx){
				abtscreen_posx -= Screen.width/27f;
				abtscreen_indexx --;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menucursorSFX, 0.45f);

			} else if ((Input.GetKey("right") || hmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexx < abtscreen_maxx){
				abtscreen_posx += Screen.width/27f;
				abtscreen_indexx ++;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menucursorSFX, 0.45f);
			}

			if ((Input.GetKey("up") || vmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexy > abtscreen_miny){
				abtscreen_posy -= Screen.height/16f;
				abtscreen_indexy --;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menucursorSFX, 0.45f);
				
			} else if ((Input.GetKey("down") || vmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexy < abtscreen_maxy){
				abtscreen_posy += Screen.height/16f;
				abtscreen_indexy ++;
				abtscreen_iscooldown = true;
				GetComponent<AudioSource>().PlayOneShot(menucursorSFX, 0.45f);
			}

			if(menuu.showicons == true) {

			// The cursor graphic
        	GUI.DrawTexture(new Rect(abtscreen_posx, abtscreen_posy, Screen.width/14f, Screen.height/14f), abtscreencursor_texture, ScaleMode.ScaleToFit);
        	//GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), walkleft, ScaleMode.ScaleToFit);

        	// Row 1 Blank Icons
        	GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);

        	// Row 2 Blank Icons
        	GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);

        	// Row 3 Blank Icons
        	GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);

        	// Row 4 Blank Icons
        	GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f + Screen.height/16f * 3, Screen.width/11f, Screen.height/11f), blankicon, ScaleMode.ScaleToFit);

        	// Other Textures
        	GUI.DrawTexture(new Rect(Screen.width/3.16f, Screen.height/2.42f, Screen.width/10f, Screen.height/12f), lefttab, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/2.4f, Screen.height/2.6f, Screen.width/6f, Screen.height/8f), header, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/1.73f, Screen.height/2.42f, Screen.width/10f, Screen.height/12f), righttab, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3.1f, Screen.height/2.35f, Screen.width/3.5f, Screen.height/6f), dpbar, ScaleMode.ScaleToFit);
        	GUI.DrawTexture(new Rect(Screen.width/3f, Screen.height/1.375f, Screen.width/3f, Screen.height/3f), textbox, ScaleMode.ScaleToFit);

        	// Number of ability points used and how many left
        	//GUI.Label(new Rect(Screen.width/1.635f, Screen.height/2f, Screen.width/2f, Screen.height/8f), plyr.apcurrent.ToString() + " / " + plyr.apmax.ToString(), abtscreen_font);
        	GUI.Label(new Rect(Screen.width/1.615f, Screen.height/1.95f, Screen.width/20f, Screen.height/80f), plyr.apcurrent.ToString() + " / " + plyr.apmax.ToString(), abtscreen_font);

        	// The ability list, if the player has the ability it will appear on the ability screen along with a description and cost
        	if(haswalkleft == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notwalkleft, ScaleMode.ScaleToFit);
        		if(eqpdwalkleft == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), walkleft, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Walk Left", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Hold the left stick left to walk left", abtscreen_font);

        			//GUI.DrawTexture(new Rect(Screen.width/3f, Screen.height/1.375f, Screen.width/3f, Screen.height/3f), textbox, ScaleMode.ScaleToFit);

					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(haswalkright == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notwalkright, ScaleMode.ScaleToFit);
        		if(eqpdwalkright == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 1, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), walkright, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Walk Right", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Hold the left stick right to walk right", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasjump == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notjump, ScaleMode.ScaleToFit);
        		if(eqpdjump == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 2, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), jump, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 2 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Jump", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Press the A button to jump", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasattack == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notattack, ScaleMode.ScaleToFit);
        		if(eqpdattack == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 3, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), attack, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Attack", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Press the B button to attack with your sword", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "Your primary attack", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "2", abtscreen_font);
				}
        	}

        	if(hashealthbar == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), nothealthbar, ScaleMode.ScaleToFit);
        		if(eqpdhealthbar == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 4, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), healthbar, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 4 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Health Bar", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "This is your health bar", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "It lets you take a number of hits", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "5", abtscreen_font);
				}
        	}

        	if(haswallet == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notwallet, ScaleMode.ScaleToFit);
        		if(eqpdwallet == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 5, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), wallet, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 5 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Wallet", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "This is your wallet", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "It lets you earn coins", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(haspause == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notpause, ScaleMode.ScaleToFit);
        		if(eqpdpause == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), pause, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 6 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Pause", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Press the Start button to pause the game", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "Allows you to take a toilet break!", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	/*if(hasmap == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), map, ScaleMode.StretchToFill);
        		if(eqpdmap == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.203f, Screen.height/6.2f + Screen.height/15 * 1, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "The map is going to be removed :(", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "0", abtscreen_font);
				}
        	}*/

        	if(hascyberslam == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notcyberslam, ScaleMode.ScaleToFit);
        		if(eqpdcyberslam == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), cyberslam, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 7 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Cyber Slam", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Press the X button to do a forward dash", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "Best used in mid-air", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "2", abtscreen_font);
				}
			}   

        	if(haspeashoot == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notpeashoot, ScaleMode.ScaleToFit);
        		if(eqpdpeashoot == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 8, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), peashoot, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 8 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Pea Shoot", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Press the Y button to shoot a pea", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "Sharper than they look", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hasmayonaise == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), notmayonaise, ScaleMode.ScaleToFit);
        		if(eqpdmayonaise == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 9, Screen.height/1.865f, Screen.width/11f, Screen.height/11f), mayonaise, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 9 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Mayonaise", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Hold the left stick down & press the A button", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "1 block at a time", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hassoap == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), notsoap, ScaleMode.ScaleToFit);
        		if(eqpdsoap == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 6, Screen.height/1.865f + Screen.height/16f * 1, Screen.width/11f, Screen.height/11f), soap, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 6 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Soap", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Makes you slippery but a good climber", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "May affect other abilities", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "8", abtscreen_font);
				}
        	}

        	if(hasgoodgrip == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), notgoodgrip, ScaleMode.ScaleToFit);
        		if(eqpdgoodgrip == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), goodgrip, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Good Grip", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "Gives you a sturdy grip!", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "May affect other abilities", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "2", abtscreen_font);
				}
        	}

        	if(hasrollerskates == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), notrollerskates, ScaleMode.ScaleToFit);
        		if(eqpdrollerskates == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.5f + Screen.width/27f * 7, Screen.height/1.865f + Screen.height/16f * 2, Screen.width/11f, Screen.height/11f), rollerskates, ScaleMode.ScaleToFit);
				}

        		if(abtscreen_indexx == 7 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/2.65f, Screen.height/1.24f, Screen.width/2f, Screen.height/8f), "Rollerskates", abtscreen_font);
        			GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.18f, Screen.width/2f, Screen.height/8f), "~ Can't stop moving ~", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.55f, Screen.height/1.13f, Screen.width/2f, Screen.height/8f), "~ Keep on grooving  ~", abtscreen_font);
					GUI.Label(new Rect(Screen.width/2.05f, Screen.height/1.06f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	}

        	// A variable for the fontsize that changes depending on the screen size
        	//int fontsizee = Convert.ToInt32(40.0f * Screen.width/1920.0f);
        	int fontsizee = Convert.ToInt32(25f * Screen.width/1920.0f);

        	// Setting the font size to the new interger
        	abtscreen_font.fontSize = fontsizee;

		}

		// If the ability screen cursor moved, a counter will start
		if (abtscreen_iscooldown == true) {
           	abtscreen_cooldowncounter++;
       	}

       	// If the ability screen counter is equal to its time, the ability screen cursor can be move again
	  	if (abtscreen_cooldowncounter >= abtscreen_cooldowntime) {
            abtscreen_iscooldown = false;
           	abtscreen_cooldowncounter = 0;
        }
	}
}
