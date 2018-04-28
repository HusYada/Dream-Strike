// Ability Screen Script for Dream Strike

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
    public bool hasattack = true;
    public bool hashealthbar = true;
    public bool haswallet = true;
    public bool haspause = true;
	public bool hascyberslam = true;
    public bool haspeashoot = true;
    public bool hasmayonaise = true;
	public bool hasbigjump = false;

    //Checks if the player has the ability equipped
    public bool eqpdwalkleft = true;
    public bool eqpdwalkright = true;
    public bool eqpdjump = true;
    public bool eqpdattack = true;
    public bool eqpdhealthbar = true;
    public bool eqpdwallet = true;
	//public bool eqpddance = false;
	public bool eqpdmap = true;
	public bool eqpdpause = true;
    public bool eqpdbigjump = false;
    public bool eqpdcyberslam = false;
    public bool eqpdpeashoot = false;
    public bool eqpdmayonaise = false;
    public bool eqpdgravity = false;

    // Textures for ability screen
	public Texture2D abtscreencursor_texture;
	public Texture2D placeholder_texture;
	public Texture2D bigjump;
	public Texture2D bigjumpselected;
	public Texture2D runmore;
	public Texture2D runmoreselected;
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
	public Texture2D equip;

	// Font style for the ability screen
	public GUIStyle abtscreen_font; 
	// End of Public Variables

	// Private Variables
	private float abtscreen_posx = Screen.width/6.5f;
	private float abtscreen_posy = Screen.height/6f;

	// Inventory screen co-ordinates for cursor
	private int abtscreen_minx = 0;
	private int abtscreen_maxx = 3;
	private int abtscreen_miny = 0;
	private int abtscreen_maxy = 9;

	// A counter for the ability screen cursor and the scroll rect
	private bool abtscreen_iscooldown;
	private int abtscreen_cooldowncounter; 
    private int abtscreen_cooldowntime = 20; 

    // Checks if the player has the ability
	//private bool hasdance = false;
	private bool hasmap = true;
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

	// If the game is paused, the ability screen will check which abilities are equipped depending on if the player has it and the ability cursor is hovering over it, adding or subtracting AP is it's equipped or not
	if(menuu.paused == true) {

		if(haswalkleft == true && abtscreen_indexx == 0 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkleft == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkleft = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkleft == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdwalkleft = false;
				abtscreen_iscooldown = true;
			}
		}

		if(haswalkright == true && abtscreen_indexx == 1 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkright == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdwalkright = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwalkright == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdwalkright = false;
				abtscreen_iscooldown = true;
			}
		}

		if(hasjump == true && abtscreen_indexx == 2 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdjump == false && abtscreen_iscooldown == false && plyr.apcurrent + 3 <= plyr.apmax) {
				plyr.apcurrent += 3;
				eqpdjump = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdjump == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 3;
				eqpdjump = false;
				abtscreen_iscooldown = true;
			}
		}

		if(hasattack == true && abtscreen_indexx == 3 && abtscreen_indexy == 0) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdattack == false && abtscreen_iscooldown == false && plyr.apcurrent + 2 <= plyr.apmax) {
				plyr.apcurrent += 2;
				eqpdattack = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdattack == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 2;
				eqpdattack = false;
				abtscreen_iscooldown = true;
			}
		}

		if(hashealthbar == true && abtscreen_indexx == 0 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdhealthbar == false && abtscreen_iscooldown == false && plyr.apcurrent + 5 <= plyr.apmax) {
				plyr.apcurrent += 5;
				eqpdhealthbar = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdhealthbar == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 5;
				eqpdhealthbar = false;
				abtscreen_iscooldown = true;
			}
		}

		if(haswallet == true && abtscreen_indexx == 1 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwallet == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdwallet = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdwallet == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdwallet = false;
				abtscreen_iscooldown = true;
			}
		}

		if(haspause == true && abtscreen_indexx == 2 && abtscreen_indexy == 1) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpause == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpause = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpause == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdpause = false;
				abtscreen_iscooldown = true;
			}
		}

		if(hasmap == true && abtscreen_indexx == 3 && abtscreen_indexy == 1) {

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
		}

		if(hascyberslam == true && abtscreen_indexx == 0 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdcyberslam == false && abtscreen_iscooldown == false && plyr.apcurrent + 2 <= plyr.apmax) {
				plyr.apcurrent += 2;
				eqpdcyberslam = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdcyberslam == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 2;
				eqpdcyberslam = false;
				abtscreen_iscooldown = true;
			}
		}

		if(haspeashoot == true && abtscreen_indexx == 1 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpeashoot == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdpeashoot = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdpeashoot == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdpeashoot = false;
				abtscreen_iscooldown = true;
			}
		}

		if(hasmayonaise == true && abtscreen_indexx == 3 && abtscreen_indexy == 2) {

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmayonaise == false && abtscreen_iscooldown == false && plyr.apcurrent + 1 <= plyr.apmax) {
				plyr.apcurrent += 1;
				eqpdmayonaise = true;
				abtscreen_iscooldown = true;
			}

			if((Input.GetKeyDown("z") || xboxp1_a == true) && eqpdmayonaise == true && abtscreen_iscooldown == false) {
				plyr.apcurrent -= 1;
				eqpdmayonaise = false;
				abtscreen_iscooldown = true;
			}
		}
	  }				
	}

	// GUI Elements are ordered with the lowest in front and vice versa
	void OnGUI () {

		// A variable set to the control stick's horizontal axis
		float hmove = Input.GetAxis("Horizontal");
		// A variable set to the control stick's vertical axis
		float vmove = Input.GetAxis("Vertical");

		// If the menu is on the ability screen and the game is paused, the cursor on the ability screen can be moved
		if(menuu.abtscreen == true && menuu.paused == true){

			// Movement for the cursor on ability list
			if ((Input.GetKey("left") || hmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexx > abtscreen_minx){
				abtscreen_posx -= Screen.width/5.7f;
				abtscreen_indexx --;
				abtscreen_iscooldown = true;
			} else if ((Input.GetKey("right") || hmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexx < abtscreen_maxx){
				abtscreen_posx += Screen.width/5.7f;
				abtscreen_indexx ++;
				abtscreen_iscooldown = true;
			}

			if ((Input.GetKey("up") || vmove > 0.1f) && abtscreen_iscooldown == false && abtscreen_indexy > abtscreen_miny){
				abtscreen_posy -= Screen.height/15f;
				abtscreen_indexy --;
				abtscreen_iscooldown = true;
				
			} else if ((Input.GetKey("down") || vmove < -0.1f) && abtscreen_iscooldown == false && abtscreen_indexy < abtscreen_maxy){
				abtscreen_posy += Screen.height/15f;
				abtscreen_indexy ++;
				abtscreen_iscooldown = true;
			}

			// The cursor graphic
        	GUI.DrawTexture(new Rect(abtscreen_posx, abtscreen_posy, Screen.width/6f, Screen.height/15f), abtscreencursor_texture, ScaleMode.StretchToFill);

        	// Number of ability points used and how many left
        	GUI.Label(new Rect(Screen.width/1.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), plyr.apcurrent.ToString() + " / " + plyr.apmax.ToString(), abtscreen_font);

        	// The ability list, if the player has the ability is will appear on the ability screen along with a description and cost
        	if(haswalkleft == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f, Screen.width/6f, Screen.height/16f), walkleft, ScaleMode.StretchToFill);
        		if(eqpdwalkleft == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.28f, Screen.height/6.2f, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Hold the left stick left to walk left", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(haswalkright == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f, Screen.width/6f, Screen.height/16f), walkright, ScaleMode.StretchToFill);
        		if(eqpdwalkright == true) {
						GUI.DrawTexture(new Rect(Screen.width/2.08f, Screen.height/6.2f, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Hold the left stick right to walk right", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasjump == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.98f, Screen.height/6f, Screen.width/6f, Screen.height/16f), jump, ScaleMode.StretchToFill);
        		if(eqpdjump == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.523f, Screen.height/6.2f, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 2 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press the A button to jump", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "3", abtscreen_font);
				}
        	}

        	if(hasattack == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f, Screen.width/6f, Screen.height/16f), attack, ScaleMode.StretchToFill);
        		if(eqpdattack == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.203f, Screen.height/6.2f, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 0) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press the B button to attack with your sword", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Can cut stuff, stops your ground movement briefly", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "2", abtscreen_font);
				}
        	}

        	if(hashealthbar == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), healthbar, ScaleMode.StretchToFill);
        		if(eqpdhealthbar == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.28f, Screen.height/6.2f + Screen.height/15 * 1, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "This is your health bar", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "It lets you take a number of hits", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "5", abtscreen_font);
				}
        	}

        	if(haswallet == true) {
        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), wallet, ScaleMode.StretchToFill);
        		if(eqpdwallet == true) {
						GUI.DrawTexture(new Rect(Screen.width/2.08f, Screen.height/6.2f + Screen.height/15 * 1, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "This is your wallet", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "It lets you earn coins", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(haspause == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.98f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), pause, ScaleMode.StretchToFill);
        		if(eqpdpause == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.523f, Screen.height/6.2f + Screen.height/15 * 1, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 2 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press the Start button to pause the game", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Allows you to take a toilet break!", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hasmap == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f + Screen.height/15 * 1, Screen.width/6f, Screen.height/16f), map, ScaleMode.StretchToFill);
        		if(eqpdmap == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.203f, Screen.height/6.2f + Screen.height/15 * 1, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 1) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "The map is going to be removed :(", abtscreen_font);
					//GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Hello World", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "0", abtscreen_font);
				}
        	}

        	if(hascyberslam == true) {
        		GUI.DrawTexture(new Rect(Screen.width/6.5f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), cyberslam, ScaleMode.StretchToFill);
        		if(eqpdcyberslam == true) {
						GUI.DrawTexture(new Rect(Screen.width/3.28f, Screen.height/6.2f + Screen.height/15 * 2, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 0 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press the X button to do a forward dash attack", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Can be used in mid-air and traverse gaps", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "2", abtscreen_font);
				}
			}   

        	if(haspeashoot == true) {

        		GUI.DrawTexture(new Rect(Screen.width/3.04f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), peashoot, ScaleMode.StretchToFill);
        		if(eqpdpeashoot == true) {
						GUI.DrawTexture(new Rect(Screen.width/2.08f, Screen.height/6.2f + Screen.height/15 * 2, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 1 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Press the Y button to shoot a pea", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Can cut stuff, stops your movement briefly", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	if(hasmayonaise == true) {
        		GUI.DrawTexture(new Rect(Screen.width/1.47f, Screen.height/6f + Screen.height/15 * 2, Screen.width/6f, Screen.height/16f), mayonaise, ScaleMode.StretchToFill);
        		if(eqpdmayonaise == true) {
						GUI.DrawTexture(new Rect(Screen.width/1.203f, Screen.height/6.2f + Screen.height/15 * 2, Screen.width/60f, Screen.height/30f), equip, ScaleMode.StretchToFill);
				}

        		if(abtscreen_indexx == 3 && abtscreen_indexy == 2) {
        			GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.2f, Screen.width/2f, Screen.height/8f), "Hold the left stick up & press the B button", abtscreen_font);
					GUI.Label(new Rect(Screen.width/6.3f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "Can make 1 block at a time, can be used in mid-air", abtscreen_font);
					GUI.Label(new Rect(Screen.width/1.65f, Screen.height/1.15f, Screen.width/2f, Screen.height/8f), "1", abtscreen_font);
				}
        	}

        	// A variable for the fontsize that changes depending on the screen size
        	int fontscale = Convert.ToInt32(40.0f * Screen.width/1920.0f);

        	// Setting the font size to the new interger
        	abtscreen_font.fontSize = fontscale;

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
