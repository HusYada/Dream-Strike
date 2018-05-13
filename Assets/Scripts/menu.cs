// Menu Script for Dream Strike by Huseyin Geyik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public abtscreen abt;			// A script variable to access variables from the abtscreen script
	public getability gabt;			// A script variable to access variables from the getability script

	// Public Variables
	public bool paused = false;		// Checks if the game is paused
	public bool canpause = true;	// Checks if the game can be paused
	public bool ivtscreen = true;	// Checks if the game has the inventory screen up
	public bool abtscreen = false;	// Checks if the game has the ability screen up
	public bool mapscreen = false;	// Checks if the game has the map screen up

	// Counter for switching through menu screens so you don't zip past them at the speed of light
	public bool menu_iscooldown;
	public bool menu_iscooldown2;
    public int menu_cooldowntime;
    public int menu_cooldowncounter;
    public int menu_cooldowncounter2;

    // Menu Animation Stuff
    public Sprite abtscreeno;
    public GameObject menuzoom;
    public Sprite menuzoomface;
    public GameObject menuface;
    public Sprite menufacetop;
    public Sprite menufacereset;
    public GameObject menutop;
    public GameObject menubottom;
    public Sprite menutopend;
    public bool showicons = false;
    public bool menuanim = false;

    // Textures for menu screens
	public Texture2D ivtscreen_texture;
	public Texture2D abtscreen_texture;
	public Texture2D mapscreen_texture;

	// Sound Effects for opening and closing the menu
	public AudioClip menustartupSFX;
	public AudioClip menucloseSFX;
	// End of Public Variables

	//private bool pressedb;
	//private bool pressedstart;

	void Start() {

		//menuzoom.GetComponent<Animator>().SetBool("Zooming", false);
		//menuface.GetComponent<Animator>().SetBool("Facing", false);

		// Sets the menu's counter
        menu_iscooldown = false;
        menu_cooldowncounter = 0;
	}

	void FixedUpdate() {
	}

	void OnGUI() {

		// A variable set to the Xbox 360/Xbox One controller's START button to see if it's been pressed
    	bool xboxp1_start = Input.GetButton("XBOXP1_START");

		// A variable set to the Xbox 360/Xbox One controller's B button to see if it's been pressed
		bool xboxp1_b = Input.GetButton("XBOXP1_B");

		// A variable set to the Xbox 360/Xbox One controller's LB button to see if it's been pressed
		bool xboxp1_lb = Input.GetButton("XBOXP1_LB");
		
		// A variable set to the Xbox 360/Xbox One controller's RB button to see if it's been pressed
		bool xboxp1_rb = Input.GetButton("XBOXP1_RB");

		// If the game is paused, it will bring up the menu
		if(paused == true) {

			// The a and d keys/LB and RB buttons will switch the menu screen depending on what the menu screen is
			if(ivtscreen == true){

				GUI.depth = 4;
				//GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), ivtscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					ivtscreen = false;
					abtscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					ivtscreen = false;
					mapscreen = true;
					menu_iscooldown = true;
				}
			} else if (abtscreen == true){
				GUI.depth = 4;
				//GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), abtscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					abtscreen = false;
					mapscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					abtscreen = false;
					ivtscreen = true;
					menu_iscooldown = true;
				}
			} else if(mapscreen == true){
				GUI.depth = 4;
				//GUI.DrawTexture(new Rect(Screen.width/20f, Screen.height/20f, Screen.width/1.1f, Screen.height/1.1f), mapscreen_texture, ScaleMode.ScaleToFit, true);
				if ((Input.GetKey("a") || xboxp1_lb == true) && menu_iscooldown == false){
					mapscreen = false;
					ivtscreen = true;
					menu_iscooldown = true;
				}
				if ((Input.GetKey("d") || xboxp1_rb == true) && menu_iscooldown == false){
					mapscreen = false;
					abtscreen = true;
					menu_iscooldown = true;
				}
			}
		}

		// If the Enter key/Start button is pressed while the game is unpaused, the game will be paused and the menu animation will start
		if((Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true) && canpause == true && paused == false && menu_iscooldown2 == false) {
			paused = true;
			menuanim = true;
			GetComponent<AudioSource>().PlayOneShot(menustartupSFX, 0.5f);
			//menu_iscooldown2 = true;
			if(abt.eqpdpause == true) {
        		Time.timeScale = 0;
        	}
		}

		/*if(abt.eqpdpause == false && canpause == true) {
        		Time.timeScale = 1;
        }*/

        // If the Enter key/Start button is pressed while the game is paused, the game will be unpaused and the menu will close
		if((Input.GetKeyDown(KeyCode.Return) || xboxp1_start == true || Input.GetKeyDown("x") || xboxp1_b == true) && paused == true && showicons == true && menuanim == false && menu_iscooldown2 == false) {
    		paused = false;
    		menuanim = false;
    		GetComponent<AudioSource>().PlayOneShot(menucloseSFX, 0.5f);
			//showicons = false;
			menutop.GetComponent<Animator>().SetBool("Topping", false);
			menubottom.GetComponent<Animator>().SetBool("Bottoming", false);
			menu_iscooldown2 = true;
    		Time.timeScale = 1;
    	}

		//if(paused == true && menuface.GetComponent<Image>().sprite != menufacetop) {
		//	menuanim = true;
		//}

    	// If the game isn't paused, time will flow as normal and menu anims will be reset
		if(paused == false) {
			Time.timeScale = 1;
			menuanim = false;
			showicons = false;
			menuzoom.SetActive(false);
    		menuface.SetActive(false);
    		menutop.SetActive(false);
    		menubottom.SetActive(false);
    		
		}

		// If the menu is animating, the intro menu animation will play
		if(menuanim == true) {
			//if(menuface.GetComponent<Image>().sprite != menufacetop) {
    			menuzoom.SetActive(true);
				menuzoom.GetComponent<Animator>().SetBool("Zooming", true);
			
				if(menuzoom.GetComponent<Image>().sprite == menuzoomface) {
					menuface.SetActive(true);
					//menuface.GetComponent<Animator>().SetBool("Facing", true);
				}
			//}

			if(menuface.GetComponent<Image>().sprite == menufacetop) {
				menuanim = false;
			}
		}

		// When the intro menu anim is finished, it will display the icons
		if(menuanim == false && paused == true && showicons == false) {
			showicons = true;
			menu_iscooldown2 = true;
			
		}
			
		// If the icons are showing, the menu will play the default animation
		if(showicons == true) {
			//menuzoom.SetActive(false);
			//menuface.SetActive(false);
			//menuface.GetComponent<Animator>().SetBool("Facing", false);
			//menuzoom.GetComponent<Animator>().SetBool("Zooming", false);
			//menuface.GetComponent<Image>().sprite = menufacereset;
			//menuzoom.SetActive(false);
    		//menuface.SetActive(false);
			menuface.GetComponent<Animator>().SetBool("Facing", false);
			menuzoom.GetComponent<Animator>().SetBool("Zooming", false);
			menuzoom.GetComponent<Image>().sprite = menufacereset;
			//menuzoom.GetComponent<Image>().sprite = menufacereset;
			menutop.SetActive(true);
			menubottom.SetActive(true);
			menutop.GetComponent<Animator>().SetBool("Topping", true);
			menubottom.GetComponent<Animator>().SetBool("Bottoming", true);
			//menuface.GetComponent<Animator>().SetBool("Facing", true);
			//menuface.GetComponent<Animator>().SetBool("Facing", true);
		}

		//if(menutop.GetComponent<Image>().sprite == menutopend){
		//	menuanim = false;
		//}

		//if()

		// If the menu screen has changed, a counter will start
		if (menu_iscooldown == true) {
           	menu_cooldowncounter++;
       	}

       	// If the menu anim finished, a counter will start
       	if (menu_iscooldown2 == true) {
           	menu_cooldowncounter2++;
       	}

       	// If the menu counter is equal to its time, the menu screen can be changed again
	  	if (menu_cooldowncounter >= menu_cooldowntime) {
            menu_iscooldown = false;
           	menu_cooldowncounter = 0;
        }

        // If the menu counter is equal to half its time, the menu screen can be interacted with again
        if (menu_cooldowncounter2 >= (menu_cooldowntime * 1.5f)) {
            menu_iscooldown2 = false;
           	menu_cooldowncounter2 = 0;
        }
	}
}